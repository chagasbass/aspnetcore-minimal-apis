﻿using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Dtos;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Repositories;

namespace MinimalApi.ApplicationServices.Services
{
    public class AlunoApplicationServices : IAlunoApplicationServices
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoApplicationServices(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Guid> AtualizarAlunoAsync(AtualizarAlunoDto atualizarAlunoDto)
        {
            var alunoExistente = await _alunoRepository.ListarAlunosAsync(atualizarAlunoDto.Id);

            if (alunoExistente == null)
                return Guid.Empty;

            alunoExistente.AlterarNome(atualizarAlunoDto.Nome)
                          .AlterarDocumento(atualizarAlunoDto.Documento)
                          .AlterarStatusDeAluno(atualizarAlunoDto.Ativo);

            await _alunoRepository.AtualizarAlunoAsync(alunoExistente);

            return alunoExistente.Id;
        }

        public async Task<IEnumerable<ListarAlunoDto>> ListarAlunosAsync()
        {
            var alunos = await _alunoRepository.ListarAlunosAsync();

            var alunosDto = new List<ListarAlunoDto>();

            if (alunos is not null)
            {
                foreach (var aluno in alunos)
                {
                    alunosDto.Add(new ListarAlunoDto
                    {
                        Id = aluno.Id,
                        Nome = aluno.Nome,
                        Documento = aluno.Documento
                    });
                }
            }

            return alunosDto;
        }

        public async Task<ListarAlunoDto> ListarAlunosAsync(Guid id)
        {
            var aluno = await _alunoRepository.ListarAlunosAsync(id);

            if (aluno is not null)
            {
                return new ListarAlunoDto
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Documento = aluno.Documento
                };
            }

            return default;
        }

        public async Task<Guid> SalvarAlunosAsync(InserirAlunoDto inserirAlunoDto)
        {
            var novoAluno = new Aluno(inserirAlunoDto.Nome, inserirAlunoDto.Documento);


            await _alunoRepository.SalvarAlunosAsync(novoAluno);

            return novoAluno.Id;
        }
    }
}