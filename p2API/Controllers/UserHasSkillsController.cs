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
    public class UserHasSkillsController : ControllerBase
    {
        private readonly Databasecontext _context;

        public UserHasSkillsController(Databasecontext context)
        {
            _context = context;
        }

        // GET: api/UserHasSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHasSkill>>> GetUserHasSkills()
        {
            return await _context.UserHasSkills.ToListAsync();
        }

        // GET: api/UserHasSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHasSkill>> GetUserHasSkill(int id)
        {
            var userHasSkill = await _context.UserHasSkills.FindAsync(id);

            if (userHasSkill == null)
            {
                return NotFound();
            }

            return userHasSkill;
        }

        // PUT: api/UserHasSkills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHasSkill(int id, UserHasSkill userHasSkill)
        {
            if (id != userHasSkill.UserHasSkillId)
            {
                return BadRequest();
            }

            _context.Entry(userHasSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHasSkillExists(id))
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

        // POST: api/UserHasSkills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserHasSkill>> PostUserHasSkill(UserHasSkill userHasSkill)
        {
            _context.UserHasSkills.Add(userHasSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserHasSkill", new { id = userHasSkill.UserHasSkillId }, userHasSkill);
        }

        // DELETE: api/UserHasSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserHasSkill>> DeleteUserHasSkill(int id)
        {
            var userHasSkill = await _context.UserHasSkills.FindAsync(id);
            if (userHasSkill == null)
            {
                return NotFound();
            }

            _context.UserHasSkills.Remove(userHasSkill);
            await _context.SaveChangesAsync();

            return userHasSkill;
        }

        private bool UserHasSkillExists(int id)
        {
            return _context.UserHasSkills.Any(e => e.UserHasSkillId == id);
        }
    }
}
