using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IRepositories
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<string> GetProductBaeCode();
    }
}
