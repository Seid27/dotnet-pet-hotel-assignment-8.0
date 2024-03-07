using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace Pet_Hotel.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PetOwnersController : ControllerBase
{
    private readonly ApplicationContext _c;
    public PetOwnersController(ApplicationContext context)
    {
        _c = context;
    }

    [HttpGet] // GET ALL
    public IActionResult GetPetOwners()
    {
        List<PetOwners> petOwners = _c.PetOwners.Include(petOwner=> petOwner.Pets).ToList();

        return Ok(petOwners);
    }


    [HttpGet("{petOwnerId}")] // GET ONE BY ID
    public IActionResult GetPetOwnerById(int petOwnerId)
    {
        PetOwners PetOwners = _c.PetOwners.Find(petOwnerId);

        if (PetOwners is null)
        {
            return NotFound();
        }

        return Ok(PetOwners);
    }

    [HttpPost] // POST new Pet Owner
    
    public IActionResult AddNewPetOwner(PetOwners petOwner)
    {
        _c.PetOwners.Add(petOwner);
        _c.SaveChanges();

        return CreatedAtAction(nameof(GetPetOwnerById), new { id = petOwner.id}, petOwner);
    }

    

    // [HttpPut("{petOwnerId}")] // UPDATE A PETOWNER BY ID

    // [HttpDelete("{petOwnerId}")] // DELETE A PETOWNER BY ID


}