namespace MinimalApi.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Documento { get; private set; }
        public bool Ativo { get; private set; }

        public Aluno(string? nome, string? documento)
        {
            Nome = nome;
            Documento = documento;
        }

        public Aluno AlterarNome(string? nome)
        {
            Nome = nome;
            return this;
        }

        public Aluno AlterarDocumento(string? documento)
        {
            Documento = documento;
            return this;
        }

        public Aluno AlterarStatusDeAluno(bool estaAtivo)
        {
            Ativo = estaAtivo;
            return this;
        }
    }
}
