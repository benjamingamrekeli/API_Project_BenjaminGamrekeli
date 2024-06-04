
using API_Project_BenjaminGamrekeli.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Project_BenjaminGamrekeli.Controllers
{
    [Route("[action]")]
    public class DierController : Controller
    {
        private IDierData dierData;

        public DierController(IDierData dierData)
        {
            this.dierData = dierData;
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
        /*[HttpGet("{id}")]
        public IActionResult CreateDier(int id)
        {
            return Ok(_laptopData.Get(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody] LaptopCreateViewModel laptopCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newLaptop = new Laptop
            {
                Name = laptopCreateViewModel.Name,
                FabricationYear = laptopCreateViewModel.FabricationYear,
                LaptopBrand = laptopCreateViewModel.LaptopBrand,
                Price = laptopCreateViewModel.Price,
                IsSold = false
            };

            _laptopData.Add(newLaptop);
            return CreatedAtAction(nameof(Details), new { newLaptop.Id }, newLaptop);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LaptopUpdateViewModel laptopUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laptop = _laptopData.Get(id);
            if (laptop == null)
            {
                return NotFound();
            }
            var updatedLaptop = new Laptop
            {
                Id = laptop.Id,
                Name = laptopUpdateViewModel.Name,
                Price = laptopUpdateViewModel.Price,
                IsSold = laptopUpdateViewModel.IsSold

            };

            _laptopData.Update(updatedLaptop);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var laptop = _laptopData.Get(id);
            if (laptop == null)
            {
                return NotFound();
            }

            _laptopData.Delete(laptop);
            return NoContent();
        }*/
    }
}
