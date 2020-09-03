using Application.Interfaces;
using Application.Interfaces.IUOW;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Featrures.ProductFeatrures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get;}
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IUOW _unitOfWork;
            public GetProductByIdQueryHandler(IUOW unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _unitOfWork.GetProductRepository.FindById(query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }

}
