using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewQuestionGenerator.Models;

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
            int randomId = randomNum.Next(1, _context.Students.Count()+1);

            var student = _context.Students.SingleOrDefault(s => s.Id == randomId);

            return View(student);
        }

        public ViewResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public ActionResult Details(int id)
        {
            var students = _context.Students.SingleOrDefault(q => q.Id == id);
            if (students == null)
                return HttpNotFound();
            return View(students);
        }

        public ActionResult New()
        {
            var student = new Student();
            return View("StudentForm", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
                return View("StudentForm", student);

            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.Name = student.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();

            return View("StudentForm", student);

        }
    }
}