using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        private DbSet<Aluno> _dataset;
        public AlunoRepository(SmartContext context) : base(context)
        {
            _dataset = context.Set<Aluno>();
        }

        public async Task<Aluno?> SelectAsync(string nome)
        {
            try
            {
                var aluno = await _dataset
                    .AsNoTracking()
                    .Where(a => a.Nome.Contains(nome))
                    .FirstOrDefaultAsync();
                if (aluno == null) return null;
                return aluno;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Aluno?> SelectCompleteAsync(int id)
        {
            try
            {
                var aluno = await _dataset
                        .Include(a => a.AlunosDisciplina)
                        .ThenInclude(ad => ad.Disciplina)
                        .ThenInclude(d => d.Professor)
                        .AsNoTracking()
                        .Where(a => a.Id.Equals(id))
                        .FirstOrDefaultAsync();
                if (aluno == null) return null;
                return aluno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Aluno?> SelectCompleteAsync(string nome)
        {
            try
            {
                var aluno = await _dataset
                        .Include(a => a.AlunosDisciplina)
                        .ThenInclude(ad => ad.Disciplina)
                        .ThenInclude(d => d.Professor)
                        .AsNoTracking()
                        .Where(a => a.Nome.Contains(nome))
                        .FirstOrDefaultAsync();
                if (aluno == null) return null;
                return aluno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAllAlunosByDisciplinaId(int disciplinaId)
        {
            try
            {
                var alunos = await _dataset
                        .Include(a => a.AlunosDisciplina)
                        .ThenInclude(ad => ad.Disciplina)
                        .ThenInclude(d => d.Professor)
                        .AsNoTracking()
                        .Where(a => a.AlunosDisciplina.Any(ad => ad.DisciplinaId.Equals(disciplinaId)))
                        .ToListAsync();
                if (alunos.IsNullOrEmpty()) return new List<Aluno> { };
                return alunos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
