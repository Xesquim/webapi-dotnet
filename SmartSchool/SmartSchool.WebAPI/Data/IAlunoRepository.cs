using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno?> SelectCompleteAsync(int id);
        Task<Aluno?> SelectCompleteAsync(string nome);
        Task<Aluno?> SelectAsync(string nome);
        Task<IEnumerable<Aluno>> GetAllAlunosByDisciplinaId(int disciplinaId);
    }
}
