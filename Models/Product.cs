using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ITsena_back.Models;

public class Product
{
    [Column(TypeName ="char")]
    public Guid ProductId { get; set;}

    [Required]
    [Column(TypeName ="varchar")]
    [MinLength(2)][MaxLength(150)]
    public string ProductName { get; set;}
    
    [Required]
    [Column(TypeName ="double")]
    public double Price { get; set;}

    [Column(TypeName ="longtext")]
    public string State { get; set;}

    [Column(TypeName ="int")]
    public int Quantity { get; set;}
    
    [Required]
    [Column(TypeName ="char")]
    public Guid UserId {get; set;}

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User User { get; set;}
}
