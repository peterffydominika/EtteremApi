namespace EtteremApi.Models.Dtos
{
    public class UpdateRendelesDto
    {
        public int AsztalSzam
        {
            get; set;
        }

        public string FizetesMod { get; set; } = null!;
    }
}
