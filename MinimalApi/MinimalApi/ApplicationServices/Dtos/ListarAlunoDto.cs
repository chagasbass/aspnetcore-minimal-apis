namespace MinimalApi.ApplicationServices.Dtos
{
    public record ListarAlunoDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }

        public ListarAlunoDto() { }
    }
}
