using API_Project_BenjaminGamrekeli.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_Project_BenjaminGamrekeli.ViewModels
{
    public class HabitatCreateViewModel
    {
        [Required]
        public HabitatNaam HabitatNaam { get; set; }
    }
}
