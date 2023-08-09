namespace SmartSchool.WebAPI.Models
{
    public class AlunoCurso
    {
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; } = null;
        public int? Nota { get; set; } = null;
        public virtual Aluno Aluno { get; set; }
        public virtual Curso Curso{ get; set; }
        public AlunoCurso()
        {
            
        }
        public AlunoCurso(int alunoId, int cursoId)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
        }

    }
}
