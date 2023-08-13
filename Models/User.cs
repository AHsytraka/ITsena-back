using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ITsena_back.Models;
public class User
{
    [Key]
    [JsonIgnore]
    public Guid UserId {get; set;}

    [Required]
    [MinLength(2)][MaxLength(150)]
    public string Username {get; set;}

    [Required]
    [EmailAddress]
    public string Email {get; set;}
    
    [Required]
    [MinLength(8)]
    public string Password {get; set;}
}