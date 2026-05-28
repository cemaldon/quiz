using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RazorQuizCore.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Prompt { get; set; } = string.Empty;

        [NotMapped]
        public List<string> Options
        {
            get => string.IsNullOrEmpty(OptionsJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(OptionsJson)!;
            set => OptionsJson = JsonSerializer.Serialize(value);
        }

        public string OptionsJson { get; set; } = "[]";
        public string SelectedOption { get; set; } = string.Empty;
    }
}
