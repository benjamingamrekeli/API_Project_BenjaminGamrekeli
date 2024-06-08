using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.Services
{
    public interface IHabitatData
    {
        IEnumerable<Habitat> GetAllHabitats();
        Habitat GetHabitat(int id);
        void CreateHabitat(Habitat habitat);
        void UpdateHabitat(Habitat habitat);
        void DeleteHabitat(int id);
    }
}
