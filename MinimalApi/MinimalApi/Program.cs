//objetos para acesso a container e serviços do aspnetcore

using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Dtos;
using MinimalApi.Extensions;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .ConfigureDbContextInMemory()
                .ConfigureDependencyInjection();

//gera o build e entrega um webapplication
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


#region mapeamento de endpoints

app.MapGet("/alunos", async (
    IAlunoApplicationServices alunoApplicationServices) =>

    await alunoApplicationServices.ListarAlunosAsync()
    is IEnumerable<ListarAlunoDto> alunos
    ? Results.Ok(alunos)
    : Results.NotFound("A pesquisa não retornou resultados."))
    .Produces<IEnumerable<ListarAlunoDto>>(StatusCodes.Status200OK)
    .Produces<string>(StatusCodes.Status404NotFound)
    .WithName("ListarAlunosAsync")
    .WithTags("Alunos - Leitura");

app.MapGet("/alunos/{id}", async (
    Guid id,
    IAlunoApplicationServices alunoApplicationServices) =>

     await alunoApplicationServices.ListarAlunosAsync(id)
     is ListarAlunoDto aluno
     ? Results.Ok(aluno)
     : Results.NotFound("A pesquisa não retornou resultados."))
    .Produces<ListarAlunoDto>(StatusCodes.Status200OK)
    .Produces<ListarAlunoDto>(StatusCodes.Status404NotFound)
    .WithName("ListarAlunosPorIdAsync")
    .WithTags("Alunos - Leitura");

app.MapPost("/alunos", async (
    InserirAlunoDto inserirAlunoDto,
    IAlunoApplicationServices alunoApplicationServices) =>

{
    if (!MiniValidator.TryValidate(inserirAlunoDto, out var errors))
        return Results.ValidationProblem(errors);

    var id = await alunoApplicationServices.SalvarAlunosAsync(inserirAlunoDto);

    return id != Guid.Empty
     ? Results.CreatedAtRoute("ListarAlunosPorIdAsync", new { Id = id })
     : Results.BadRequest("Problemas ao salvar o aluno");
})
   .ProducesValidationProblem()
   .Produces<Guid>(StatusCodes.Status201Created)
   .Produces(StatusCodes.Status400BadRequest)
   .WithName("SalvarAlunosAsync")
   .WithTags("Alunos - Escrita");

app.MapPut("/alunos", async (
    AtualizarAlunoDto atualizarAlunoDto,
    IAlunoApplicationServices alunoApplicationServices) =>

{
    if (!MiniValidator.TryValidate(atualizarAlunoDto, out var errors))
        return Results.ValidationProblem(errors);

    var id = await alunoApplicationServices.AtualizarAlunoAsync(atualizarAlunoDto);

    return id != Guid.Empty
     ? Results.NoContent()
     : Results.BadRequest("Problemas ao atualizar o aluno");
})
   .ProducesValidationProblem()
   .Produces(StatusCodes.Status204NoContent)
   .Produces(StatusCodes.Status400BadRequest)
   .WithName("AtualizarAlunosAsync")
   .WithTags("Alunos - Escrita");

app.MapDelete("/alunos", async (
    Guid alunoId,
    IAlunoApplicationServices alunoApplicationServices) =>

{

    var id = await alunoApplicationServices.ExcluirAlunoAsync(alunoId);

    return id != Guid.Empty
     ? Results.Ok("Aluno excluído com sucesso.")
     : Results.BadRequest("O aluno não existe.");
})
   .ProducesValidationProblem()
   .Produces(StatusCodes.Status204NoContent)
   .Produces(StatusCodes.Status400BadRequest)
   .WithName("ExcluirAlunosAsync")
   .WithTags("Alunos - Escrita");

#endregion

app.Run();
