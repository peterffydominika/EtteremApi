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
        public async Task<object> Post(AddRendelesDto addRendelesDto)
        {
            try
            {
                var rendeles = new Rendeles
                {
                    AsztalSzam = addRendelesDto.AsztalSzam,
                    FizetesMod = addRendelesDto.FizetesMod
                };

                await _context.Rendeles.AddAsync(rendeles);
                await _context.SaveChangesAsync();
                _responseDto.Message = "Sikeres hozzáadás!";
                _responseDto.Result = rendeles;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
        public async Task<object> Delete(int rendelesId)
        {
            try
            {
                var rendeles = await _context.Rendeles.FirstOrDefaultAsync(x => x.RendelesId == rendelesId);
                if (rendeles != null)
                {
                    _responseDto.Message = "A rendelés nem található.";
                    _responseDto.Result = null;
                    return _responseDto;
                }
                _context.Rendeles.Remove(rendeles);
                await _context.SaveChangesAsync();
                _responseDto.Message = "Sikeres törlés!";
                _responseDto.Result = rendeles;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
        public async Task<object> Update(int rendelesId, UpdateRendelesDto updateRendelesDto)
        {
            try
            {
                var ujRendeles = await _context.Rendeles.FirstOrDefaultAsync(x => x.RendelesId == rendelesId);
                if (ujRendeles != null)
                {
                    ujRendeles.AsztalSzam = updateRendelesDto.AsztalSzam;
                    ujRendeles.FizetesMod = updateRendelesDto.FizetesMod;

                    _context.Rendeles.Update(ujRendeles);
                    await _context.SaveChangesAsync();
                    _responseDto.Message = "Sikeres frissítés.";
                    _responseDto.Result = null;
                    return _responseDto;
                }
                else
                {
                    _responseDto.Message = "A rendelés nem található.";
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
        //3.Feladat
        public async Task<object> GetRendelesCard()
        {
            try
            {
                var rendelesek = await _context.Rendeles.Where(r => r.FizetesMod == "Bankkártya").Select(r => r.RendelesId).ToListAsync();
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