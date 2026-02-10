using System.ComponentModel.DataAnnotations;
using Equipment.Api.Models;

namespace Equipment.Api.DTOs;

public class CreateEquipmentDto
{
    [Required, MinLength(2)]
    public string Name { get; set; } = "";

    [Required, RegularExpression(@"^[A-Za-z0-9\-]{3,50}$")]
    public string SerialNumber { get; set; } = "";

    [Required]
    public DateTime PurchaseDate { get; set; }

    [Required]
    public EquipmentStatus Status { get; set; }

    [Required, MinLength(2)]
    public string Category { get; set; } = "";

    [Required, MinLength(2)]
    public string Location { get; set; } = "";
}
