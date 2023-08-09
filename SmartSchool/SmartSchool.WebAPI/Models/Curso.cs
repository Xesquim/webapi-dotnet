namespace SmartSchool.WebAPI.Models
{
    public class Curso : BaseModel
    {
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        public virtual ICollection<AlunoCurso> AlunosCurso{ get; set; }
        public Curso()
        {
            
        }
        public Curso(int id, string nome) : base (id)
        {
            Id = id;
            Nome = nome;
        }
    }
}
