﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;
using Models.Models;
using Models.ViewModels;

namespace p2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly Databasecontext _context;

        public ProjectsController(Databasecontext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }
        [HttpGet("Contractor/{id}")]
        public async Task<ActionResult<Project>> GetProjectByContractor(string id)
        {
            List<Project> projects = new List<Project>();
            var query = await _context.ProjectPositions.Where(p => (p.ContractorId == id)).ToListAsync();
            foreach (var stuff in query)
            {
                var project = await _context.Projects.FirstOrDefaultAsync(a => (a.ProjectId == stuff.ProjectId));
                projects.Add(project);
            }





            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<Project>> GetProjectByUser(string id)
        {

            var project = await _context.Projects.Where(p => (p.UserId == id)).ToListAsync();
            


            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpGet("Latest/{id}")]
        public async Task<ActionResult<Project>> GetLatestProjectByUser(string id)
        {

            var projects = await _context.Projects.Where(p => (p.UserId == id)).ToListAsync();
            Project project = projects.Last();



            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }




        
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }



        
        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
