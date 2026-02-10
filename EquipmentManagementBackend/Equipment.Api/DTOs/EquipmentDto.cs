
using Equipment.Api.Models;

namespace Equipment.Api.DTOs;

public class EquipmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string SerialNumber { get; set; } = "";
    public DateTime PurchaseDate { get; set; }
    public EquipmentStatus Status { get; set; }
    public string Category { get; set; } = "";
    public string Location { get; set; } = "";
}

