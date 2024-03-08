using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pet_hotel.Models;

// Put enums here so class can access them later
public enum PetBreedType
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



public enum PetColorType
{
    White,
    Black,
    Golden,
    Tricolor,
    Spotted
}
public class Pet
{
    public int Id { get; set; }
    
    [Required]
    public string Name {get; set;}

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreedType PetBreed { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColorType PetColor { get; set; }

    [Required]
    public DateTime? CheckedInAt {get; set;}

     public PetOwner PetOwner { get; set; }
     
    [Required]
    public int PetOwnerId {get; set;}


   

}
