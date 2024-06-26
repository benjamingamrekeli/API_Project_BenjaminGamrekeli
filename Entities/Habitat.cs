﻿namespace API_Project_BenjaminGamrekeli.Entities
{
    public enum HabitatNaam { Grasland, Woestijn, Regenwoud, Zee, Bergen }
    public class Habitat // een dier kan meerdere habitats hebben en een habitat kan meerdere dieren hebben
    {
        public int Id { get; set; }
        public HabitatNaam HabitatNaam { get; set; }
        public List<Dier> Dieren { get; set; }
        public List<DierHabitat> DierHabitats { get; set; }
    }
}
