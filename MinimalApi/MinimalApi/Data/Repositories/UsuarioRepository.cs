using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.DataContext;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Repositories;

namespace MinimalApi.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MinimalApiDataContext _context;

        public UsuarioRepository(MinimalApiDataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ListarUsuarioAsync(string? login)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(x => x.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Usuario> ListarUsuarioAsync(string? login, string? senha)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(x => x.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && x.Senha.Equals(senha));
        }

        public async Task<Usuario> SalvarUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;

        }
    }
}
