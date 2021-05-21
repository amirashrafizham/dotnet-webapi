using Microsoft.AspNetCore.Mvc;
using rpgTest_2.Models;
using System.Linq;
using System.Collections.Generic;
using rpgTest_2.Services.CharacterService;
using System.Threading.Tasks;
using rpgTest_2.Dtos.Character;

namespace rpgTest_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {

            try
            {
                return Ok(await _characterService.UpdateCharacter(updatedCharacter));
            }
            catch (System.Exception)
            {

                return BadRequest("No id found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {

            try
            {
                return Ok(await _characterService.DeleteCharacter(id));

            }
            catch (System.Exception)
            {

                return BadRequest("No id found");
            }
        }
    }
}