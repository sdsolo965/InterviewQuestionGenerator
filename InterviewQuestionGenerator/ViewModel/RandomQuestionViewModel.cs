using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.ViewModel
{
    public class RandomQuestionViewModel
    {
        public Student Student { get; set; }
        public InterviewQuestion Question { get; set; }
    }
}