namespace SmartSchool.WebAPI.Models
{
    public class Professor : BaseModel
    {
        public string Nome { get; set; }
        public string? Sobrenome { get; set; }
        public int Registro { get; set; }
        public string? Telefone { get; set; } = null;
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
        public Professor()
        {
            
        }
        public Professor(int id, int registro, string nome, string? sobronome) : base(id)
        {
            Id = id;
            Registro = registro;
            Nome = nome;
            Sobrenome = sobronome;
        }
        public Professor(int id, string nome, string? sobrenome, int registro, string telefone) : base(id)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Registro = registro;
            Telefone = telefone;
        }
        public Professor(int id, string nome, string? sobrenome, int registro, string telefone,
                        DateTime dataMatricula, bool ativo) : base(id)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Registro = registro;
            Telefone = telefone;
            DataMatricula = dataMatricula;
            Ativo = ativo;
        }
    }
}
