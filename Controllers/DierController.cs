using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli.Services;
using API_Project_BenjaminGamrekeli.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Project_BenjaminGamrekeli.Controllers
{
    [Route("[action]")]
    public class DierController : Controller
    {
        private readonly IDierData _dierData;
        private readonly IKlasseData _klasseData;
        private readonly IHabitatData _habitatData;
        private readonly IDierHabitatData _dierHabitatData;

        public DierController(IDierData dierData, IKlasseData klasseData, IHabitatData habitatData, IDierHabitatData dierHabitatData)
        {
            _dierData = dierData;
            _klasseData = klasseData;
            _habitatData = habitatData;
            _dierHabitatData = dierHabitatData;
        }

        [HttpGet]
        public IActionResult GetAllDieren()
        {
            var dieren = _dierData.GetAllDieren();
            if (dieren == null)
            {
                return NotFound();
            }
            return Ok(dieren);
        }

        [HttpGet("{id}")]
        public IActionResult GetDier(int id)
        {
            var dier = _dierData.GetDier(id);
            if (dier == null)
            {
                return NotFound();
            }
            return Ok(dier);
        }

        [HttpPost]
        public IActionResult CreateDier([FromBody] DierCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var klasse = _klasseData.GetAllKlassen().FirstOrDefault(k => k.KlasseNaam == model.KlasseNaam);
            if (klasse == null)
            {
                return BadRequest("Invalid KlasseNaam");
            }

            var newDier = new Dier
            {
                Naam = model.Naam,
                Klasse = klasse,
                Dieet = model.Dieet,
                LevensVerwachting = model.LevensVerwachting
            };

            _dierData.CreateDier(newDier);

            // Assign habitats to the new Dier
            foreach (var habitatId in model.HabitatIds)
            {
                var habitat = _habitatData.GetHabitat(habitatId);
                if (habitat == null)
                {
                    return BadRequest($"Invalid HabitatId: {habitatId}");
                }

                var dierHabitat = new DierHabitat
                {
                    DierId = newDier.Id,
                    HabitatId = habitatId
                };
                _dierHabitatData.CreateDierHabitat(dierHabitat);
            }

            return CreatedAtAction(nameof(GetDier), new { newDier.Id }, newDier);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateDier(int id, [FromBody] DierUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dier = _dierData.GetDier(id);
            if (dier == null)
            {
                return NotFound();
            }

            var klasse = _klasseData.GetAllKlassen().FirstOrDefault(k => k.KlasseNaam == model.KlasseNaam);
            if (klasse == null)
            {
                return BadRequest("Invalid KlasseNaam");
            }

            dier.Naam = model.Naam;
            dier.Klasse = klasse;
            dier.Dieet = model.Dieet;
            dier.LevensVerwachting = model.LevensVerwachting;

            _dierData.UpdateDier(dier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDier(int id)
        {
            var dier = _dierData.GetDier(id);
            if (dier == null)
            {
                return NotFound();
            }
            _dierData.DeleteDier(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllKlassen()
        {
            var klassen = _klasseData.GetAllKlassen();
            if (klassen == null)
            {
                return NotFound();
            }
            return Ok(klassen);
        }

        [HttpGet("{id}")]
        public IActionResult GetKlasse(int id)
        {
            var klasse = _klasseData.GetKlasse(id);
            if (klasse == null)
            {
                return NotFound();
            }
            return Ok(klasse);
        }

        [HttpPost]
        public IActionResult CreateKlasse([FromBody] KlasseCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newKlasse = new Klasse
            {
                KlasseNaam = model.KlasseNaam,
                Dieren = new List<Dier>()
            };

            _klasseData.CreateKlasse(newKlasse);
            return CreatedAtAction(nameof(GetKlasse), new { newKlasse.Id }, newKlasse);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateKlasse(int id, [FromBody] KlasseUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var klasse = _klasseData.GetKlasse(id);
            if (klasse == null)
            {
                return NotFound();
            }

            klasse.KlasseNaam = model.KlasseNaam;
            _klasseData.UpdateKlasse(klasse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKlasse(int id)
        {
            var klasse = _klasseData.GetKlasse(id);
            if (klasse == null)
            {
                return NotFound();
            }
            _klasseData.DeleteKlasse(id);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllHabitats()
        {
            var habitats = _habitatData.GetAllHabitats();
            if (habitats == null)
            {
                return NotFound();
            }
            return Ok(habitats);
        }

        [HttpGet("{id}")]
        public IActionResult GetHabitat(int id)
        {
            var habitat = _habitatData.GetHabitat(id);
            if (habitat == null)
            {
                return NotFound();
            }
            return Ok(habitat);
        }

        [HttpPost]
        public IActionResult CreateHabitat([FromBody] HabitatCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newHabitat = new Habitat
            {
                HabitatNaam = model.HabitatNaam
            };
            _habitatData.CreateHabitat(newHabitat);
            return CreatedAtAction(nameof(GetHabitat), new { newHabitat.Id }, newHabitat);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHabitat(int id, [FromBody] HabitatUpdateViewModel habitatUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var habitat = _habitatData.GetHabitat(id);
            if (habitat == null)
            {
                return NotFound();
            }

            habitat.HabitatNaam = habitatUpdateViewModel.HabitatNaam;
            _habitatData.UpdateHabitat(habitat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHabitat(int id)
        {
            var habitat = _habitatData.GetHabitat(id);
            if (habitat == null)
            {
                return NotFound();
            }
            _habitatData.DeleteHabitat(id);
            return NoContent();
        }
    }
}

/*
using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli.Services;
using API_Project_BenjaminGamrekeli.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Project_BenjaminGamrekeli.Controllers
{
    [Route("[action]")]
    public class DierController : Controller
    {
        private IDierData dierData;
        private IKlasseData klasseData;

        public DierController(IDierData dierData, IKlasseData klasseData)
        {
            this.dierData = dierData;
            this.klasseData = klasseData;
        }
        [HttpGet]
        public IActionResult GetAllDieren()
        {
            var dieren = dierData.GetAllDieren();
            if (dieren == null)
            {
                return NotFound();
            }
            return Ok(dieren);
        }
        [HttpGet("{id}")]
        public IActionResult GetDier(int id)
        {
            var dier = dierData.GetDier(id);
            if (dier == null)
            {
                return NotFound();
            }
            return Ok(dier);
        }
        [HttpPost]
        public IActionResult CreateDier([FromBody] DierCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newDier = new Dier
            {
                Naam = model.Naam,
                Klasse = klasseData.GetAllKlassen().FirstOrDefault(k => k.KlasseNaam == model.KlasseNaam),
                Dieet = model.Dieet,
                LevensVerwachting = model.LevensVerwachting
            };

            dierData.CreateDier(newDier);
            return CreatedAtAction(nameof(GetDier), new { newDier.Id }, newDier);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDier(int id,[FromBody] DierUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dier = dierData.GetDier(id);
            if (dier == null)
            {
                return NotFound();
            }
            var updatedDier = new Dier
            {
                Naam = model.Naam,
                Klasse = klasseData.GetAllKlassen().FirstOrDefault(k => k.KlasseNaam == model.KlasseNaam),
                Dieet = model.Dieet,
                LevensVerwachting = model.LevensVerwachting
            };
            dierData.UpdateDier(updatedDier);
            return CreatedAtAction(nameof(GetDier), new { id = updatedDier.Id }, updatedDier);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDier(int id)
        {
            var dier = dierData.GetDier(id);
            if (dier == null)
            {
                return NotFound();
            }
            dierData.DeleteDier(id);
            return NoContent();
        }
    }
}
*/