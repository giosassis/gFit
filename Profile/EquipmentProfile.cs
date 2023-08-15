using AutoMapper; 
using gFit.Models;
using static gFit.Context.DTOs.EquipmentDto;

public class EquipmentProfile : Profile
{
    public EquipmentProfile()
    {
        CreateMap<Equipment, EquipmentReadDTO>();
        CreateMap<EquipmentReadDTO, Equipment>();
        CreateMap<EquipmentCreateDTO, Equipment>();
        CreateMap<EquipmentUpdateDTO, Equipment>();
    }
}
