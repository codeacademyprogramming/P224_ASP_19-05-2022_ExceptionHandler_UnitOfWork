using AutoMapper;
using Shop.Core;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Service.DTOs.CategoryDtos;
using Shop.Service.Exceptions;
using Shop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        //private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(/*ICategoryRepository categoryRepository*/ IMapper mapper, IUnitOfWork unitOfWork)
        {
            //_categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryGetDto> Get(int? id)
        {
            if (id == null) throw new IdIsNullException("Id Is Null");

            Category category = await _unitOfWork.CategoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id, "Children", "Parent");

            if (category == null) throw new ItemNotFoundException($"Id {id} Wrong");

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task<List<CategoryListDto>> GetList()
        {
            IEnumerable<Category> categories = await _unitOfWork.CategoryRepository.GetAllAsync(c => !c.IsDeleted);

            List<CategoryListDto> categoryListDtos = _mapper.Map<List<CategoryListDto>>(categories);

            return categoryListDtos;
        }

        public async Task<CategoryGetDto> PostAsync(CategoryPostDto categoryPostDto)
        {
            Category category = _mapper.Map<Category>(categoryPostDto);

            await _unitOfWork.CategoryRepository.AddAsync(category);

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task PutAsync(int? id, CategoryPutDto categoryPutDto)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);

            category.Name = categoryPutDto.Name;
            category.IsMain = categoryPutDto.IsMain;
            category.ParentId = categoryPutDto.ParentId;

            await _unitOfWork.CategoryRepository.CommitAsync();
        }
    }
}
