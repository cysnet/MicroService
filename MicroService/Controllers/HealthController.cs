using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        [HttpGet] public IActionResult Get() { return Ok("ok"); }
    }
}