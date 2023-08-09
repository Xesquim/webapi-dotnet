using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        private DbSet<Professor> _dataset;
        public ProfessorRepository(SmartContext context) : base(context)
        {
            _dataset = context.Set<Professor>();
        }

        public async Task<Professor?> SelectCompleteAsync(int id)
        {
            try
            {
                var professor = await _dataset
                    .Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplina)
                    .ThenInclude(ad => ad.Aluno)
                    .AsNoTracking()
                    .Where(a => a.Id.Equals(id))
                    .FirstOrDefaultAsync();
                if (professor == null) return null;
                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Professor?> SelectCompleteAsync(string nome)
        {
            try
            {
                var professor = await _dataset
                    .Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplina)
                    .ThenInclude(ad => ad.Aluno)
                    .AsNoTracking()
                    .Where(a => a.Nome.Contains(nome))
                    .FirstOrDefaultAsync();
                if (professor == null) return null;
                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Professor?> SelectAsync(string nome)
        {
            try
            {
                var professor = await _dataset
                    .AsNoTracking()
                    .Where(a => a.Nome.Contains(nome))
                    .FirstOrDefaultAsync();
                if (professor == null) return null;
                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Professor?> GetProfessorByDisciplinaId(int disciplinaId)
        {
            try
            {
                var professor = await _dataset
                    .Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplina)
                    .ThenInclude(ad => ad.Aluno)
                    .AsNoTracking()
                    .Where(a => a.Disciplinas.Any(d => d.Id == disciplinaId))
                    .FirstOrDefaultAsync();
                if (professor == null) return null;
                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
