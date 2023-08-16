using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ITsena_back.Models;
public class User
{
    [Key]
    [JsonIgnore]
    [Column(TypeName ="char")]
    public Guid UserId {get; set;}

    [Required]
    [MinLength(2)][MaxLength(150)]
    [Column(TypeName ="varchar")]
    public string Username {get; set;}

    [Required]
    [EmailAddress]
    [Column(TypeName ="longtext")]
    public string Email {get; set;}
    
    [Required]
    [MinLength(8)]
    [Column(TypeName ="longtext")]
    public string Password {get; set;}
}