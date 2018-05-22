using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.ViewModel
{
    public class CohortsForSingleStudentViewModel
    {
        public IEnumerable<CohortType> CohortTypes { get; set; }
        public Student Student { get; set; }
    }
}