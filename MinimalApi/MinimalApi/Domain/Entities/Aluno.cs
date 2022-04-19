namespace MinimalApi.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public bool Ativo { get; private set; }

        public Aluno(string? nome, string? email)
        {
            Nome = nome;
            Email = email;
            Ativo = true;
        }

        public Aluno AlterarNome(string? nome)
        {
            Nome = nome;
            return this;
        }

        public Aluno AlterarEmail(string? email)
        {
            Email = email;
            return this;
        }

        public Aluno AlterarStatusDeAluno(bool estaAtivo)
        {
            Ativo = estaAtivo;
            return this;
        }
    }
}
