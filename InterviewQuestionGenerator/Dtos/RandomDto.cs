using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.Dtos
{
    public class RandomDto
    {
        public InterviewQuestion Question { get; set; }

        public Student Student { get; set; }
    }
}