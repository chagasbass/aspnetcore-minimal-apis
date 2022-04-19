using Microsoft.IdentityModel.Tokens;
using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Dtos;
using MinimalApi.Domain.Repositories;
using MinimalApi.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MinimalApi.ApplicationServices.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public TokenServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> GenerateTokenAsync(LoginUsuarioDto loginUsuarioDto)
        {
            var usuario = await _usuarioRepository.ListarUsuarioAsync(loginUsuarioDto.Login, loginUsuarioDto.Senha);

            if (usuario is null)
                return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Settings.GetSecretArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.Role, usuario.Permissao)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
