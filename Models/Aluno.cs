namespace workspace.Models;

using workspace.Models;

public class Aluno
{
    // props universais
    public int Id { get; set; }
    public DateTime CreationTimestamp { get; set; }
    public DateTime? DeletionTimestamp { get; set; }

    // props do modelo
    public required string Nome { get; set; }

    // props de relacionamento
    public Turma? Turma { get; set; }
}
