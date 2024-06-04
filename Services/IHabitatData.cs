using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.Services
{
    public interface IHabitatData
    {
        IEnumerable<Habitat> GetAllHabitats();
        Habitat GetHabitat(int id);
        void AddHabitat(Habitat habitat);
        void UpdateHabitat(int id);
        void DeleteHabitat(int id);
    }
}
