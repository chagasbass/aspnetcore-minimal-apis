using System.ComponentModel.DataAnnotations;

namespace MinimalApi.ApplicationServices.Dtos
{
    public class AtualizarAlunoDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(2), MaxLength(200)]
        public string? Nome { get; set; }
        [Required, MaxLength(30), EmailAddress]
        public string? Email { get; set; }
        [Required]
        public bool Ativo { get; set; }

        public AtualizarAlunoDto() { }

    }
}
