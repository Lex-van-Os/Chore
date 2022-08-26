using ChoreApp.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChoreApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shared.Task>>> GetTasks()
        {
            var tasks = await _context.Task.ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shared.Task>> GetTask(int id)
        {
            var task = await _context.Task.FirstOrDefaultAsync(t => t.Id == id);

            if(task == null)
                return NotFound("Task with given id couldn't be found");

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Shared.Task>> CreateTask(Shared.Task task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Shared.Task>> UpdateTask(Shared.Task task, int id)
        {
            var dbTask = await _context.Task.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return NotFound("Task with given id couldn't be found");

            dbTask.Name = task.Name;
            dbTask.Description = task.Description;
            dbTask.DueDate = task.DueDate;
            dbTask.Done = task.Done;

            await _context.SaveChangesAsync();

            return Ok(dbTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Shared.Task>> DeleteTask(int id)
        {
            var task = _context.Task.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound("Task with given id couldn't be found");

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }
    }
}
