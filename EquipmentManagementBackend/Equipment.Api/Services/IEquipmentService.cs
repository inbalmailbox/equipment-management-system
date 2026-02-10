using Equipment.Api.DTOs;

namespace Equipment.Api.Services;

public interface IEquipmentService
{
    IEnumerable<EquipmentDto> GetAll();
    EquipmentDto Create(CreateEquipmentDto dto);

    EquipmentDto? Update(int id, CreateEquipmentDto dto);
    bool Delete(int id);

}
