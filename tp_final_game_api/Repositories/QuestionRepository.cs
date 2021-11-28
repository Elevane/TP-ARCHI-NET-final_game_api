using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using tp_final_game_api.Persistence;
using tp_final_game_api.Persistence.Models;
using tp_final_game_api.Repositories.Interfaces;

namespace tp_final_game_api.Repositories
{
    public class QuestionRepository : IQuestionRepository 
    {
        private readonly GameContext _context;
        public QuestionRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<Question> Create(Question objet)
        {
           
            
            _context.Set<Question>().Add(objet);
            await _context.SaveChangesAsync();
            return objet;
            
           
        }

        public async virtual Task<Question> Delete(int id)
        {
            Question toDelete = await _context.Questions.FindAsync(id);

            _context.Reponses.RemoveRange(
                _context.Reponses.Where(reponse => reponse.QuestionId == id)
            );

            _context.Questions.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<Question> Get(int id)
        {
            return await _context.Set<Question>().Include(question => question.Reponses).Where(question => question.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Question>> GetAll()
        {
            return  await _context.Set<Question>().Include(question => question.Reponses).ToListAsync();
        }

        public async Task<Question> Update(Question objet, int id)
        {
            Question toUpdate = await _context.Set<Question>().Include(question => question.Reponses).Where(question => question.Id == id).FirstOrDefaultAsync();
            toUpdate.Text = objet.Text;
            toUpdate.CategorieId = objet.CategorieId;
            toUpdate.Reponses = objet.Reponses;
            _context.Entry(toUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return objet;
        }
    }
}
