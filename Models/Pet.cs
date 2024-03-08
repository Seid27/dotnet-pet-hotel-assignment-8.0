using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace pet_hotel.Models;
public enum PetBreedType
{
  Shepherd,
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
  public string Name { get; set; }
  [Required]
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public PetBreedType PetBreed { get; set; }
  [Required]
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public PetColorType PetColor { get; set; }
  public DateTime? CheckedInAt { get; set; }
  public PetOwner PetOwner { get; set; }
  [Required]
  public int PetOwnerId { get; set; }
}