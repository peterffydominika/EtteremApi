using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.Etterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi.Services
{
    public class RendelesService : IRendeles
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto = new ResponseDto();
        public RendelesService(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }
        public async Task<object> GetAllRendeles()
        {
            try
            {
                var rendelesek = await _context.Rendeles.ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés!";
                _responseDto.Result = rendelesek;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
    }
}
