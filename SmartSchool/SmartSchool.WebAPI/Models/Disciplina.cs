namespace SmartSchool.WebAPI.Models
{
    public class Disciplina : BaseModel
    {
        public string Nome { get; set; }
        public int? CargaHoraria { get; set; }
        public int ProfessorId { get; set; }
        public int CursoId { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public virtual Disciplina Prerequisito { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<AlunoDisciplina> AlunosDisciplina { get; set; }
        public Disciplina()
        {
            
        }
        public Disciplina(int id, string nome, int professorId, int cursoId) : base(id)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
            CursoId = cursoId;
        }
        public Disciplina(int id, string nome, int cargaHoraria, int professorId, int cursoId) : base (id)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            ProfessorId = professorId;
            CursoId = cursoId;
        }
        public Disciplina(int id, string nome, int cargaHoraria, int professorId, int cursoId, int prerequisitoId) : base(id)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            ProfessorId = professorId;
            CursoId = cursoId;
            PrerequisitoId = prerequisitoId;
        }
    }
}
