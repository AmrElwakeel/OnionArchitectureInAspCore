using Application.Interfaces;
using Application.Interfaces.IUOW;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Featrures.ProductFeatrures.Commends
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IUOW _unitOfWork;
            public DeleteProductByIdCommandHandler(IUOW unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _unitOfWork.GetProductRepository.FindById(command.Id);
                if (product == null) return default;
                _unitOfWork.GetProductRepository.Delete(command.Id);
                await _unitOfWork.GetProductRepository.SaveChanges();
                return product.Id;
            }
        }
    }
}
