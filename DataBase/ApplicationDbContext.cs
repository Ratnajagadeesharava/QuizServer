using Microsoft.EntityFrameworkCore;
using QuizCreatorServer.Models;
namespace QuizCreatorServer.DataBase
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<QuestionModel> Questions { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}