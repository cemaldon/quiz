using System.Collections.Generic;
using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorQuizDemo.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }

        [NotMapped]
        public List<string> Options
        {
            get => string.IsNullOrEmpty(OptionsJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(OptionsJson)!;
            set => OptionsJson = JsonSerializer.Serialize(value);
        }

        public string OptionsJson { get; set; }

        public string SelectedOption { get; set; }
    }
}
