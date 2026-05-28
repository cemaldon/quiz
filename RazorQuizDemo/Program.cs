using Microsoft.EntityFrameworkCore;
using RazorQuizDemo.Data;
using RazorQuizCore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=quiz.db"));

var app = builder.Build();

// Ensure DB is created/migrated and seed initial data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<QuizDbContext>();
    db.Database.Migrate();

    if (!db.Questions.Any())
    {
        var sample = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Id = 1,
                Title = "Q1 — Rapid app deployment",
                Prompt = "Your startup needs to deploy a web app quickly with minimal ops overhead and automatic scaling.",
                Options = new List<string>{ "IaaS","PaaS","SaaS","FaaS" }
            },
            new QuizQuestion
            {
                Id = 2,
                Title = "Q2 — Full control & compliance",
                Prompt = "You must run legacy software needing custom OS config, specific network setups, and full infrastructure control.",
                Options = new List<string>{ "IaaS","PaaS","SaaS","FaaS" }
            },
            new QuizQuestion
            {
                Id = 3,
                Title = "Q3 — Off-the-shelf business app",
                Prompt = "You want a hosted CRM with standard features, low customization, and no platform management.",
                Options = new List<string>{ "IaaS","PaaS","SaaS","FaaS" }
            },
            new QuizQuestion
            {
                Id = 4,
                Title = "Q4 — Event-driven small workloads",
                Prompt = "You need to process uploaded images (resize/thumbnail) only when events occur; cost should match usage.",
                Options = new List<string>{ "IaaS","PaaS","SaaS","FaaS" }
            },
            new QuizQuestion
            {
                Id = 5,
                Title = "Q5 — Containerized microservices with orchestration",
                Prompt = "Your team builds microservices in containers and wants managed orchestration but control over deployments.",
                Options = new List<string>{ "IaaS","PaaS","CaaS","FaaS" }
            }
        };

        db.Questions.AddRange(sample);
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
