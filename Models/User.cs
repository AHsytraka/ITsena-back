using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ITsena_back.Models;
public class User
{
    [Key]
    [JsonIgnore]
    public Guid Id {get;set;}

    [Required]
    [MinLength(2)][MaxLength(150)]
    public string Name {get; set;}

    [Required]
    [EmailAddress]
    public string Email {get; set;}
    
    [Required]
    [MinLength(8)]
    public string Password {get; set;}
}