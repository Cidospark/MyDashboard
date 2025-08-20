using AutoMapper;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<AppUser, EditUserDto>();
        CreateMap<EditUserDto, AppUser>();
        CreateMap<AddUserDto, AppUser>();
        CreateMap<AppUser, AddUserDto>();
    }
}