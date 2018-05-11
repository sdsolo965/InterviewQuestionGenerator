using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.ViewModel
{
    public class QuestionCategoryViewModel
    {
        public IEnumerable<QuestionCategory> Categories { get; set; }
        public IEnumerable<InterviewQuestion> Questions { get; set; }
    }
}