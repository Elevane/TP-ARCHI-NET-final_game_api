using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tp_final_game_api.Persistence.Models;
using tp_final_game_api.Repositories.Interfaces;

namespace tp_final_game_api.Controllers
{

    [ApiController]
    [Route("/api/v1/[controller]")]
    public class QuestionController : Controller
    {

        private readonly IQuestionRepository _repo;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       


        [HttpGet]
        public async Task<Result<List<QuestionDTO>>> GetAll()
        {
            List<Question> questions = await _repo.GetAll();
            List<QuestionDTO> questiondto = _mapper.Map<List<QuestionDTO>>(questions);
            return  Result.Ok(questiondto);
        }


        [HttpGet("/api/v1/[controller]/{questionId}")]
        public async Task<Result<QuestionDTO>> Get(int questionId)
        {
            Question question = await _repo.Get(questionId);
            QuestionDTO questiondto = _mapper.Map<QuestionDTO>(question);
            return Result.Ok(questiondto);
        }


        [HttpPost]
        public async Task<Result<QuestionDTO>> Post([FromBody] QuestionDTO postobjet)
        {
            Question toCreate = _mapper.Map<Question>(postobjet);
            Question question = await _repo.Create(toCreate);
            QuestionDTO questiondto = _mapper.Map<QuestionDTO>(question);
            Result<QuestionDTO> res =  new Result<QuestionDTO>(questiondto);
            return res;
        }

        [HttpPut("/api/v1/[controller]/{questionId}")]
        public async Task<Result<QuestionDTO>> Put([FromBody] QuestionDTO putobjet, int questionId)
        {
            Question toUpdate = _mapper.Map<Question>(putobjet);
            Question question = await _repo.Update(toUpdate, questionId);
            QuestionDTO questiondto = _mapper.Map<QuestionDTO>(question);
            Result<QuestionDTO> res = new Result<QuestionDTO>(questiondto);
            return res;
        }


        [HttpDelete("/api/v1/[controller]/{questionId}")]
        public async Task<Result<QuestionDTO>> Delete( int questionId)
        {
            
            Question question = await _repo.Delete( questionId);
            QuestionDTO questiondto = _mapper.Map<QuestionDTO>(question);
            Result<QuestionDTO> res = new Result<QuestionDTO>(questiondto);
            return res;
        }

    }
}
