using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.Etterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi.Services
{
    public class TermekService : ITermek
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto = new ResponseDto();
        public TermekService(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }
        public async Task<object> GetAllTermek()
        {
            try
            {
                var termekek = await _context.Termeks.ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés!";
                _responseDto.Result = termekek;
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
