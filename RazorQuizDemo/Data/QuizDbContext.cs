using Microsoft.EntityFrameworkCore;
using RazorQuizCore.Models;

namespace RazorQuizDemo.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<QuizQuestion> Questions { get; set; }
    }
}
