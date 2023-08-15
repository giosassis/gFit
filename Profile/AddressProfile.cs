using AutoMapper;
using gFit.Models;
using static gFit.Context.DTOs.AddressDto;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressReadDTO>();
        CreateMap<AddressReadDTO, Address>();
        CreateMap<AddressCreateDTO, Address>();
        CreateMap<AddressUpdateDTO, Address>();
    }
}
