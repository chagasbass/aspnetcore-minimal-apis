using MinimalApi.ApplicationServices.Dtos;

namespace MinimalApi.ApplicationServices.Contracts
{
    public interface IAlunoApplicationServices
    {
        Task<IEnumerable<ListarAlunoDto>> ListarAlunosAsync();
        Task<ListarAlunoDto> ListarAlunosAsync(Guid id);
        Task<Guid> SalvarAlunosAsync(InserirAlunoDto inserirAlunoDto);
        Task<Guid> AtualizarAlunoAsync(AtualizarAlunoDto atualizarAlunoDto);
    }
}
