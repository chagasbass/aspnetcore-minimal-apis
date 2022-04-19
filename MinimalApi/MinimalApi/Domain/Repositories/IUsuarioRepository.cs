using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> SalvarUsuarioAsync(Usuario usuario);
        Task<Usuario> ListarUsuarioAsync(string? login);
        Task<Usuario> ListarUsuarioAsync(string? login, string? senha);
    }
}
