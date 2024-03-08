using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pet_hotel.Models;

public class PetOwner
{
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Name { get; set; }


    [JsonIgnore]
    public ICollection<Pet> Pets { get; set; }

    [NotMapped]
    public int PetCount
    {
        get
        {
            return this.Pets != null ? this.Pets.Count : 0;
        }
    }
}