using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.Etterem
{
    public interface ITermek
    {
        Task<object> GetAllTermek();
        Task<object> Post(AddTermekDto addTermekDto);
    }
}
