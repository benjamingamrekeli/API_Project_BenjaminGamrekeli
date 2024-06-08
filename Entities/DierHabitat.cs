using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli
{
    public class DierHabitat //associatietabel voor meer-op-meer relatie tussen dier en habitat
    {
        public int DierId { get; set; }
        public Dier Dier { get; set; }
        public int HabitatId { get; set; }
        public Habitat Habitat { get; set; }
    }
}
