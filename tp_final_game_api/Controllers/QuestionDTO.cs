using AutoMapper;
using tp_final_game_api.Persistence.Models;
using tp_final_game_api.Utils.Mapper;

namespace tp_final_game_api.Controllers
{
    public class QuestionDTO : IMapFrom<Question>
    {
        public string Text { get; set; }
        public int CategorieId { get; set; }
       
        public List<ReponseDTO> Reponses { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionDTO>()
                .ReverseMap();
        }
    }
}