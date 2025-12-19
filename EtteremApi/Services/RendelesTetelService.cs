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
        //4.Feladat
        public async Task<object> GetAllRendelesTetelekkel()
        {
            try
            {
                var rendelestetelek = await _context.Rendelestetels
                    .Include(rt => rt.Rendeles)
                    .Include(rt => rt.Termek)
                    .Select(rt => new { rt.Rendeles.RendelesId, rt.Termek.TermekNev, rt.Termek.Ar })
                    .ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés!";
                _responseDto.Result = rendelestetelek;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
        //5.Feladat
        public async Task<object> GetRendelesekTetelekkel()
        {
            try
            {
                var rendelestetelek = await _context.Rendelestetels
                    .Include(rt => rt.Rendeles)
                    .Include(rt => rt.Termek)
                    .Select(rt => new { rt.Rendeles.RendelesId, rt.Termek.TermekNev, rt.Termek.Ar })
                    .GroupBy(rt => rt.RendelesId)
                    .ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés!";
                _responseDto.Result = rendelestetelek;
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
