namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DisciplinaId { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        public Professor() { }
        public Professor(int id, string nome, int disciplinaId)
        {
            Id = id;
            Nome = nome;
            DisciplinaId = disciplinaId;
        }
    }
}
