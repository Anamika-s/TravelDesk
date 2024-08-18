using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonTypeRefsController : ControllerBase
    {
        private readonly TravelDeskDbContext _context;

        public CommonTypeRefsController(TravelDeskDbContext context)
        {
            _context = context;
        }

        // GET: api/CommonTypeRefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonTypeRef>>> GetCommonTypes()
        {
          if (_context.CommonTypes == null)
          {
              return NotFound();
          }
            return await _context.CommonTypes.ToListAsync();
        }

        // GET: api/CommonTypeRefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonTypeRef>> GetCommonTypeRef(int id)
        {
          if (_context.CommonTypes == null)
          {
              return NotFound();
          }
            var commonTypeRef = await _context.CommonTypes.FindAsync(id);

            if (commonTypeRef == null)
            {
                return NotFound();
            }

            return commonTypeRef;
        }

        // PUT: api/CommonTypeRefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCommonTypeRef(int id, CommonTypeRef commonTypeRef)
        //{
        //    if (id != commonTypeRef.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(commonTypeRef).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CommonTypeRefExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/CommonTypeRefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CommonTypeRef>> PostCommonTypeRef(CommonTypeRef commonTypeRef)
        //{
        //  if (_context.CommonTypes == null)
        //  {
        //      return Problem("Entity set 'TravelDeskDbContext.CommonTypes'  is null.");
        //  }
        //    _context.CommonTypes.Add(commonTypeRef);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCommonTypeRef", new { id = commonTypeRef.Id }, commonTypeRef);
        //}

        // DELETE: api/CommonTypeRefs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCommonTypeRef(int id)
        //{
        //    if (_context.CommonTypes == null)
        //    {
        //        return NotFound();
        //    }
        //    var commonTypeRef = await _context.CommonTypes.FindAsync(id);
        //    if (commonTypeRef == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CommonTypes.Remove(commonTypeRef);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CommonTypeRefExists(int id)
        {
            return (_context.CommonTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
