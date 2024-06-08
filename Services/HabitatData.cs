using API_Project_BenjaminGamrekeli.Entities;
namespace API_Project_BenjaminGamrekeli.Services
{
    public class HabitatData : IHabitatData
    {
        private DierContext context;

        public HabitatData(DierContext context)
        {
            this.context = context;
        }

        public IEnumerable<Habitat> GetAllHabitats()
        {
            return context.Habitats.ToList();
        }
        public Habitat GetHabitat(int id)
        {
            return context.Habitats.FirstOrDefault(x => x.Id == id);
        }
        public void CreateHabitat(Habitat habitat)
        {
            habitat.Id = context.Habitats.Max(x => x.Id) + 1;
            context.Habitats.Add(habitat);
            context.SaveChanges();
        }
        public void UpdateHabitat(Habitat habitat)
        {
            Habitat oldHabitat = context.Habitats.FirstOrDefault(x => x.Id == habitat.Id);
            oldHabitat.HabitatNaam = habitat.HabitatNaam;
            context.SaveChanges();
        }
        public void DeleteHabitat(int id)
        {
            Habitat deleteHabitat = context.Habitats.FirstOrDefault(x => x.Id == id);
            context.Habitats.Remove(deleteHabitat);
            context.SaveChanges();
        }
    }
}
