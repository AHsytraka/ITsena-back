using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ITsena_back.Models;

public class Cart
{
    [Column(TypeName ="int")]
    public int CartId { get; set; }

    [Column(TypeName ="int")]
    public int Number { get; set; }

    [Column(TypeName ="char")]
    public Guid UserId { get; set; }

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User User { get; set;}

    [Column(TypeName ="char")]
    public Guid ProductId { get; set; }

    [JsonIgnore]
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set;}
}
