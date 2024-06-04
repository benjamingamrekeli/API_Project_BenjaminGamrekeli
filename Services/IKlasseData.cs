using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.Services
{
    public interface IKlasseData
    {
        IEnumerable<Klasse> GetAllKlassen();
        Klasse GetKlasse(int id);
        void AddKlasse(Klasse klasse);
        void UpdateKlasse(int id);
        void DeleteKlasse(int id);
    }
}
