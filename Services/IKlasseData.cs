using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.Services
{
    public interface IKlasseData
    {
        IEnumerable<Klasse> GetAllKlassen();
        Klasse GetKlasse(int id);
        void CreateKlasse(Klasse klasse);
        void UpdateKlasse(Klasse klasse);
        void DeleteKlasse(int id);
    }
}
