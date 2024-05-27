namespace workspace.Models;
using workspace.Models;

public class Turma
{
    // props que todo modelo tem
    public int Id { get; set; }
    public DateTime CreationTimestamp { get; set; }
    public DateTime? DeletionTimestamp { get; set; }

    // props deste modelo
    public required string Nome { get; set; }

    // relacoes deste modelo
    public ICollection<Aluno>? Alunos { get; }
    
}
