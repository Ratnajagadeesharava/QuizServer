using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizCreatorServer.DataBase;
using QuizCreatorServer.Models;
using QuizCreatorServer.DTOS;
namespace QuizCreatorServer.Controllers
{
    public class SubjectController:BaseApiController
    {
        private readonly ILogger<SubjectController> _logger;
        private ApplicationDbContext _dbContext;
        public SubjectController(ILogger<SubjectController> logger , ApplicationDbContext dbContext)
        {
                _dbContext = dbContext;
                _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Subject> GetSubjects(){
                IEnumerable<Subject> subjects = _dbContext.Subjects.ToList();
                return subjects;
        }
        [HttpPost("register")]
        public ActionResult<Subject> Register(SubjectDto subjectDto){
                Subject subject =new Subject(){
                        Title = subjectDto.title
                };
                _dbContext.Subjects.Add(subject);
                _dbContext.SaveChanges();
                return subject;

        }
    }
}