using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.ViewModels
{
    public class DierCreateViewModel
    {
        public string Naam { get; set; }
        public KlasseNaam KlasseNaam { get; set; }
        public Dieet Dieet { get; set; }
        public int LevensVerwachting { get; set; }
    }
}
