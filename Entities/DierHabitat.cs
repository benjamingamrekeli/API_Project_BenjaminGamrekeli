using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli
{
    public class DierHabitat
    {
        public int DierId { get; set; }
        public Dier Dier { get; set; }
        public int HabitatId { get; set; }
        public Habitat Habitat { get; set; }
    }
}
