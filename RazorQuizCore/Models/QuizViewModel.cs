using System.Collections.Generic;

namespace RazorQuizCore.Models
{
    public class QuizViewModel
    {
        public List<QuizQuestion> Questions { get; set; } = new();
        public bool Submitted { get; set; }
    }
}
