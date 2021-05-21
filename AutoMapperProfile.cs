using rpgTest_2.Models;
using rpgTest_2.Dtos.Character;
using AutoMapper;
namespace rpgTest_2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}