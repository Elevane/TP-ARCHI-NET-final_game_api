using System.Threading.Tasks;

namespace tp_final_game_api.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IModel
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<T> Create(T objet);
        Task<T> Update(T objet, int id);

        Task<T> Delete(int id);

    }
}
