using EsseDefatoVerdadeiroCrudDapper.Model;

namespace EsseDefatoVerdadeiroCrudDapper.Services.LivrosServices
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int livroid);
        Task<IEnumerable<Livro>> CreateLivro(Livro livro);
        Task<IEnumerable<Livro>> UodateLivro(Livro livro);
        Task<IEnumerable<Livro>> DeleteLivro(int livroid);
    }
}
