using System.Threading.Tasks;
using tp_final_game_api.Persistence.Models;

namespace tp_final_game_api.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> Get(int id);
        Task<List<Question>> GetAll();
        Task<Question> Create(Question objet);
        Task<Question> Update(Question objet, int id);

        Task<Question> Delete(int id);

    }
}
