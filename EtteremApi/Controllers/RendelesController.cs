using EtteremApi.Models.Dtos;
using EtteremApi.Services.Etterem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesController : ControllerBase
    {
        private readonly IRendeles _rendeles;
        public RendelesController(IRendeles rendeles)
        {
            _rendeles = rendeles;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllRendeles()
        {
            try
            {
                var requestResult = await _rendeles.GetAllRendeles();
                return Ok(requestResult);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddRendelesDto addRendelesDto)
        {
            try
            {
                var requestResult = await _rendeles.Post(addRendelesDto);
                return StatusCode(201, requestResult);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message
                });
            }
        }
    }
}
