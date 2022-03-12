using System;
using System.Collections.Generic;

#nullable disable

namespace QUIZ.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
