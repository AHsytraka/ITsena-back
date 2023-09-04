using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ITsena_back.Models;

[Keyless]
public class Cart
{
    [Column(TypeName ="char")]
    public Guid UserId { get; set; }

    [Column(TypeName ="char")]
    public Guid ProductId { get; set; }

    [Column(TypeName ="int")]
    public int Number { get; set; }
}
