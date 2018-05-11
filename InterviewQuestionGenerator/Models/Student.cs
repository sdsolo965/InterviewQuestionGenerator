using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewQuestionGenerator.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter the Students name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public int Id { get; set; }
    }
}