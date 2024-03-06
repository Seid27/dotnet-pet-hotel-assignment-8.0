using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetOwners.Models;

public class PetOwners
{
    public int id { get; set; }

    [Required]
    public string name { get; set; }
    r   
    [EmailAddressAttribute]
 public string EmailAdd { get; set; }
}