using Application.Dto.Products;
using AutoMapper;
using AutoMapper.Execution;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping.Resolvers
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _cofiguration;

        public ProductImageUrlResolver(IConfiguration cofiguration)
        {
            _cofiguration = cofiguration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            //if(string.IsNullOrEmpty(source.PictureUrl))
            //     return _cofiguration["BackendUrl"] + "Images/Product/" + source.PictureUrl;
            // return null;

            return _cofiguration["BackendUrl"] + _cofiguration["Imageslocation:ProductsImageLocation"] + source.PictureUrl;
        }
    }
}
