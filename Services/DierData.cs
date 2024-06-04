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
            return (Dier)context.Dieren.Where(x => x.Id == id);
        }
        public void CreateDier(Dier dier) 
        {
            context.Dieren.Add(dier);
            context.SaveChanges();
        }
        public void UpdateDier(int id) 
        {
            context.Dieren.Update(GetDier(id));
            context.SaveChanges();
        }
        public void DeleteDier(int id)
        {
            context.Dieren.Remove(GetDier(id));
            context.SaveChanges();
        }
    }
}
