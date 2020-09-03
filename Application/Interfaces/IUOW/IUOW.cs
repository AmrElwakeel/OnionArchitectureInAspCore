using Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IUOW
{
    public interface IUOW
    {
        IProductRepository GetProductRepository { get; }
    }
}
