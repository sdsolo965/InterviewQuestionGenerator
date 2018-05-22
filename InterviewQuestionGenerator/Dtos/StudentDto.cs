using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public CohortType CohortType { get; set; }

        public byte CohortTypeId { get; set; }
    }
}