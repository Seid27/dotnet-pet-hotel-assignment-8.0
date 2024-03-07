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

    public IActionResult getPets()
    {
        List<Pet> pets = context.Pet.Include(pet => pet.petOwnerId).ToList();

        return Ok(pets);
    }

    [HttpGet("{petId}")] // GET A PET BY ID

    public IActionResult GetPetById(int petId)
    {
        Pet Pet = context.Pet.Include(p => p.petOwnerId).FirstOrDefault(p => p.id == petId);

        if (Pet is null)
        {
            return NotFound();
        }
        return Ok(Pet);
    }

    [HttpPost] // POST A PET
    public IActionResult AddPet(Pet pet)
    {
        context.Pet.Add(pet);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetPetById), new { Id = pet.id }, pet);
    }

    [HttpPut("{petId}")] // EDIT A PET BY ID
    public IActionResult update(int petId, Pet pet)
    {
        if (petId != pet.id)
        {
            return BadRequest();
        }
        bool ExistingPet = context.Pet.Any(p => p.id == petId);
        if (ExistingPet is false)
        {
            return NotFound();
        }

        context.Pet.Update(pet);
        context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{petId}")] // DELETE PET BY ID
    public IActionResult DeletePet(int petId)
    {
        Pet Pet = context.Pet.Find(petId);

        if (Pet is null)
        {
            return NotFound();
        }
        context.Pet.Remove(Pet);
        context.SaveChanges();

        return NoContent();
    }


    [HttpPut("{petId}/checkin")] // CHECK A PET IN BY ID

    public IActionResult CheckInPet(int petId)
    {
        Pet pet = context.Pet.Find(petId);

        if (pet == null)
        {
            return NotFound();
        }
        
        pet.chekedInAt = DateTime.Now;

        context.Pet.Update(pet);
        context.SaveChanges();

        return Ok();
    }


    [HttpPut("{petId}/checkout")] // CHECK A PET OUT BY ID

    public IActionResult CheckOutPet(int petId){
        Pet pet = context.Pet.Find(petId);
        
        if (pet == null)
        {
            return NotFound();
        }

        pet.chekedInAt = DateTime.MinValue;

        context.Pet.Update(pet);
        context.SaveChanges();

        return Ok();
    }


}