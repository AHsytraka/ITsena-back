using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ITsena_back.Models;

namespace ITsena_back;

public class Product
{
    public Guid ProductId { get; set;}

    [Required]
    [MinLength(2)][MaxLength(150)]
    public string ProductName { get; set;}
    [Required]
    public double Price { get; set;}
    public string State { get; set;}
    public int Quantity { get; set;}
    [Required]
    public Guid UserId {get; set;}
    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User User { get; set;}
}
