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
    public class HireRequestsController : ControllerBase
    {
        private readonly Databasecontext _context;

        public HireRequestsController(Databasecontext context)
        {
            _context = context;
        }

        // GET: api/HireRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HireRequest>>> GetHireRequests()
        {
            return await _context.HireRequests.ToListAsync();
        }

        // GET: api/HireRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HireRequest>> GetHireRequest(int id)
        {
            var hireRequest = await _context.HireRequests.FindAsync(id);

            if (hireRequest == null)
            {
                return NotFound();
            }

            return hireRequest;
        }



        [HttpGet("userId/{id}")]
        public async Task<ActionResult<HireRequest>> GetClientRequest(string id)
        {
            var hireRequest = await _context.HireRequests.Where(p => (p.ClientId == id)).ToListAsync();

            if (hireRequest == null)
            {
                return NotFound();
            }

            return Ok(hireRequest);
        }



        [HttpGet("Contractor/{id}")]
        public async Task<ActionResult<HireRequest>> GetContractorRequest(string id)
        {
            var hireRequest = await _context.HireRequests.Where(p => (p.ContractorId == id)).ToListAsync();

            if (hireRequest == null)
            {
                return NotFound();
            }

            return Ok(hireRequest);
        }
        // PUT: api/HireRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHireRequest(int id, HireRequest hireRequest)
        {
            if (id != hireRequest.HireRequestId)
            {
                return BadRequest();
            }

            _context.Entry(hireRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HireRequestExists(id))
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

        // POST: api/HireRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HireRequest>> PostHireRequest(HireRequest hireRequest)
        {
            _context.HireRequests.Add(hireRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHireRequest", new { id = hireRequest.HireRequestId }, hireRequest);
        }

        // DELETE: api/HireRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HireRequest>> DeleteHireRequest(int id)
        {
            var hireRequest = await _context.HireRequests.FindAsync(id);
            if (hireRequest == null)
            {
                return NotFound();
            }

            _context.HireRequests.Remove(hireRequest);
            await _context.SaveChangesAsync();

            return hireRequest;
        }

        private bool HireRequestExists(int id)
        {
            return _context.HireRequests.Any(e => e.HireRequestId == id);
        }
    }
}
