using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.DataContext;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Repositories;

namespace MinimalApi.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly MinimalApiDataContext _context;

        public AlunoRepository(MinimalApiDataContext context)
        {
            _context = context;
        }

        public async Task<Aluno> AtualizarAlunoAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();

            return aluno;

        }

        public async Task<Guid> ExcluirAlunoAsync(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno.Id;
        }

        public async Task<IEnumerable<Aluno>> ListarAlunosAsync()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public async Task<Aluno> ListarAlunosAsync(Guid id)
        {
            return await _context.Alunos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Aluno> SalvarAlunosAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();

            return aluno;

        }
    }
}
