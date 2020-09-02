using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class ProductListDto:IMapFrom<Product>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductListDto>();
                //.ForMember(d => d.Barcode, opt => opt.MapFrom(src => src.Barcode));
        }
    }
}
