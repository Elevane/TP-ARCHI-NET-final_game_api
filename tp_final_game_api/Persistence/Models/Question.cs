using System.Collections.Generic;

namespace tp_final_game_api.Persistence.Models
{
    public class Question 
    {
        public int Id { get;  } 
        public string Text { get; set; }
        public Categorie Categorie { get; set; }
        public int CategorieId { get; set; }
        public List<Reponse> Reponses { get; set; }

    }
}
