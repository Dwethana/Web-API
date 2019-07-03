using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NameListApi.Models;

namespace NameListApi.Controllers
{
    [Route("api/namelist")]
    [ApiController]
    public class NameListController : ControllerBase
    {
        private readonly NameListContext _context;

        public NameListController(NameListContext context)
        {
            _context = context;

            if (_context.NameListItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.NameListItems.Add(new NameListItem { Name = "Name", FirstName="Firstname", YearOfBirth="0000"});
                _context.SaveChanges();
            }
        }
        // GET: api/Todo
        [HttpGet]
        [Produces ("application/json")]
        public async Task<ActionResult<IEnumerable<NameListItem>>> GetNameListItems()
        {
            return await _context.NameListItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NameListItem>> GetNameListItem(long id)
        {
            var namelistItem = await _context.NameListItems.FindAsync(id);

            if (namelistItem == null)
            {
                return NotFound();
            }

            return namelistItem;
        }
        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<NameListItem>> PostNameListItem(NameListItem item)
        {
            _context.NameListItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNameListItem), new { id = item.Id }, item);
        }
        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNameListItem(long id, NameListItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNameListItem(long id)
        {
            var namelistItem = await _context.NameListItems.FindAsync(id);

            if (namelistItem == null)
            {
                return NotFound();
            }

            _context.NameListItems.Remove(namelistItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}