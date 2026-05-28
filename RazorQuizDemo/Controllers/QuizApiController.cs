using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorQuizDemo.Data;
using RazorQuizDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorQuizDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizApiController : ControllerBase
    {
        private readonly QuizDbContext _db;
        public QuizApiController(QuizDbContext db) => _db = db;

        [HttpGet]
        public async Task<IEnumerable<QuizQuestion>> Get()
        {
            if (await _db.Questions.AnyAsync())
                return await _db.Questions.ToListAsync();

            // Fallback sample
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = 1,
                    Title = "Q1 — Rapid app deployment",
                    Prompt = "Your startup needs to deploy a web app quickly with minimal ops overhead and automatic scaling.",
                    Options = new List<string>{ "IaaS","PaaS","SaaS","FaaS" }
                }
            };
        }

        [HttpPost("submit")]
        public IActionResult Submit([FromBody] List<QuizQuestion> answers)
        {
            return Ok(new { Received = answers?.Count ?? 0 });
        }
    }
}
