namespace ProjetoControleTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool Concluida => DataConclusao.HasValue;

        public string Status => Concluida ? "Feita" : "Por Fazer";
    }

}
