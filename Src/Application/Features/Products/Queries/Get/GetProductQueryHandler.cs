using Application.Contracts;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Get
{
    internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private IUnitOfWork _uow;

        public GetProductQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var spec = new GetProductsSpec(request.Id);
            return await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);

            //var entity = await _uow.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
            //TODO HandleException
            //if (entity == null) throw new Exception("Error message");
            //return entity;
        }
    }
}
