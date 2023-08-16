using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ITsena_back.Models;

public class Cart
{
    public int CartId { get; set; }
    public int Quantity { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User User { get; set;}
    public Guid ProductId { get; set; }
    [JsonIgnore]
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set;}
}
