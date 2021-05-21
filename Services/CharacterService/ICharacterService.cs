using Microsoft.AspNetCore.Mvc;
using rpgTest_2.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using rpgTest_2.Dtos.Character;

namespace rpgTest_2.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<GetCharacterDto>> GetAllCharacters();
        Task<GetCharacterDto> GetCharacterById(int id);
        Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter);
        // AddCharacterDto because we want to limit the set of data that could be sent to the server (without Id)
        // GetCharacterDto because we want to show the set of data that could be sent to the client (with Id)
        Task<List<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<List<GetCharacterDto>> DeleteCharacter(int id);

    }
}