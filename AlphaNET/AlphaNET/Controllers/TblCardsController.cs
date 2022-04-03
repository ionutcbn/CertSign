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
    public class TblCardsController : ControllerBase
    {
        private readonly AlphaNetContext _context;

        public TblCardsController(AlphaNetContext context)
        {
            _context = context;
        }

        // GET: api/TblCards
        [HttpGet]
        public IEnumerable<TblCards> GetTblCards()
        {
            return _context.TblCards;
        }

        // GET: api/TblCards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblCards([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblCards = await _context.TblCards.FindAsync(id);

            if (tblCards == null)
            {
                return NotFound();
            }

            return Ok(tblCards);
        }

        // PUT: api/TblCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCards([FromRoute] long id, [FromBody] TblCards tblCards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCards.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCardsExists(id))
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

        // POST: api/TblCards
        [HttpPost]
        public async Task<IActionResult> PostTblCards([FromBody] TblCards tblCards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblCards.Add(tblCards);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCardsExists(tblCards.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCards", new { id = tblCards.Id }, tblCards);
        }

        // DELETE: api/TblCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCards([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblCards = await _context.TblCards.FindAsync(id);
            if (tblCards == null)
            {
                return NotFound();
            }

            _context.TblCards.Remove(tblCards);
            await _context.SaveChangesAsync();

            return Ok(tblCards);
        }

        private bool TblCardsExists(long id)
        {
            return _context.TblCards.Any(e => e.Id == id);
        }
    }
}