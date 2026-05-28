using Microsoft.AspNetCore.Mvc;
using RazorQuizCore.Models;
using System.Collections.Generic;

namespace RazorQuizDemo.Controllers
{
    public class QuizController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new QuizViewModel
            {
                Questions = GetQuestions(),
                Submitted = false
            });
        }

        [HttpPost]
        public IActionResult Index(QuizViewModel model)
        {
            model.Questions = GetQuestions();
            model.Submitted = true;
            return View(model);
        }

        private static List<QuizQuestion> GetQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = 1,
                    Title = "Q1 — Rapid app deployment",
                    Prompt = "Your startup needs to deploy a web app quickly with minimal ops overhead and automatic scaling.",
                    Options = new List<string> { "IaaS", "PaaS", "SaaS", "FaaS" }
                },
                new QuizQuestion
                {
                    Id = 2,
                    Title = "Q2 — Full control & compliance",
                    Prompt = "You must run legacy software needing custom OS config, specific network setups, and full infrastructure control.",
                    Options = new List<string> { "IaaS", "PaaS", "SaaS", "FaaS" }
                },
                new QuizQuestion
                {
                    Id = 3,
                    Title = "Q3 — Off-the-shelf business app",
                    Prompt = "You want a hosted CRM with standard features, low customization, and no platform management.",
                    Options = new List<string> { "IaaS", "PaaS", "SaaS", "FaaS" }
                },
                new QuizQuestion
                {
                    Id = 4,
                    Title = "Q4 — Event-driven small workloads",
                    Prompt = "You need to process uploaded images (resize/thumbnail) only when events occur; cost should match usage.",
                    Options = new List<string> { "IaaS", "PaaS", "SaaS", "FaaS" }
                },
                new QuizQuestion
                {
                    Id = 5,
                    Title = "Q5 — Containerized microservices with orchestration",
                    Prompt = "Your team builds microservices in containers and wants managed orchestration but control over deployments.",
                    Options = new List<string> { "IaaS", "PaaS", "CaaS", "FaaS" }
                }
            };
        }
    }
}
