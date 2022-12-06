using Application.Dto.Products;
using Application.Features.ProductBrands.Queries.GetAll;
using Application.Features.Products.Queries.Get;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Meditor.Send(new GetAllProductQuery(),cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Meditor.Send(new GetProductQuery(id), cancellationToken));
        }
    }
}
