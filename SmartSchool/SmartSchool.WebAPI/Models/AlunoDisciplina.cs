﻿namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; } = null;
        public int? Nota { get; set; } = null;
        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public AlunoDisciplina()
        {
            
        }
        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }

    }
}
