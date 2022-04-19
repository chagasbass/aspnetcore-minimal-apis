using System.ComponentModel.DataAnnotations;

namespace MinimalApi.ApplicationServices.Dtos
{
    public class AtualizarAlunoDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(2), MaxLength(200)]
        public string? Nome { get; set; }
        [Required, MaxLength(14)]
        public string? Documento { get; set; }
        [Required]
        public bool Ativo { get; set; }

        public AtualizarAlunoDto() { }

    }
}
