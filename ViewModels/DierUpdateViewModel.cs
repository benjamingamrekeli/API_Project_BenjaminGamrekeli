using API_Project_BenjaminGamrekeli.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_Project_BenjaminGamrekeli.ViewModels
{
    public class DierUpdateViewModel
    {
        public string Naam { get; set; }
        public KlasseNaam KlasseNaam { get; set; }
        public Dieet Dieet { get; set; }
        public int LevensVerwachting { get; set; }
        public List<int> HabitatIds { get; set; }
    }
}
