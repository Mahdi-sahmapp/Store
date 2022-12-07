using Application.Common.Mapping;
using Application.Common.Mapping.Resolvers;
using Application.Dto.Common;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Products
{
    public class ProductDto :CommandDto,IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        //public bool IsDelete { get; set; } = false;
        public string ProductType { get; set; } // title
        public string ProductBrand { get; set; } // title

        public void Mapping(Profile profile)
        {


            profile.CreateMap<Product, ProductDto>()
                .ForMember(a => a.ProductType, c => c.MapFrom(a => a.ProductType.Title))
                .ForMember(a => a.ProductBrand, c => c.MapFrom(a => a.ProductBrand.Title))
                .ForMember(a => a.PictureUrl, c => c.MapFrom<ProductImageUrlResolver>());


            //profile.CreateMap<Product, ProductDto>()
            //    .ForMember(a => a.ProductBrand, c => c.MapFrom(a => a.ProductBrand.Title));
        }
    }
}
