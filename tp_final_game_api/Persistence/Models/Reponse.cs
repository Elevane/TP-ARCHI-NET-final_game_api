namespace tp_final_game_api.Persistence.Models
{
    public class Reponse
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}