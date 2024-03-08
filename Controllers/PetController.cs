using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace Pet_Hotel.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PetController : ControllerBase
{
    private readonly ApplicationContext context;
    public PetController(ApplicationContext c)
    {
        context = c;
    }


    [HttpGet] // GET ALL PETS

    public IActionResult GetPets()
    {
        List<Pet> Pets = context.Pet.Include(Pet => Pet.PetOwner).ToList();

        return Ok(Pets);
    }

    [HttpGet("{PetId}")] // GET A PET BY ID

    public IActionResult GetPetById(int PetId)
    {
        Pet Pet = context.Pet.Include(p => p.PetOwnerId).FirstOrDefault(p => p.Id == PetId);

        if (Pet is null)
        {
            return NotFound();
        }
        return Ok(Pet);
    }

    [HttpPost] // POST A PET
    public IActionResult AddPet(Pet Pet)
    {

        PetOwner PetOwner = context.PetOwner.Find(Pet.PetOwnerId);
        // Console.WriteLine(PetOwner.name);

        if (PetOwner is null)
        {
            return NotFound();
        }

        context.Pet.Add(Pet);
        context.SaveChanges();
 
        return CreatedAtAction(nameof(GetPetById), new { Id = Pet.Id }, Pet);
  
    }

    [HttpPut("{PetId}")] // EDIT A PET BY ID
    public IActionResult UpdatePet(int PetId, Pet Pet)
    {
        if (PetId != Pet.Id)
        {
            return BadRequest();
        }
        bool ExistingPet = context.Pet.Any(p => p.Id == PetId);
        if (ExistingPet is false)
        {
            return NotFound();
        }

        context.Pet.Update(Pet);
        context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{PetId}")] // DELETE PET BY ID
    public IActionResult DeletePet(int PetId)
    {
        Pet Pet = context.Pet.Find(PetId);

        if (Pet is null)
        {
            return NotFound();
        }
        context.Pet.Remove(Pet);
        context.SaveChanges();

        return NoContent();
    }


    [HttpPut("{petId}/checkin")] // CHECK A PET IN BY ID

    public IActionResult CheckInPet(int PetId)
    {
        Pet Pet = context.Pet.Find(PetId);

        if (Pet == null)
        {
            return NotFound();
        }
        
        Pet.CheckedInAt = DateTime.Now;

        context.Pet.Update(Pet);
        context.SaveChanges();

        return Ok();
    }


    [HttpPut("{petId}/checkout")] // CHECK A PET OUT BY ID

    public IActionResult CheckOutPet(int PetId){
        Pet Pet = context.Pet.Find(PetId);
        
        if (Pet == null)
        {
            return NotFound();
        }

        Pet.CheckedInAt = DateTime.MinValue;

        context.Pet.Update(Pet);
        context.SaveChanges();

        return Ok();
    }


}