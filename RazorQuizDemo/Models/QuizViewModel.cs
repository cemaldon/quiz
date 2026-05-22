using System.Collections.Generic;

namespace RazorQuizDemo.Models
{
    public class QuizViewModel
    {
        public List<QuizQuestion> Questions { get; set; }
        public bool Submitted { get; set; }
    }
}
