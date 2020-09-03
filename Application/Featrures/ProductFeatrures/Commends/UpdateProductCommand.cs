using Application.Interfaces;
using Application.Interfaces.IUOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Featrures.ProductFeatrures.Commends
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IUOW _unitOfWork;
            public UpdateProductCommandHandler(IUOW unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _unitOfWork.GetProductRepository.FindById(command.Id);

                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.Barcode = command.Barcode;
                    product.Name = command.Name;
                    product.Rate = command.Rate;
                    product.Description = command.Description;
                    await _unitOfWork.SaveChanges();

                    return product.Id;
                }
            }
        }
    }
}
