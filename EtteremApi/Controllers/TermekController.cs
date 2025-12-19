using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.Etterem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly EtteremContext _context;
        private readonly ITermek _termek;

        public TermekController(EtteremContext context, ITermek termek)
        {
            _context = context;
            _termek = termek;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTermek()
        {
            try
            {
                var requestResult = await _termek.GetAllTermek();
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
        public async Task<IActionResult> Post(AddTermekDto addTermekDto)
        {
            try
            {
                var requestResult = await _termek.Post(addTermekDto);
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

        [HttpDelete("{termekId}")]
        public async Task<IActionResult> Delete(int termekId)
        {
            try
            {
                var requestResult = await _termek.Delete(termekId);
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

        [HttpPut("{termekId}")]
        public async Task<IActionResult> Update(int termekId, UpdateTermekDto updateTermekDto)
        {
            try
            {
                var requestResult = await _termek.Update(termekId, updateTermekDto);
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

        //2.Feladat
        [HttpGet("nev-ar")]
        public async Task<ActionResult> GetAllTermekNevAr()
        {
            try
            {
                var requestResult = await _termek.GetAllTermekNevAr();
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
