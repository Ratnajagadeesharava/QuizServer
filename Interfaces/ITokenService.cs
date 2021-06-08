using QuizCreatorServer.Models;
namespace QuizCreatorServer.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User usr);
    }
}