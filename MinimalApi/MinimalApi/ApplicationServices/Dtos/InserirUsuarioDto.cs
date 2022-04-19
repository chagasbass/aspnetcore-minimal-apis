using System.ComponentModel.DataAnnotations;

namespace MinimalApi.ApplicationServices.Dtos
{
    public class InserirUsuarioDto
    {
        [Required, MaxLength(30)]
        public string? Login { get; set; }
        [Required, MaxLength(10)]
        public string? Senha { get; set; }
        [Required, RangeAttribute(typeof(string), "Admin", "User")]
        public string? Permissao { get; set; }

        public InserirUsuarioDto() { }

    }
}
