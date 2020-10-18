using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;
using Models.Models;

namespace p2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionNeedsSkillsController : ControllerBase
    {
        private readonly Databasecontext _context;

        public PositionNeedsSkillsController(Databasecontext context)
        {
            _context = context;
        }

        // GET: api/PositionNeedsSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionNeedsSkill>>> GetPositionNeedsSkills()
        {
            return await _context.PositionNeedsSkills.ToListAsync();
        }

        // GET: api/PositionNeedsSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionNeedsSkill>> GetPositionNeedsSkill(int id)
        {
            var positionNeedsSkill = await _context.PositionNeedsSkills.FindAsync(id);

            if (positionNeedsSkill == null)
            {
                return NotFound();
            }

            return positionNeedsSkill;
        }

        // PUT: api/PositionNeedsSkills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositionNeedsSkill(int id, PositionNeedsSkill positionNeedsSkill)
        {
            if (id != positionNeedsSkill.PositionNeedsSkillId)
            {
                return BadRequest();
            }

            _context.Entry(positionNeedsSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionNeedsSkillExists(id))
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

        // POST: api/PositionNeedsSkills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PositionNeedsSkill>> PostPositionNeedsSkill(PositionNeedsSkill positionNeedsSkill)
        {
            _context.PositionNeedsSkills.Add(positionNeedsSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPositionNeedsSkill", new { id = positionNeedsSkill.PositionNeedsSkillId }, positionNeedsSkill);
        }

        // DELETE: api/PositionNeedsSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PositionNeedsSkill>> DeletePositionNeedsSkill(int id)
        {
            var positionNeedsSkill = await _context.PositionNeedsSkills.FindAsync(id);
            if (positionNeedsSkill == null)
            {
                return NotFound();
            }

            _context.PositionNeedsSkills.Remove(positionNeedsSkill);
            await _context.SaveChangesAsync();

            return positionNeedsSkill;
        }

        private bool PositionNeedsSkillExists(int id)
        {
            return _context.PositionNeedsSkills.Any(e => e.PositionNeedsSkillId == id);
        }
    }
}
