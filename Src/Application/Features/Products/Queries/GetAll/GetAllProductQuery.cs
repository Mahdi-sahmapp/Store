﻿using Application.Contracts;
using Application.Dto.Products;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>, ICacheQuery
    {
        public int HoursSaveData => 1; // 1 hour save data
    }
}
