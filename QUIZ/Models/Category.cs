using System;
using System.Collections.Generic;

#nullable disable

namespace QUIZ.Models
{
    public partial class Category
    {
        public Category()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
