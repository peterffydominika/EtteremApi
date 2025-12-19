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

        public async Task<object> Post(AddTermekDto addTermekDto)
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
                _responseDto.Message = "Sikeres hozzáadás!";
                _responseDto.Result = termek;
                return _responseDto;
            }
            catch (Exception ex)
            {

                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
        public async Task<object> Delete(int termekId)
        {
            try
            {
                var termek = await _context.Termeks.FirstOrDefaultAsync(x => x.TermekId == termekId);
                if (termek != null)
                {
                    _responseDto.Message = "A termék nem található.";
                    _responseDto.Result = null;
                    return _responseDto;
                }
                _context.Termeks.Remove(termek);
                await _context.SaveChangesAsync();
                _responseDto.Message = "Sikeres törlés!";
                _responseDto.Result = termek;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
        public async Task<object> Update(int termekId, UpdateTermekDto updateTermekDto)
        {
            try
            {
                var ujTermek = await _context.Termeks.FirstOrDefaultAsync(x => x.TermekId == termekId);
                if (ujTermek != null)
                {
                    ujTermek.TermekNev = updateTermekDto.TermekNev;
                    ujTermek.Ar = updateTermekDto.Ar;

                    _context.Termeks.Update(ujTermek);
                    await _context.SaveChangesAsync();
                    _responseDto.Message = "Sikeres frissítés.";
                    _responseDto.Result = null;
                    return _responseDto;
                }
                else
                {
                    _responseDto.Message = "A termék nem található.";
                    _responseDto.Result = null;
                    return _responseDto;
                }
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }

        public async Task<object> GetAllTermekNevAr()
        {
            try
            {
                var termekek = await _context.Termeks.Select(t => new GetTermekNevArDto { TermekNev = t.TermekNev, Ar = t.Ar }).ToListAsync();
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
