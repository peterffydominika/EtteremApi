using EtteremApi.Services.Etterem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesTetelController : ControllerBase
    {
        private readonly IRendelesTetel _rendelesTetel;
        public RendelesTetelController(IRendelesTetel rendelesTetel)
        {
            _rendelesTetel = rendelesTetel;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllRendelesTetel()
        {
            try
            {
                var requestResult = await _rendelesTetel.GetAllRendelesTetel();
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
        [HttpGet("Rendelesek-tetelek")]
        public async Task<ActionResult> GetAllRendelesTetelekkel()
        {
            try
            {
                var requestResult = await _rendelesTetel.GetAllRendelesTetelekkel();
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
        [HttpGet("Rendelesek-tetelekkel-csoportositva")]
        public async Task<ActionResult> GetRendelesekTetelekkel()
        {
            try
            {
                var requestResult = await _rendelesTetel.GetRendelesekTetelekkel();
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
    }
}
