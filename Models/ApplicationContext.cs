using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Models;

public class ApplicationContext : DbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    public DbSet<PetOwners> PetOwners { get; set; }
  public DbSet<Pet> Pet { get; set; }
}