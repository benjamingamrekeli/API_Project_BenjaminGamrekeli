using API_Project_BenjaminGamrekeli;
using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

// alle data van database verwijderen bij het opstarten van de programma
using (var context = new DierContext())
{
    context.Dieren.RemoveRange(context.Dieren);
    context.Habitats.RemoveRange(context.Habitats);
    context.Klassen.RemoveRange(context.Klassen);
    context.DierHabitats.RemoveRange(context.DierHabitats);
    context.SaveChanges();
}

// habitats aanmaken en
// dierensoorten aanmaken en toevoegen aan klassen
// en dierhabitats aanmaken om meer-op-meer relatie te leggen tussen dieren en habitats
using (var context = new DierContext())
{
    // dierenklassen aanmaken
    var zoogdier = new Klasse
    {
        KlasseNaam = KlasseNaam.Zoogdier,
        Dieren = new List<Dier>()
    };
    var reptiel = new Klasse
    {
        KlasseNaam = KlasseNaam.Reptiel,
        Dieren = new List<Dier>()
    };
    var vis = new Klasse
    {
        KlasseNaam = KlasseNaam.Vis,
        Dieren = new List<Dier>()
    };
    var insect = new Klasse
    {
        KlasseNaam = KlasseNaam.Insect,
        Dieren = new List<Dier>()
    };

    // habitats aanmaken
    var grasland = new Habitat
    {
        HabitatNaam = HabitatNaam.Grasland,
        Dieren = new List<Dier>()
    };
    var woestijn = new Habitat
    {
        HabitatNaam = HabitatNaam.Woestijn,
        Dieren = new List<Dier>()
    };
    var regenwoud = new Habitat
    {
        HabitatNaam = HabitatNaam.Regenwoud,
        Dieren = new List<Dier>()
    };
    var zee = new Habitat
    {
        HabitatNaam = HabitatNaam.Zee,
        Dieren = new List<Dier>()
    };
    var bergen = new Habitat
    {
        HabitatNaam = HabitatNaam.Bergen,
        Dieren = new List<Dier>()
    };

    // diersoorten aanmaken
    var leeuw = new Dier
    {
        Naam = "Leeuw",
        Dieet = Dieet.Carnivoor,
        LevensVerwachting = 10
    };
    var schildpad = new Dier
    {
        Naam = "Schildpad",
        Dieet = Dieet.Carnivoor,
        LevensVerwachting = 50
    };

    // Add classes and habitats to the context
    context.Klassen.AddRange(zoogdier, reptiel, vis, insect);
    context.Habitats.AddRange(grasland, woestijn, regenwoud, zee, bergen);

    context.SaveChanges();

    // Add dieren to their respective klassen
    leeuw.KlasseId = zoogdier.Id;
    schildpad.KlasseId = reptiel.Id;

    context.Dieren.AddRange(leeuw, schildpad);

    context.SaveChanges();

    // Create DierHabitat entries
    var dierhabitat1 = new DierHabitat { DierId = leeuw.Id, HabitatId = grasland.Id };
    var dierhabitat2 = new DierHabitat { DierId = schildpad.Id, HabitatId = regenwoud.Id };

    context.DierHabitats.AddRange(dierhabitat1, dierhabitat2);

    context.SaveChanges();
}

await Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webbuilder => { webbuilder.UseStartup<Startup>(); })
    .Build()
    .RunAsync();

/* var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API_Project_BenjaminGamrekeli");

app.Run(); */



/*
is this correct :
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
    foreach (DierHabitat dierHabitat in context.DierHabitats)
    {
        context.DierHabitats.Remove(dierHabitat);
    }
    context.SaveChanges();
}


// habitats aanmaken en
// dierensoorten aanmaken en toevoegen aan klassen
// en dierhabitats aanmaken om meer-op-meer relatie te leggen tussen dieren en habitats
using (var context = new DierContext())
{
    //dierenklassen aanmaken
    var zoogdier = new Klasse
    {
        KlasseNaam = KlasseNaam.Zoogdier,
        Dieren = new List<Dier>()
    };
    var reptiel = new Klasse
    {
        KlasseNaam = KlasseNaam.Reptiel,
        Dieren = new List<Dier>()
    };
    var vis = new Klasse
    {
        KlasseNaam = KlasseNaam.Vis,
        Dieren = new List<Dier>()
    };
    var insect = new Klasse
    {
        KlasseNaam = KlasseNaam.Insect,
        Dieren = new List<Dier>()
    };

    //habitats aanmaken
    var grasland = new Habitat
    {
        HabitatNaam = HabitatNaam.Grasland,
        Dieren = new List<Dier>()
    };
    var woestijn = new Habitat
    {
        HabitatNaam = HabitatNaam.Woestijn,
        Dieren = new List<Dier>()
    };
    var regenwoud = new Habitat
    {
        HabitatNaam = HabitatNaam.Regenwoud,
        Dieren = new List<Dier>()
    };
    var zee = new Habitat
    {
        HabitatNaam = HabitatNaam.Zee,
        Dieren = new List<Dier>()
    };
    var bergen = new Habitat
    {
        HabitatNaam = HabitatNaam.Bergen,
        Dieren = new List<Dier>()
    };

    //diersoorten aanmaken
    var leeuw = new Dier
    {
        Naam = "Leeuw",
        //KlasseId = zoogdierId,  // Assign KlasseId here
        Dieet = Dieet.Carnivoor,
        LevensVerwachting = 10
    };
    var schildpad = new Dier
    {
        Naam = "Schildpad",
        //KlasseId = reptielId,  // Assign KlasseId here
        Dieet = Dieet.Carnivoor,
        LevensVerwachting = 50
    };

    context.Klassen.Add(zoogdier);
    context.Klassen.Add(reptiel);
    context.Klassen.Add(vis);
    context.Klassen.Add(insect);

    context.Habitats.Add(grasland);
    context.Habitats.Add(woestijn);
    context.Habitats.Add(zee);
    context.Habitats.Add(bergen);

    context.SaveChanges();

    context.Dieren.Add(leeuw);
    context.Dieren.Add(schildpad);
    zoogdier.Dieren.Add(leeuw);
    reptiel.Dieren.Add(schildpad);

    context.SaveChanges();

    var dierhabitat1 = new DierHabitat { DierId = leeuw.Id, HabitatId = grasland.Id};
    var dierhabitat2 = new DierHabitat { DierId = schildpad.Id, HabitatId = regenwoud.Id };

    context.DierHabitats.Add(dierhabitat1);
    context.DierHabitats.Add(dierhabitat2);

    context.SaveChanges();
}





await Host.CreateDefaultBuilder(args).
    ConfigureWebHostDefaults(webbuilder => { webbuilder.UseStartup<Startup>(); }).Build().RunAsync();
/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "API_Project_BenjaminGamrekeli");

app.Run();*/