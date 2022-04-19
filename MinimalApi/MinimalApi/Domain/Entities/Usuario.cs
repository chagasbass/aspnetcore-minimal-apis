namespace MinimalApi.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string? Login { get; private set; }
        public string? Senha { get; private set; }
        public string? Permissao { get; private set; }

        public Usuario(string? login, string? senha, string? permissao)
        {
            Login = login;
            Senha = senha;
            Permissao = permissao;
        }

        public Usuario AlterarLogin(string? login)
        {
            Login = login;
            return this;
        }

        public Usuario AlterarSenha(string? senha)
        {
            Senha = senha;
            return this;
        }

        public Usuario AlterarPermissao(string? permissao)
        {
            Permissao = permissao;
            return this;
        }

    }
}
