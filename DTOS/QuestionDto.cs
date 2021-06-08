namespace QuizCreatorServer.DTOS
{
    public class QuestionDto
    {
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public int answer { get; set; }
        public string explanation { get; set; }
    }
}