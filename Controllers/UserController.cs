using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizCreatorServer.DataBase;
using QuizCreatorServer.Models;
using QuizCreatorServer.DTOS;
using System.Security.Cryptography;
using System.Text;
using QuizCreatorServer.Interfaces;
namespace QuizCreatorServer.Controllers
{
    public class UserController:BaseApiController
    {
        private readonly ILogger<UserController> _logger;
        private ApplicationDbContext _dbContext;
        private ITokenService _tokenService;
        public UserController(ILogger<UserController> logger , ApplicationDbContext dbContext,ITokenService tokenService)
        {
            _tokenService = tokenService;
            _dbContext = dbContext;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<User> Get(){
            IEnumerable<User> users = _dbContext.Users.ToList();
            return users;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto userDto){
            using var hmac = new HMACSHA512();
            //using here uses dispose method
            var user  = new User(){
                UserName = userDto.username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.password)),
                PasswordSalt = hmac.Key,
                Email = userDto.email,
                Optional = userDto.optional
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto){
          
            var user =   _dbContext.Users.SingleOrDefault(x=>x.Email == loginDto.email);
            if(user == null)
            return Unauthorized("Invalid Email");
            using var hmac =new  HMACSHA512(user.PasswordSalt);
            byte[] loginPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));
            int l = loginPassword.Length;
            for(int i=0;i<l;i++){
                if(loginPassword[i]!=user.PasswordHash[i])
                return Unauthorized("Invalid  Password");
            }
            TokenDto tokenDto = new TokenDto(){
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
            return tokenDto;
            
        }
        
    }
}