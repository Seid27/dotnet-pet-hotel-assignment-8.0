using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pet_hotel.Models;

public class PetOwners
{
    public int id { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    [EmailAddress]
    public string emailAddress { get; set; }

    [JsonIgnore]
    public ICollection<Pet> Pets { get; set; }

    [NotMapped]
    public int petCount
    {
        get
        {
            return (this.Pets != null) ? this.Pets.Count : 0;
        }
    }
}