using API_Project_BenjaminGamrekeli.Entities;

namespace API_Project_BenjaminGamrekeli.Services
{
    public class KlasseData:IKlasseData
    {
        private DierContext context;

        public KlasseData(DierContext context)
        {
            this.context = context;
        }

        public IEnumerable<Klasse> GetAllKlassen()
        {
            return context.Klassen.ToList();
        }
        public Klasse GetKlasse(int id)
        {
            return context.Klassen.FirstOrDefault(x => x.Id == id);
        }
        public void CreateKlasse(Klasse klasse)
        {
            klasse.Id = context.Klassen.Max(x => x.Id) + 1;
            context.Klassen.Add(klasse);
            context.SaveChanges();
        }
        public void UpdateKlasse(Klasse klasse)
        {
            Klasse oldKlasse = context.Klassen.FirstOrDefault(x => x.Id == klasse.Id);
            oldKlasse.KlasseNaam = klasse.KlasseNaam;
            oldKlasse.Dieren = klasse.Dieren;
            context.SaveChanges();
        }
        public void DeleteKlasse(int id)
        {
            Klasse deleteKlasse = context.Klassen.FirstOrDefault(x => x.Id == id);
            context.Klassen.Remove(deleteKlasse);
            context.SaveChanges();
        }
    }
}
