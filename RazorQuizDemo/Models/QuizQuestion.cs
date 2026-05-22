using System.Collections.Generic;

namespace RazorQuizDemo.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public List<string> Options { get; set; }
        public string SelectedOption { get; set; }
    }
}
