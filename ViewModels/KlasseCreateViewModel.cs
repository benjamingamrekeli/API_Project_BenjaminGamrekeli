using API_Project_BenjaminGamrekeli.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_Project_BenjaminGamrekeli.ViewModels
{
    public class KlasseCreateViewModel
    {
        [Required]
        public KlasseNaam KlasseNaam { get; set; }
    }
}
