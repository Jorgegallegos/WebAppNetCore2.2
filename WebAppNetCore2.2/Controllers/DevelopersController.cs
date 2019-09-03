using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppNetCore2._2.Data;
using WebAppNetCore2._2.Entities;
using WebAppNetCore2._2.Models;

namespace WebAppNetCore2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly IMapper _mapper;

        public DevelopersController(MyAppContext context,IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Developers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperIndexDTO>>> GetDevelopers()
        {
            var developers = await _context.Developers.ToListAsync();
            return _mapper.Map<List<DeveloperIndexDTO>>(developers);
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperIndexDTO>> GetDeveloper(int id)
        {
            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return _mapper.Map<DeveloperIndexDTO>(developer);
        }

        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloper(int id, DeveloperAddDTO developerDTO)
        {
            if (id != developerDTO.Id)
            {
                return BadRequest();
            }

            var developer = _mapper.Map<Developer>(developerDTO);
            _context.Entry(developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Developers
        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(DeveloperAddDTO developerDTO)
        {
            var developer = _mapper.Map<Developer>(developerDTO);
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developer);
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Developer>> DeleteDeveloper(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();

            return developer;
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.Id == id);
        }
    }
}
