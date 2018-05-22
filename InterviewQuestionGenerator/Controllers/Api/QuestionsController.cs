using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using InterviewQuestionGenerator.Dtos;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.Controllers.Api
{
    public class QuestionsController : ApiController
    {

        private ApplicationDbContext _context;

        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/question
        [HttpGet]
        public IHttpActionResult GetQuestion()
        {
            var questionDtos = _context.Questions
                .Include(q => q.QuestionCategory)
                .ToList()
                .Select(Mapper.Map<InterviewQuestion, QuestionDto>);
            return Ok(questionDtos);
        }

        //GET /api/question/1
        [HttpGet]
        public IHttpActionResult GetQuestion(int id)
        {
            var question = _context.Questions.SingleOrDefault(s => s.Id == id);

            if (question == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<InterviewQuestion, QuestionDto>(question));
        }

        //POST /api/question
        [HttpPost]
        public IHttpActionResult CreateQuestion(InterviewQuestion question)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Questions.Add(question);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + question.Id), question);
        }

        //PUT /api/question/1
        [HttpPut]
        public void UpdateQuestion(int id, InterviewQuestion question)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var questionInDb = _context.Questions.SingleOrDefault(q => q.Id == id);
            if (questionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            questionInDb.Question = question.Question;
            questionInDb.QuestionCategoryId = question.QuestionCategoryId;

            _context.SaveChanges();

        }

        //DELETE /api/question/1
        [HttpDelete]
        public void DeleteQuestion(int id)
        {
            var question = _context.Questions.SingleOrDefault(q => q.Id == id);

            if (question == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Questions.Remove(question);
            _context.SaveChanges();
        }
    }
}
