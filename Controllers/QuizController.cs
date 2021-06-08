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
    [ApiController]
    [Route("[Controller]")]
    public class QuizController:ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private ApplicationDbContext _dbContext;
        public QuizController(ILogger<QuizController> logger , ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        [HttpPost("addQuestion")]
        public IEnumerable<QuestionModel> AddQuestion(QuestionDto questionDto){
            QuestionModel qm = new QuestionModel(){
                Question = questionDto.question,
                Option1 = questionDto.option1,
                Option2 = questionDto.option2,
                Option3 = questionDto.option3,
                Option4 = questionDto.option4,
                Answer = questionDto.answer,
                Explanation = questionDto.explanation
            };
            this._dbContext.Questions.Add(qm);
            this._dbContext.SaveChanges();
            IEnumerable<QuestionModel> questions = this._dbContext.Questions.ToList();
            return questions;
          }
          [HttpGet]
           public IEnumerable<QuestionModel> Get(){
                
                IEnumerable<QuestionModel> questions = this._dbContext.Questions.ToList();
                return questions;
           }
           [HttpGet("{id}")]
           public QuestionModel Get(int id){
               QuestionModel qu = this._dbContext.Questions.Find(id);
               return qu;
           }
    }
}