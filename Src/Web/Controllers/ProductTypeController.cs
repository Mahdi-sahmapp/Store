using Application.Features.ProductTypes.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class ProductTypeController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ProductType>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Meditor.Send(new GetAllProductTypeQuery(), cancellationToken));
        }
    }
}
