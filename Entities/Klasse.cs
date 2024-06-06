namespace API_Project_BenjaminGamrekeli.Entities
{
    public enum KlasseNaam { Zoogdier, Reptiel, Vis, Insect}
    public class Klasse
    {
        public int Id { get; set; }
        public KlasseNaam KlasseNaam { get; set; }
        public List<Dier> Dieren { get; set; }
    }
}
