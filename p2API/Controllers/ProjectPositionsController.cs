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
    public class ProjectPositionsController : ControllerBase
    {
        private readonly Databasecontext _context;

        public ProjectPositionsController(Databasecontext context)
        {
            _context = context;
        }

        // GET: api/ProjectPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectPositions>>> GetProjectPositions()
        {
            return await _context.ProjectPositions.ToListAsync();
        }

        // GET: api/ProjectPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectPositions>> GetProjectPositions(int id)
        {
            var projectPositions = await _context.ProjectPositions.FindAsync(id);

            if (projectPositions == null)
            {
                return NotFound();
            }

            return projectPositions;
        }

        [HttpGet("Projects/{id}")]
        public async Task<ActionResult<ProjectPositions>> GetPositionsByProjectId(int id)
        {
            var projectPositions = await _context.ProjectPositions.Where(b => (b.ProjectId == id)).ToListAsync();

            if (projectPositions == null)
            {
                return NotFound();
            }

            return Ok(projectPositions);
        }






         //PUT: api/ProjectPositions/5
      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectPositions(int id, ProjectPositions projectPositions)
        {
            if (id != projectPositions.ProjectPositionsId)
            {
                return BadRequest();
           }

           _context.Entry(projectPositions).State = EntityState.Modified;
    try
           {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectPositionsExists(id))
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

        // POST: api/ProjectPositions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectPositions>> PostProjectPositions(ProjectPositions projectPositions)
        {
            _context.ProjectPositions.Add(projectPositions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectPositions", new { id = projectPositions.ProjectPositionsId }, projectPositions);
        }

        // DELETE: api/ProjectPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectPositions>> DeleteProjectPositions(int id)
        {
            var projectPositions = await _context.ProjectPositions.FindAsync(id);
            if (projectPositions == null)
            {
                return NotFound();
            }

            _context.ProjectPositions.Remove(projectPositions);
            await _context.SaveChangesAsync();

            return projectPositions;
        }

        private bool ProjectPositionsExists(int id)
        {
            return _context.ProjectPositions.Any(e => e.ProjectPositionsId == id);
        }
    }
}
