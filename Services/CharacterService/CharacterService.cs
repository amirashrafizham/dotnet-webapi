using Microsoft.AspNetCore.Mvc;
using rpgTest_2.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using rpgTest_2.Dtos.Character;
using AutoMapper;
using rpgTest_2.Data;
using Microsoft.EntityFrameworkCore;

namespace rpgTest_2.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character() {Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter); // this is to map AddCharacterDto to Character first
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            return _mapper.Map<List<GetCharacterDto>>(dbCharacters);
        }

        public async Task<List<GetCharacterDto>> GetAllCharacters()
        {
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            return _mapper.Map<List<GetCharacterDto>>(dbCharacters);
        }

        public async Task<GetCharacterDto> GetCharacterById(int id)
        {
            Character dbCharacter = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<GetCharacterDto>(dbCharacter);
        }
        public async Task<List<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            Character tobeUpdated = await _context.Characters.FirstOrDefaultAsync(x => x.Id == updatedCharacter.Id);
            tobeUpdated.Name = updatedCharacter.Name;
            tobeUpdated.Strength = updatedCharacter.Strength;
            tobeUpdated.Intelligence = updatedCharacter.Intelligence;
            tobeUpdated.Defense = updatedCharacter.Defense;
            tobeUpdated.HitPoints = updatedCharacter.HitPoints;
            tobeUpdated.Class = updatedCharacter.Class;

            _context.Characters.Update(tobeUpdated);
            await _context.SaveChangesAsync();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            return _mapper.Map<List<GetCharacterDto>>(dbCharacters);
        }

        public async Task<List<GetCharacterDto>> DeleteCharacter(int id)
        {
            Character deletedChar = await _context.Characters.FirstAsync(x => x.Id == id);
            _context.Remove(deletedChar);
            await _context.SaveChangesAsync();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            return _mapper.Map<List<GetCharacterDto>>(dbCharacters);
        }
    }
}