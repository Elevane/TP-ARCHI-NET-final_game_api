using AutoMapper;
using tp_final_game_api.Persistence.Models;
using tp_final_game_api.Utils.Mapper;

namespace tp_final_game_api.Controllers
{
    public class CategorieDTO : IMapFrom<Categorie>
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Categorie, CategorieDTO>()
                .ReverseMap();
        }
    }

}