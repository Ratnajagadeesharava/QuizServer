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
    public class BaseApiController:ControllerBase
    {
        
    }
}