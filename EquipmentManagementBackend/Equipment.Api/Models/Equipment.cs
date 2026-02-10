
namespace Equipment.Api.Models;

public enum EquipmentStatus
{
    Available,
    InUse,
    Maintenance,
    Retired
}

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public EquipmentStatus Status { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
