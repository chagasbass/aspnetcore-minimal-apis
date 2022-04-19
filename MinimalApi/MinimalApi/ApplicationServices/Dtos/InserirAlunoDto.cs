using System.ComponentModel.DataAnnotations;

namespace MinimalApi.ApplicationServices.Dtos
{
    public record InserirAlunoDto
    {
        [Required, MinLength(2), MaxLength(200)]
        public string? Nome { get; set; }
        [Required, MaxLength(30), EmailAddress]
        public string? Email { get; set; }

        public InserirAlunoDto() { }

    }
}
