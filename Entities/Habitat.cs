namespace API_Project_BenjaminGamrekeli.Entities
{
    public enum HabitatNaam { Grasland, Woestijn, Regenwoud, Zee, Bergen }
    //public enum Continent { Afrika, Europa, Azië, Amerika, Australië}
    public class Habitat
    {
        public int Id { get; set; }
        public HabitatNaam HabitatNaam { get; set; }
        //public Continent Continent { get; set; }
        public List<Dier> Dieren { get; set; }
        public List<DierHabitat> DierHabitats { get; set; }
    }
}
