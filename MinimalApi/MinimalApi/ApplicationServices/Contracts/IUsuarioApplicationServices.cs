using MinimalApi.ApplicationServices.Dtos;

namespace MinimalApi.ApplicationServices.Contracts
{
    public interface IUsuarioApplicationServices
    {
        Task<Guid> SalvarUsuarioAsync(InserirUsuarioDto inserirUsuarioDto);
    }
}
