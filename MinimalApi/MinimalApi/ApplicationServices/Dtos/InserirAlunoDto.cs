﻿using System.ComponentModel.DataAnnotations;

namespace MinimalApi.ApplicationServices.Dtos
{
    public record InserirAlunoDto
    {
        [Required, MinLength(2), MaxLength(200)]
        public string? Nome { get; set; }
        [Required, MaxLength(14)]
        public string? Documento { get; set; }

        public InserirAlunoDto() { }

    }
}