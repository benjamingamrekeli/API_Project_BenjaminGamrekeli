using API_Project_BenjaminGamrekeli;
using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

//alle data van database verwijderen bij het opstarten van de programma
using (var context = new DierContext())
{
    foreach(Dier dier in context.Dieren)
    {
        context.Dieren.Remove(dier);
    }
    foreach (Habitat habitat in context.Habitats)
    {
        context.Habitats.Remove(habitat);
    }
    foreach (Klasse klasse in context.Klassen)
    {
        context.Klassen.Remove(klasse);
    }
    context.SaveChanges();
}

//dierenklassen aanmaken
var zoogdier = new Klasse
{
    KlasseNaam = KlasseNaam.Zoogdier
};
var reptiel = new Klasse
{
    KlasseNaam = KlasseNaam.Reptiel
};
var vis = new Klasse
{
    KlasseNaam = KlasseNaam.Vis
};
var insect = new Klasse
{
    KlasseNaam = KlasseNaam.Insect
};
using (var context = new DierContext())
{
    context.Klassen.Add(zoogdier);
    context.Klassen.Add(reptiel);
    context.Klassen.Add(vis);
    context.Klassen.Add(insect);
    context.SaveChanges();
}

//dierensoorten aanmaken
using (var context = new DierContext())
{
    var leeuw = new Dier
    {
        Naam = "Leeuw",
        //Klasse = (Klasse)context.Klassen.Select(klasse => klasse.KlasseNaam == KlasseNaam.Zoogdier),
        Dieet = Dieet.Carnivoor,
        LevensVerwachting = 10
    };
    var schildpad = new Dier
    {
        Naam = "Schildpad",
        //Klasse = (Klasse)context.Klassen.Select(klasse => klasse.KlasseNaam == KlasseNaam.Reptiel),
        Dieet = Dieet.Carnivoor,
        LevensVerwachting = 50
    };
    context.Dieren.Add(leeuw);
    context.Dieren.Add(schildpad);

    context.SaveChanges();
    
}


await Host.CreateDefaultBuilder(args).
    ConfigureWebHostDefaults(webbuilder => { webbuilder.UseStartup<Startup>(); }).Build().RunAsync();
/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "API_Project_BenjaminGamrekeli");

app.Run();*/
