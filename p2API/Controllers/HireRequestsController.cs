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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HireRequest>>> GetHireRequests()
        {
            return await _context.HireRequests.ToListAsync();
        }

     
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

     

        public async Task<ActionResult<HireRequest>> PostHireRequest(HireRequest hireRequest)
        {
            _context.HireRequests.Add(hireRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHireRequest", new { id = hireRequest.HireRequestId }, hireRequest);
        }

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
