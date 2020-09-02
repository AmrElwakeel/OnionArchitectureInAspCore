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

namespace Application.Featrures.ProductFeatrures.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductListDto>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<ProductListDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            { 
                var ProjectList= await _context.Products
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
