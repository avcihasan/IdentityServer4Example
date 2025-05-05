using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "ReadProduct")]
        public IActionResult GetProducts()
        {
            return Ok(nameof(GetProducts));
        }

        [HttpPost]
        [Authorize(Policy = "UpdateOrCreateProduct")]
        public IActionResult CreateProduct()
        {
            return Ok(nameof(CreateProduct));
        }
        [HttpPut]
        [Authorize(Policy = "UpdateOrCreateProduct")]
        public IActionResult UptadeProduct()
        {
            return Ok(nameof(UptadeProduct));
        }
    }
}
