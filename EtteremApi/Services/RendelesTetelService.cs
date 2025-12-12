using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.Etterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi.Services
{
    public class RendelesTetelService : IRendelesTetel
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto;
        public RendelesTetelService(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }

        public async Task<object> GetAllRendelesTetel()
        {
            try
            {
                var rendelesek = await _context.Rendelestetels.ToListAsync();
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
