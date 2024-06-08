using API_Project_BenjaminGamrekeli.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_Project_BenjaminGamrekeli.ViewModels
{
    public class DierCreateViewModel
    {
        [Required, MaxLength(50)]
        public string Naam { get; set; }
        [Required]
        public KlasseNaam KlasseNaam { get; set; }
        [Required]
        public Dieet Dieet { get; set; }
        public int LevensVerwachting { get; set; }
        public List<int> HabitatIds { get; set; }
    }
}
