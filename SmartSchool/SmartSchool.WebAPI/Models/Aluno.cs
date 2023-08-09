namespace SmartSchool.WebAPI.Models
{
    public class Aluno : BaseModel
    {
        public string Nome { get; set; }
        public string? Sobrenome { get; set; }
        public int Matricula { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public virtual ICollection<AlunoDisciplina> AlunosDisciplina { get; set; }
        public Aluno()
        {
            
        }
        public Aluno(int id, int matricula, string nome , string? sobrenome, string telefone,
                    DateTime dataNasc) : base(id)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNasc = dataNasc;
        }
        public Aluno(int id, string nome, string? sobrenome, int matricula, string telefone,
                    DateTime dataNasc, DateTime dataMatricula, DateTime? dataConclusao, bool ativo) : base(id)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Matricula = matricula;
            Telefone = telefone;
            DataNasc = dataNasc;
            DataMatricula = dataMatricula;
            DataConclusao = dataConclusao;
            Ativo = ativo;
        }
    }
}
