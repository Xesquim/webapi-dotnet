using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<Professor?> SelectCompleteAsync(int id);
        Task<Professor?> SelectCompleteAsync(string nome);
        Task<Professor?> SelectAsync(string nome);
        Task<Professor?> GetProfessorByDisciplinaId(int disciplinaId);
    }
}
