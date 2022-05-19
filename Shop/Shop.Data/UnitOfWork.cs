using Shop.Core;
using Shop.Core.Repositories;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ShopDbContext _context;

        public UnitOfWork(ShopDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository != null ? _categoryRepository : new CategoryRepository(_context);

        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);
    }
}
