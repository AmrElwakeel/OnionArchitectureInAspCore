using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IUOW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UOW : IUOW
    {
        private readonly ApplicationDbContext _context;
        IProductRepository productRepository;
        public UOW(ApplicationDbContext context)
        {
            _context = context;
        }
        public IProductRepository GetProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new Productrepository(_context);
                return productRepository;
            }
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
