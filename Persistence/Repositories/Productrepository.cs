using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    public class Productrepository : Repository<Product>, IProductRepository
    {
        public Productrepository(ApplicationDbContext context):base(context) { }
        ApplicationDbContext AppContext => (ApplicationDbContext)_context;
        public IEnumerable<string> GetProductBaeCode()
        {
            return AppContext.Products.Select(a => a.Barcode).ToList();
        }
    }
}
