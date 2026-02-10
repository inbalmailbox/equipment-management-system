using EquipmentModel = Equipment.Api.Models.Equipment;
using Equipment.Api.DTOs;
using Equipment.Api.Models;

namespace Equipment.Api.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<EquipmentModel> _items = new();
    private int _nextId = 1;

    public EquipmentService()
    {
        _items.Add(new EquipmentModel
        {
            Id = _nextId++,
            Name = "Laptop Dell",
            SerialNumber = "SN-1001",
            PurchaseDate = DateTime.UtcNow.AddYears(-2),
            Status = EquipmentStatus.InUse,
            Category = "IT",
            Location = "HQ"
        });
    }

    public IEnumerable<EquipmentDto> GetAll()
    {
        return _items.Select(e => new EquipmentDto
        {
            Id = e.Id,
            Name = e.Name,
            SerialNumber = e.SerialNumber,
            PurchaseDate = e.PurchaseDate,
            Status = e.Status,
            Category = e.Category,
            Location = e.Location
        });
    }

    public EquipmentDto Create(CreateEquipmentDto dto)
    {
        var entity = new EquipmentModel
        {
            Id = _nextId++,
            Name = dto.Name,
            SerialNumber = dto.SerialNumber,
            PurchaseDate = dto.PurchaseDate,
            Status = dto.Status,
            Category = dto.Category,
            Location = dto.Location
        };

        _items.Add(entity);

        return new EquipmentDto
        {
            Id = entity.Id,
            Name = entity.Name,
            SerialNumber = entity.SerialNumber,
            PurchaseDate = entity.PurchaseDate,
            Status = entity.Status,
            Category = entity.Category,
            Location = entity.Location
        };
    }

    public EquipmentDto? Update(int id, CreateEquipmentDto dto)
    {
        var entity = _items.FirstOrDefault(e => e.Id == id);
        if (entity == null)
            return null;

        entity.Name = dto.Name;
        entity.SerialNumber = dto.SerialNumber;
        entity.PurchaseDate = dto.PurchaseDate;
        entity.Status = dto.Status;
        entity.Category = dto.Category;
        entity.Location = dto.Location;

        return new EquipmentDto
        {
            Id = entity.Id,
            Name = entity.Name,
            SerialNumber = entity.SerialNumber,
            PurchaseDate = entity.PurchaseDate,
            Status = entity.Status,
            Category = entity.Category,
            Location = entity.Location
        };
    }

    public bool Delete(int id)
    {
        var entity = _items.FirstOrDefault(e => e.Id == id);
        if (entity == null)
            return false;

        _items.Remove(entity);
        return true;
    }

}
