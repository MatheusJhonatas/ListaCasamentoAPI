using System;
using System.ComponentModel.DataAnnotations;

public class EditorPessoaViewModel
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(45, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 45 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Data de Aniversário é obrigatório.")]
    public DateTime Aniversario { get; set; }
    [Required(ErrorMessage = "Sexo é obrigatório.")]
    public string Sexo { get; set; }
    [Required(ErrorMessage = "Familia é obrigatório.")]
    public string Familia { get; set; }
    [Required(ErrorMessage = "Telefone é obrigatório.")]
    [StringLength(45, MinimumLength = 11, ErrorMessage = "Informar o telefone no seguinte formato: 11.99999-0000")]
    public string Telefone { get; set; }
    [Required(ErrorMessage = "Email é obrigatório.")]
    [StringLength(55, MinimumLength = 10, ErrorMessage = "Este campo precisa ter entre 10 e 55 caracteres!")]
    public string Email { get; set; }
    public bool Confirmacao { get; set; }
}