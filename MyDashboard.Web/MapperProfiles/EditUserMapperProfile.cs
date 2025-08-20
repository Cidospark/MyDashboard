using AutoMapper;

public class EditUserMapperProfile : Profile
{
    public EditUserMapperProfile()
    {
        CreateMap<AppUser, EditUserDto>();
        CreateMap<EditUserDto, AppUser>();
    }
}