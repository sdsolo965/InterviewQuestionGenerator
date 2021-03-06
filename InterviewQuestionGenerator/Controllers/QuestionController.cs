﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewQuestionGenerator.Models;
using InterviewQuestionGenerator.ViewModel;

namespace InterviewQuestionGenerator.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static Random _random;

        public QuestionController()
        {
            _context = new ApplicationDbContext();
            _random = new Random();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Question
        public ActionResult Random()
        {
            var studentIds = _context.Students.Select(s => s.Id).ToList();
            int listMax = studentIds.Count();
            
            return View();
        }

        public ActionResult Details(int id)
        {
            var questions = _context.Questions.SingleOrDefault(q => q.Id == id);
            if (questions == null)
                return HttpNotFound();
            return View(questions);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new CategoriesForSingleQuestionViewModel()
            {
                Categories = categories,
                Question = new InterviewQuestion()

            };
            return View("QuestionForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(InterviewQuestion question)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CategoriesForSingleQuestionViewModel
                {
                    Categories = _context.Categories.ToList(),
                    Question = question
                };
                return View("QuestionForm", viewModel);
            }
            if (question.Id == 0)
                _context.Questions.Add(question);
            else
            {
                var questionInDb = _context.Questions.Single(q => q.Id == question.Id);
                questionInDb.Question = question.Question;
                questionInDb.QuestionCategoryId = question.QuestionCategoryId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Question");
        }

        public ActionResult Edit(int id)
        {
            var question = _context.Questions.SingleOrDefault(q => q.Id == id);
            if (question == null)
                return HttpNotFound();

            var viewModel = new CategoriesForSingleQuestionViewModel
            {
                Categories = _context.Categories.ToList(),
                Question = question
            };

            return View("QuestionForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}