using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly TravelDeskDbContext _context;

        public DocumentsController(TravelDeskDbContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
          if (_context.Documents == null)
          {
              return NotFound();
          }
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
          if (_context.Documents == null)
          {
              return NotFound();
          }
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, Document document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        //[HttpPost]
        //public async Task<ActionResult<Document>> PostDocument(Document document)
        //{
        //  if (_context.Documents == null)
        //  {
        //      return Problem("Entity set 'TravelDeskDbContext.Documents'  is null.");
        //  }
        //    _context.Documents.Add(document);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        //}

        public class A
        {
            int id;
            string name;
        }
        [HttpPost("upload")]
        public IActionResult Upload([FromForm] Document document)
        {
             string sFolderPath;

            sFolderPath = "C:/Documents";
            var pathToSave = sFolderPath + "\\user";
            if (Request.Form.Files.Count > 0)
            {  foreach (var temp in Request.Form.Files)
                {
                    var file = temp;
                    Directory.CreateDirectory(sFolderPath + "\\user");
                    //foreach (var file in certificates)
                    //{
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // }    
                    }
                }
                _context.Requests.Add(Request);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        //public IActionResult Post(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment)
        //{
        //    if (file != null && file.Length > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(hostingEnvironment.WebRootPath, "Documents", fileName);
        //        using (var fileStream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //        }

        //        return Ok("success" + "/Documents/" + file.FileName);
        //    }

        //    return BadRequest("No file was uploaded.");
        //}


        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            if (_context.Documents == null)
            {
                return NotFound();
            }
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentExists(int id)
        {
            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
