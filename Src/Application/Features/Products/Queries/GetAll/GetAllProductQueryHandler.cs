using Application.Contracts;
using Application.Dto.Products;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, PaginationResponse<ProductDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            //logic
                        
            var spec = new GetProductsSpec(request);
            var count = await _uow.Repository<Product>().CountAsyncSpec(new ProductCountSpec(request), cancellationToken);
            var resualt = await _uow.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
            var model= _mapper.Map<IEnumerable<ProductDto>>(resualt);
            return new PaginationResponse<ProductDto>(request.PageIndex, request.PageSize, count, model);
        }
    }
}
