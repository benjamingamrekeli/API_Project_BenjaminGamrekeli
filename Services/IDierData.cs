using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.Services
{
    public interface IDierData
    {
        IEnumerable<Dier> GetAllDieren();
        Dier GetDier(int id);
        void CreateDier(Dier dier);
        void UpdateDier(int id);
        void DeleteDier(int id);
    }
}
