using Application.Features.ProductBrands.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class ProductBrandController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ProductBrand>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Meditor.Send(new GetAllProductBrandQuery(), cancellationToken));
        }
    }
}
