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

        public CohortType CohortType { get; set; }

        [Required(ErrorMessage = "Please give the Student a Cohort.")]
        [Display(Name = "Cohort")]
        public byte CohortTypeId { get; set; }
    }
}