using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Dtos;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Repositories;

namespace MinimalApi.ApplicationServices.Services
{
    public class UsuarioApplicationServices : IUsuarioApplicationServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplicationServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> SalvarUsuarioAsync(InserirUsuarioDto inserirUsuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.ListarUsuarioAsync(inserirUsuarioDto.Login);

            if (usuarioExistente is not null)
                return Guid.Empty;

            var novoUsuario = new Usuario(inserirUsuarioDto.Login, inserirUsuarioDto.Senha, inserirUsuarioDto.Permissao);

            await _usuarioRepository.SalvarUsuarioAsync(novoUsuario);

            return novoUsuario.Id;
        }
    }
}
