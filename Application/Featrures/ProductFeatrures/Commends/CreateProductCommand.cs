using Application.Interfaces;
using Application.Interfaces.IUOW;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Featrures.ProductFeatrures.Commends
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IUOW _unitOfWork;
            public CreateProductCommandHandler(IUOW unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.Rate = command.Rate;
                product.Description = command.Description;
                _unitOfWork.GetProductRepository.Create(product);
                await _unitOfWork.GetProductRepository.SaveChanges();

                return product.Id;
            }
        }
    }
}
