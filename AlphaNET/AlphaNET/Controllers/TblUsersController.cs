using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlphaNET.Models;

namespace AlphaNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblUsersController : ControllerBase
    {
        private readonly AlphaNetContext _context;

        public TblUsersController(AlphaNetContext context)
        {
            _context = context;
        }

        // GET: api/TblUsers
        [HttpGet]
        public IEnumerable<TblUsers> GetTblUsers()
        {
            return _context.TblUsers;
        }

        // GET: api/TblUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblUsers([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblUsers = await _context.TblUsers.FindAsync(id);

            if (tblUsers == null)
            {
                return NotFound();
            }

            return Ok(tblUsers);
        }

        // PUT: api/TblUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUsers([FromRoute] long id, [FromBody] TblUsers tblUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsersExists(id))
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

        // POST: api/TblUsers
        [HttpPost]
        public async Task<IActionResult> PostTblUsers([FromBody] TblUsers tblUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblUsers.Add(tblUsers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblUsersExists(tblUsers.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblUsers", new { id = tblUsers.Id }, tblUsers);
        }

        // DELETE: api/TblUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUsers([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblUsers = await _context.TblUsers.FindAsync(id);
            if (tblUsers == null)
            {
                return NotFound();
            }

            _context.TblUsers.Remove(tblUsers);
            await _context.SaveChangesAsync();

            return Ok(tblUsers);
        }

        private bool TblUsersExists(long id)
        {
            return _context.TblUsers.Any(e => e.Id == id);
        }
    }
}