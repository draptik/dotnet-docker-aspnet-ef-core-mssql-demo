using System;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApplication.Models;
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

        [HttpPost]
        public async Task<IActionResult> Seed()
        {
            _logger.LogInformation("Calling NotesController.Seed...");
            
            var notes = await _db.Notes.ToListAsync();
            var alreadySeeded = notes
                .Select(x => x.Summary)
                .Any(x => x.StartsWith("foobar"));

            if (alreadySeeded)
            {
                _logger.LogInformation("already seeded...");
                return Ok("already seeded.");
            }

            var seeds = Enumerable
                .Range(1, 10)
                .Select(x => new Note {Summary = $"foobar{x.ToString()}"});

            await using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                _db.Notes.AddRange(seeds);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok("seed data created.");
            }
            catch (Exception e)
            {
                _logger.LogError($"problem during seeding: {e.Message}");
                return new JsonResult(e.Message);
            }
        }
    }
}