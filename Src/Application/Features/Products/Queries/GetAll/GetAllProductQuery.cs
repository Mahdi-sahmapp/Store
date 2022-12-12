using Application.Contracts;
using Application.Dto.Products;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQuery : RequestParametersBasic,IRequest<PaginationResponse<ProductDto>>, ICacheQuery
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        [BindNever]
        public int HoursSaveData => 1; // 1 hour save data
    }
}
