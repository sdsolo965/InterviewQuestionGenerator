using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewQuestionGenerator.Models;
using InterviewQuestionGenerator.ViewModel;

namespace InterviewQuestionGenerator.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Student
        public ActionResult Random()
        {
            Random randomNum = new Random();
            var students = _context.Students.Select(s => s.IsSelectedForQuestions == true).ToList();
            int randomId = randomNum.Next(1, students.Count()+1);





            return View();

        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageStudents))
                return View("List");
            return View("NonDeleteEditList");
        }

        public ActionResult Details(int id)
        {
            var students = _context.Students.SingleOrDefault(q => q.Id == id);
            if (students == null)
                return HttpNotFound();
            return View(students);
        }

        [Authorize(Roles = RoleName.CanManageStudents)]
        public ActionResult New()
        {
            var cohorts = _context.Cohorts.ToList();
            var viewModel = new CohortsForSingleStudentViewModel
            {
                CohortTypes = cohorts,
                Student = new Student()
            };
            return View("StudentForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var cohorts = _context.Cohorts.ToList();
                var viewModel = new CohortsForSingleStudentViewModel
                {
                    CohortTypes = cohorts,
                    Student = student
                };
                return View("StudentForm", viewModel);

            }

            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.Name = student.Name;
                studentInDb.CohortTypeId = student.CohortTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public ActionResult Edit(int id)
        {
            var cohorts = _context.Cohorts.ToList();
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            var viewModel = new CohortsForSingleStudentViewModel
            {
                CohortTypes = cohorts,
                Student = student
            };

            return View("StudentForm", viewModel);

        }
    }
}