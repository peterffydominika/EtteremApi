using EtteremApi.Models;
using EtteremApi.Models.Dtos;
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
        public TermekController(EtteremContext context)
        {
            _context = context;
        }

        [HttpPost("TermékFelvitele")]
        public async Task<IActionResult> TermekFelvitele(AddTermekDto addTermekDto)
        {
            try
            {
                var termek = new Termek
                {
                    TermekNev = addTermekDto.TermekNev,
                    Ar = addTermekDto.Ar
                };
                if (termek != null)
                {
                    await _context.Termeks.AddAsync(termek);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new
                    {
                        message = "Sikeres hozzáadás!",
                        result = termek
                    });
                }
                return StatusCode(404, new
                {
                    message = "Sikertelen hozzáadás!",
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
