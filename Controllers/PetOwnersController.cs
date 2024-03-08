using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace Pet_Hotel.Controllers;

[ApiController]
[Route("api/[controller]")]

public class petownersController : ControllerBase
{
    private readonly ApplicationContext _c;
    public petownersController(ApplicationContext context)
    {
        _c = context;
    }

    [HttpGet] // GET ALL
    public IActionResult GetPetOwners()
    {
        List<PetOwner> PetOwners = _c.PetOwner.Include(PetOwner=> PetOwner.Pets).ToList();

        return Ok(PetOwners);
    }


    [HttpGet("{PetOwnerId}")] // GET ONE BY ID
    public IActionResult GetPetOwnerById(int PetOwnerId)
    {
        PetOwner PetOwners = _c.PetOwner.Find(PetOwnerId);

        if (PetOwners is null)
        {
            return NotFound();
        }

        return Ok(PetOwners);
    }

    [HttpPost] // POST new Pet Owner
    
    public IActionResult AddNewPetOwner(PetOwner PetOwner)
    {
        _c.PetOwner.Add(PetOwner);
        _c.SaveChanges();

        return CreatedAtAction(nameof(GetPetOwnerById), new { Id = PetOwner.Id}, PetOwner);
    }

    

    [HttpPut("{PetOwnerId}")] // UPDATE A PETOWNER BY ID
    public IActionResult UpdatePetOwner(int PetOwnerId, PetOwner PetOwners)
    {
        if (PetOwnerId != PetOwners.Id)
        {
            return BadRequest();
        }

        bool ExistingPetOwner = _c.PetOwner.Any(p => p.Id == PetOwnerId);

        if (!ExistingPetOwner) {
            return NotFound();
        }

        _c.PetOwner.Update(PetOwners);
        _c.SaveChanges();

        PetOwner UpdatedPetOwner = _c.PetOwner.Find(PetOwnerId);

        return Ok(UpdatedPetOwner);
    }

    [HttpDelete("{PetOwnerId}")] // DELETE A PETOWNER BY ID

    public IActionResult DeletePetOwner(int PetOwnerId)
    {
        PetOwner PetOwner = _c.PetOwner.Find(PetOwnerId);
        if (PetOwnerId != PetOwner.Id)
        {
            return BadRequest();
        }

        _c.PetOwner.Remove(PetOwner);
        _c.SaveChanges();
        
        return NoContent();
    }


}