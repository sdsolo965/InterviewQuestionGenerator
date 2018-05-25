using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.Dtos
{
    public class QuestionDto
    {
        public string Question { get; set; }

        public int Id { get; set; }

        public QuestionCategoryDto QuestionCategory { get; set; }

        public byte QuestionCategoryId { get; set; }

        public bool IsSelected { get; set; }
    }
}