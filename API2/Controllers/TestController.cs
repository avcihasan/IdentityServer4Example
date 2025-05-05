using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "ReadOrder")]
        public IActionResult GetOrders()
        {
            return Ok(nameof(GetOrders));
        }

        [HttpPost]
        [Authorize(Policy = "UpdateOrCreateOrder")]
        public IActionResult CreateOrder()
        {
            return Ok(nameof(CreateOrder));
        }
        [HttpPut]
        [Authorize(Policy = "UpdateOrCreateOrder")]
        public IActionResult UptadeOrder()
        {
            return Ok(nameof(UptadeOrder));
        }
    }
}
