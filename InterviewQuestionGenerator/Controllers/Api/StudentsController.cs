using System;
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
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/student
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            return Ok(_context.Students.ToList().Select(Mapper.Map<Student, StudentDto>));
        }

        //GET /api/student/1
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(Mapper.Map<Student, StudentDto>(student));
        }

        //POST /api/studentDto
        [HttpPost]
        public IHttpActionResult CreateStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentDto, Student>(studentDto);
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;

            return Created(new Uri(Request.RequestUri + "/" + student.Id), studentDto);
        }

        //Put /api/studentDto/1
        [HttpPut]
        public void UpdateStudent(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(studentDto, studentInDb);

            _context.SaveChanges();
        }

        //DELETE /api/student/1
        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
        }

    }
}
