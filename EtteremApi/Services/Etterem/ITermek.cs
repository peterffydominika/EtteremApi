using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.Etterem
{
    public interface ITermek
    {
        Task<object> GetAllTermek();
        Task<object> Post(AddTermekDto addTermekDto);
        Task<object> Delete(int termekId);
        Task<object> Update(int termekId, UpdateTermekDto updateTermekDto);
    }
}
