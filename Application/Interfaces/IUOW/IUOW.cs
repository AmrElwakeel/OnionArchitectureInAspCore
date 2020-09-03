using Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IUOW
{
    public interface IUOW
    {
        IProductRepository GetProductRepository { get; }

        Task<bool> SaveChanges();
    }
}
