using MinimalApi.ApplicationServices.Dtos;

namespace MinimalApi.ApplicationServices.Contracts
{
    public interface ITokenServices
    {
        public Task<string> GenerateTokenAsync(LoginUsuarioDto loginUsuarioDto);
    }
}
