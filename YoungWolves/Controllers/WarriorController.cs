using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using YoungWolves.Data;
using YoungWolves.DTO;
using YoungWolves.Models;

namespace YoungWolves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarriorController : ControllerBase
    {
        private readonly DataContext _context;

        public WarriorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WarriorDTO>>> Get()
        {
            List<Warrior> warriors = await _context.Warriors.ToListAsync();

            List<WarriorDTO> warriorDTOs = new List<WarriorDTO>();

            foreach (var item in warriors)
            {
                WarriorDTO warriorDTO = new WarriorDTO();
                warriorDTO.Name = item.Name;
                warriorDTO.Surname = item.Surname;
                warriorDTO.Number = item.Number;
                warriorDTO.Value = item.Value;

                warriorDTOs.Add(warriorDTO);
            }

            return Ok(warriorDTOs);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<WarriorDTO>> Get(int number)
        {
            var warrior = await _context.Warriors.Where(n=> n.Number == number).ToListAsync();
            if (warrior is null)
            {
                return BadRequest("Not found");
            }

            return Ok(warrior);
        }

        [HttpPost]
        public async Task<ActionResult<List<WarriorDTO>>> Add(WarriorDTO warriorDTO)
        {
            Warrior warrior = new Warrior();
            warrior.Number = warriorDTO.Number;
            warrior.Name = warriorDTO.Name;
            warrior.Surname = warriorDTO.Surname;
            warrior.Value = warriorDTO.Value;

            _context.Warriors.Add(warrior);
            await _context.SaveChangesAsync();

            return Ok(await _context.Warriors.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<WarriorDTO>>> Update(WarriorDTO newWarrior, int id)
        {

            Warrior warrior = await _context.Warriors.FindAsync(id);
            if (warrior is null)
            {
                return BadRequest("Not found");
            }

            warrior.Name = newWarrior.Name;
            warrior.Surname = newWarrior.Surname;
            warrior.Number = newWarrior.Number;
            warrior.Value = newWarrior.Value;
            
            await _context.SaveChangesAsync();

            return Ok(newWarrior); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WarriorDTO>> Delete(int id)
        {

            WarriorDTO warriorDTO = new WarriorDTO();
            Warrior warrior = await _context.Warriors.FindAsync(id);
            if (warrior is null)
            {
                return BadRequest("Not found");
            }

            warriorDTO.Name = warrior.Name;
            warriorDTO.Surname = warrior.Surname;
            warriorDTO.Number = warrior.Number;
            warriorDTO.Value = warrior.Value;
            _context.Warriors.Remove(warrior);
            await _context.SaveChangesAsync();

            return Ok(warriorDTO);
        }
    }
}