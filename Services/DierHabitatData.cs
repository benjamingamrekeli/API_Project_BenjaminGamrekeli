using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli;
using API_Project_BenjaminGamrekeli.Services;

public class DierHabitatData:IDierHabitatData
{
    private DierContext context;

    public DierHabitatData(DierContext context)
    {
        this.context = context;
    }

    public void CreateDierHabitat(DierHabitat dierHabitat)
    {
        context.DierHabitats.Add(dierHabitat);
        context.SaveChanges();
    }

    // Other CRUD methods if needed
}
