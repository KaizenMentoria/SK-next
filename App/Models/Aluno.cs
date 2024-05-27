using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class Aluno
{
    public int AlunoId { get; set; }

    [Required(ErrorMessage = "Primeiro nome é obrigatório")]
    [Display(Name = "Primeiro Nome")]
    public string PrimeiroNome { get; set; }
    
    [Display(Name = "Segundo Nome")]
    public string? SegundoNome { get; set; }

    [Required(ErrorMessage = "Sobrenome é obrigatório.")]
    [Display(Name = "Sobrenome")]
    public string Sobrenome { get; set; }

    [RegularExpression("[0-9]{2}-[0-9]{5}-[0-9]{4}", ErrorMessage = "Número de contato tem de estar no formato (00) 00000-0000")]
    [Required(ErrorMessage = "Número de telefone é obrigatório.")]
    [Display(Name = "Número de Telefone")]
    public string NumeroTelefone { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email é obrigatório")]
    
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.DateTime)]
    public DateTime Nascimento { get; set; }
}