﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHelper.Models;

namespace ProjectHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMembersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectMember>>> GetProjectMember()
        {
            return await _context.ProjectMember.ToListAsync();
        }

        // GET: api/ProjectMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectMember>> GetProjectMember(int id)
        {
            var projectMember = await _context.ProjectMember.FindAsync(id);

            if (projectMember == null)
            {
                return NotFound();
            }

            return projectMember;
        }

        // PUT: api/ProjectMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectMember(int id, ProjectMember projectMember)
        {
            if (id != projectMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectMemberExists(id))
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

        // POST: api/ProjectMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectMember>> PostProjectMember(ProjectMember projectMember)
        {
            _context.ProjectMember.Add(projectMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectMember", new { id = projectMember.Id }, projectMember);
        }

        // DELETE: api/ProjectMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectMember(int id)
        {
            var projectMember = await _context.ProjectMember.FindAsync(id);
            if (projectMember == null)
            {
                return NotFound();
            }

            _context.ProjectMember.Remove(projectMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectMemberExists(int id)
        {
            return _context.ProjectMember.Any(e => e.Id == id);
        }
    }
}
