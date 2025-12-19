namespace EtteremApi.Services.Etterem
{
    public interface IRendelesTetel
    {
        Task<object> GetAllRendelesTetel();
        Task<object> GetAllRendelesTetelekkel();
        Task<object> GetRendelesekTetelekkel();
        Task<object> GetKolaRendeles();

    }
}
