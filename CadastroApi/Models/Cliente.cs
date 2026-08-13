using System.ComponentModel.DataAnnotations;

namespace CadastroApi.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage = "Nome deve conter somente letras.")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(14)]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF deve estar no formato 000.000.000-00.")]
    public string Cpf { get; set; } = string.Empty;

    [Required]
    [MaxLength(11)]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter 10 ou 11 números.")]
    public string Telefone { get; set; } = string.Empty;

    public DateOnly DataNascimento { get; set; }

    [Required]
    [MaxLength(100)]
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage = "Cidade deve conter somente letras.")]
    public string Cidade { get; set; } = string.Empty;
}
