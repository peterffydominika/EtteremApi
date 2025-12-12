using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.Etterem
{
    public interface IRendeles
    {
        Task<object> GetAllRendeles();
        Task<object> Post(AddRendelesDto addRendelesDto);
    }
}
