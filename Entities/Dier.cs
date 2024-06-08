namespace API_Project_BenjaminGamrekeli.Entities
{
    public enum Dieet { Carnivoor, Herbivoor, Omnivoor}
    public class Dier  //dier verwijst naar diersoort, geen aparte dier
    {
        public int Id { get; set; }
        public string Naam { get; set;}
        public int KlasseId { get; set; }
        public Klasse Klasse { get; set;} //een dier kan maar tot één klasse behoren
        public Dieet Dieet { get; set;}
        public int LevensVerwachting { get; set; }
        public List<Habitat> Habitats { get; set; } // een dier kan meerdere habitats hebben
        public List<DierHabitat> DierHabitats { get; set; } 
    }
}
