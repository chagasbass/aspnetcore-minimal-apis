using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> ListarAlunosAsync();
        Task<Aluno> ListarAlunosAsync(Guid id);
        Task<Aluno> SalvarAlunosAsync(Aluno aluno);
        Task<Aluno> AtualizarAlunoAsync(Aluno aluno);
    }
}
