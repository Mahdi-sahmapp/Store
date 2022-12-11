using Application.Contracts;
using Application.Dto.Products;
using Application.Features.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Get
{
    internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var spec = new GetProductsSpec(request.Id);
            var resualt = await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);
            if (resualt == null) throw new NotFoundEntityException();
            return _mapper.Map<ProductDto>(resualt);

            //var entity = await _uow.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
