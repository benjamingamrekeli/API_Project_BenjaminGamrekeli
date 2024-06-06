using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli.Services;
using API_Project_BenjaminGamrekeli.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Project_BenjaminGamrekeli.Controllers
{
    [Route("[controller]")]
    public class DierController : Controller
    {
        private readonly IDierData _dierData;
        private readonly IKlasseData _klasseData;

        public DierController(IDierData dierData, IKlasseData klasseData)
        {
            _dierData = dierData;
            _klasseData = klasseData;
        }

        [HttpGet("GetAllDieren")]
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
            return CreatedAtAction(nameof(GetDier), new { id = newDier.Id }, newDier);
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