using AutoMapper;
using tp_final_game_api.Persistence.Models;
using tp_final_game_api.Utils.Mapper;

namespace tp_final_game_api.Controllers
{
    public class ReponseDTO : IMapFrom<Reponse>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reponse, ReponseDTO>()
                .ReverseMap();
        }
    }

}