using API_Project_BenjaminGamrekeli.Entities;
namespace API_Project_BenjaminGamrekeli.Services
{
    public class DierData:IDierData
    {
        private DierContext context;

        public DierData(DierContext context)
        {
            this.context = context;
        }

        public IEnumerable<Dier> GetAllDieren() 
        {
            return context.Dieren.ToList();
        }
        public Dier GetDier(int id) 
        {
            return context.Dieren.FirstOrDefault(x => x.Id == id);
        } 
        public void CreateDier(Dier dier) 
        {
            dier.Id = context.Dieren.Max(x => x.Id)+1;
            context.Dieren.Add(dier);
            context.SaveChanges();
        }
        public void UpdateDier(Dier dier) 
        {
            Dier oldDier = context.Dieren.FirstOrDefault(x=>x.Id == dier.Id);
            oldDier.Naam = dier.Naam;
            oldDier.Klasse = dier.Klasse;
            oldDier.Dieet = dier.Dieet;
            oldDier.LevensVerwachting = dier.LevensVerwachting;
            context.SaveChanges();
        }
        public void DeleteDier(int id)
        {
            Dier deleteDier = context.Dieren.FirstOrDefault(x =>x.Id == id);
            context.Dieren.Remove(deleteDier);
            context.SaveChanges();
        }
    }
}
