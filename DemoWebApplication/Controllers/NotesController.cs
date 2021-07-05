using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {

        private readonly AppDbContext _db;
        private readonly ILogger<NotesController> _logger;

        public NotesController(AppDbContext db, ILogger<NotesController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Calling NotesController.Get...");
            
            var notes = await _db.Notes.ToListAsync();
            return new JsonResult(notes);
        }
    }
}