using System;
using Microsoft.AspNetCore.Mvc;


namespace WebApiExemplo.Api.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("asda");
            return Ok(new
            {
                content = DateTime.Now
            });
        }

        [HttpGet("/api/ping/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new
            {
                content = DateTime.Now
            });
        }
    }
}
