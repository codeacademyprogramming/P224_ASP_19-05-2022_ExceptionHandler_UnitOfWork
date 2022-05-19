using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.Repositories;

namespace Shop.Core
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
