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

        [HttpPost("TermekFelvitele")]
        public async Task<IActionResult> TermekFelvitele(AddTermekDto addTermekDto)
        {
            try
            {
                var termek = new Termek
                {
                    TermekNev = addTermekDto.TermekNev,
                    Ar = addTermekDto.Ar
                };
                await _context.Termeks.AddAsync(termek);
                await _context.SaveChangesAsync();
                return StatusCode(201, new
                {
                    message = "Sikeres hozzáadás!",
                    result = termek
                });
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
