using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pikos.API.Controllers
{
    [Route("api/health")]
    [ApiController]
    public class APIHealthController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(new
            {
                Status = "Up and running :)"
            });
        }
    }
}
