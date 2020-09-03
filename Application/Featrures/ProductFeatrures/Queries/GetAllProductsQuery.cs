using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Models;
using AutoMapper.QueryableExtensions;
using Application.Interfaces.IUOW;

namespace Application.Featrures.ProductFeatrures.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductListDto>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
        {
            private readonly IUOW _unitOfWork;
            private readonly IMapper _mapper;
            public GetAllProductsQueryHandler(IUOW unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<ProductListDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            { 
                var ProjectList= await _unitOfWork.GetProductRepository.GetAll().AsQueryable()
                    .ProjectTo<ProductListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (ProjectList == null)
                {
                    return null;
                }
                return ProjectList;
            }
        }
    }
}
