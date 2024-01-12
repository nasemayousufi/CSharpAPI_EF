using FinalProject1.Filters;
using FinalProject1.Filters.ActionFilter;
using FinalProject1.Filters.ExeptionFilter;
using FinalProject1.Models;
using FinalProject1.Models.Repository;
using Microsoft.AspNetCore.Mvc;




namespace FinalProject1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DressesController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult GetDresses()
        {
           
            return Ok(DressRepository.Getdresses());
        }
        [HttpGet("{id}")]
        [Dress_ValidateDressIdFilter]
        public IActionResult GetDressById(int id)
        {
            return Ok(DressRepository.GetDressById(id));
        }
        [HttpPost]
        [Dress_ValidateCreateDressFilter]
        public IActionResult CreateDress([FromForm] Dress dress)
        {
            //if (dress == null) return BadRequest();
            //var existingDress = DressRepository.GetDressByProperties(dress.Brand, dress.Gender, dress.Color, dress.Size);
            //if (existingDress == null) return BadRequest();
            DressRepository.AddDress(dress);

            return CreatedAtAction(nameof(GetDressById),
                new { id =dress.Id },
                dress);
        }
        [HttpPut("{id}")]
        [Dress_ValidateDressIdFilter]
        [Dress_ValidateUpdateDressFilter]
        [Dress_HandleUpdateExeptionsFilter]
        public IActionResult UpdateDress(int id , Dress dress) 
        {
            DressRepository.UpdateDress(dress);

            return NoContent();
        }
        [HttpDelete("{id}")]
        [Dress_ValidateDressIdFilter]
        public IActionResult DeleteDress(int id)

        {
            var dress = DressRepository.GetDressById(id);
            DressRepository.DeleteDress(id);
            return Ok(dress);
        }


    }
}