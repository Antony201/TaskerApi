using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskerApi.Models;

namespace TaskerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskItemContext _context;

        public TaskItemsController(TaskItemContext context)
        {
            _context = context;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
          if (_context.TaskItems == null)
          {
              return NotFound();
          }
            return await _context.TaskItems.ToListAsync();
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
        {
          if (_context.TaskItems == null)
          {
              return NotFound();
          }
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // PUT: api/TaskItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(long id, TaskItem taskItem)
        {
            if (id != taskItem.id)
            {
                return BadRequest();
            }

            _context.Entry(taskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(id))
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

        // POST: api/TaskItems
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
          if (_context.TaskItems == null)
          {
              return Problem("Entity set 'TaskItemContext.TaskItems'  is null.");
          }
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.id }, taskItem);

        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(long id)
        {
            if (_context.TaskItems == null)
            {
                return NotFound();
            }
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskItemExists(long id)
        {
            return (_context.TaskItems?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
