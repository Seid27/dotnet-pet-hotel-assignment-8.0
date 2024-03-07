using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pet_hotel.Models;

// Put enums here so class can access them later
public enum PetBreed
{
    Shepard,
    Poodle,
    Beagle,
    Bulldog,
    Terrier,
    Boxer,
    Labrador,
    Retriever
}



public enum PetColor
{
    White,
    Black,
    Golden,
    Tricolor,
    Spotted
}
public class Pet
{
    public int id { get; set; }
    
    [Required]
    public string name {get; set;}

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColor color { get; set; }

    [Required]
    public DateTime checkedInAt {get; set;}

    [Required]
    public int petOwnerId {get; set;}

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreed breed { get; set; }

    public PetOwners OwnedBy { get; set; }

}
