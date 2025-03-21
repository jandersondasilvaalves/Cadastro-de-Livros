using EsseDefatoVerdadeiroCrudDapper.Model;
using EsseDefatoVerdadeiroCrudDapper.Services.LivrosServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsseDefatoVerdadeiroCrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {

        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAllLivros()
        {
            IEnumerable<Livro> livros = await _livroInterface.GetAllLivros();

            if (!livros.Any())
            {
                return NotFound("Nenhum regitro no banco");
            }

            return Ok(livros);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivroById(int livroid)
        {
            Livro livro = await _livroInterface.GetLivroById(livroid);
            if (livro == null)
            {
                return NotFound("Registro não encontrado!");
            }
            return Ok(livro);  

        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Livro>>> CreateLivro(Livro livro)
        {
            IEnumerable<Livro> livros = await _livroInterface.CreateLivro(livro);

            return Ok(livros);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Livro>>> UodateLivro(Livro livro)
        {
            Livro registro = await _livroInterface.GetLivroById(livro.id);

            if(registro == null)
            {
                return NotFound("Não encontrado!");
            }
            IEnumerable<Livro> livros = await _livroInterface.UodateLivro(livro);
            return Ok(livros);
        }
        [HttpDelete("{livroid}")]
        public async Task<ActionResult<IEnumerable<Livro>>> DeleteLivro(int livroid)
        {
            Livro registro = await _livroInterface.GetLivroById(livroid);
            if(registro == null)
            {
                return NotFound("Não encontrado!");

            }
            IEnumerable<Livro> livro = await _livroInterface.DeleteLivro(livroid);
            return Ok(livro);
        }

    }
}
