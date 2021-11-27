using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using tp_final_game_api.Persistence;
using tp_final_game_api.Repositories.Interfaces;

namespace tp_final_game_api.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IModel
    {
        private readonly GameContext _context;
        public BaseRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T objet)
        {
            _context.Set<T>().Add(objet);
            await _context.SaveChangesAsync();
            return objet;
        }

        public async virtual Task<T> Delete(int id)
        {
            T toDelete = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T objet, int id)
        {
            T toUpdate = await _context.Set<T>().FindAsync(id);
            _context.Entry(toUpdate).CurrentValues.SetValues(objet);
            await _context.SaveChangesAsync();
            return objet;
        }
    }
}
