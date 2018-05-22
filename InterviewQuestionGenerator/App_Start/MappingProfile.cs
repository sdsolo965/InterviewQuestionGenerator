using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InterviewQuestionGenerator.Dtos;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Student, StudentDto>();
            Mapper.CreateMap<StudentDto, Student>();
            Mapper.CreateMap<QuestionDto, InterviewQuestion>();
            Mapper.CreateMap<InterviewQuestion, QuestionDto>();
            Mapper.CreateMap<QuestionCategory, QuestionCategoryDto>();
        }
    }
}