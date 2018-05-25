using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewQuestionGenerator.Models
{
    public class InterviewQuestion
    {
        [Required(ErrorMessage = "Please enter a new Question")]
        public string Question { get; set; }
        
        public int Id { get; set; }

        public QuestionCategory QuestionCategory { get; set; }

        [Required(ErrorMessage = "Please give the Question a Category.")]
        [Display(Name = "Question Category")]
        public byte QuestionCategoryId { get; set; }

        public bool IsSelected { get; set; }
    }
}