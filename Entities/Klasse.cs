namespace API_Project_BenjaminGamrekeli.Entities
{
    public enum KlasseNaam { Zoogdier, Reptiel, Vis, Insect}
    public class Klasse
    {
        /*public Klasse() 
        {
            Dieren = new List<Dier>();
        }*/
        public int Id { get; set; }
        public KlasseNaam KlasseNaam { get; set; }
        public List<Dier> Dieren { get; set; }
    }
}
