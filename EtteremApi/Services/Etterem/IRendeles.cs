using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.Etterem
{
    public interface IRendeles
    {
        Task<object> GetAllRendeles();
        Task<object> Post(AddRendelesDto addRendelesDto);
        Task<object> Delete(int rendelesId);
        Task<object> Update(int rendelesId, UpdateRendelesDto updateRendelesDto);
        Task<object> GetRendelesCard();
    }
}
