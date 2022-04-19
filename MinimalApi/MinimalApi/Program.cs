//objetos para acesso a container e serviços do aspnetcore

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Dtos;
using MinimalApi.Extensions;
using MiniValidation;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer()
                .AddMinimalApiHttpLogging()
                .AddOptionsPattern(configuration)
                .AddSwaggerDocumentation(configuration)
                .AddMinimalApiPerformanceBoost()
                .AddDbContextInMemory()
                .AddDependencyInjection()
                .AddApiVersioning(x => x.DefaultApiVersion = ApiVersion.Default)
                .AddMinimalApiAuthentication()
                .AddMinimalApiAuthorization();

var app = builder.Build();

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

MapAlunoActions(app);
MapUsuarioActions(app);
MapAuthActions(app);

app.Run();

void MapAlunoActions(WebApplication app)
{
    #region Endpoints de Aluno

    app.MapGet("/alunos", [Authorize(Roles = "User")] async (
        [FromQuery] bool estaAtivo,
        IAlunoApplicationServices alunoApplicationServices) =>

        await alunoApplicationServices.ListarAlunosAsync(estaAtivo)
        is IEnumerable<ListarAlunoDto> alunos
        ? Results.Ok(alunos)
        : Results.NotFound("A pesquisa não retornou resultados."))
        .Produces<IEnumerable<ListarAlunoDto>>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .WithName("ListarAlunosAsync")
        .WithTags("Alunos - Leitura");


    app.MapGet("/alunos/{id}", [Authorize(Roles = "Admin")] async (
        Guid id,
        IAlunoApplicationServices alunoApplicationServices) =>

         await alunoApplicationServices.ListarAlunosAsync(id)
         is ListarAlunoDto aluno
         ? Results.Ok(aluno)
         : Results.NotFound("A pesquisa não retornou resultados."))
        .Produces<ListarAlunoDto>(StatusCodes.Status200OK)
        .Produces<ListarAlunoDto>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .WithName("ListarAlunosPorIdAsync")
        .WithTags("Alunos - Leitura");

    app.MapPost("/alunos", [Authorize(Roles = "Admin")] async (
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
       .Produces(StatusCodes.Status401Unauthorized)
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
       .Produces(StatusCodes.Status401Unauthorized)
       .WithName("AtualizarAlunosAsync")
       .WithTags("Alunos - Escrita")
       .RequireAuthorization();

    app.MapDelete("/alunos", [Authorize(Roles = "Admin")] async (
        Guid alunoId,
        IAlunoApplicationServices alunoApplicationServices) =>
    {

        var id = await alunoApplicationServices.ExcluirAlunoAsync(alunoId);

        return id != Guid.Empty
         ? Results.Ok("Aluno excluído com sucesso.")
         : Results.BadRequest("O aluno não existe.");
    })
       .Produces(StatusCodes.Status204NoContent)
       .Produces(StatusCodes.Status400BadRequest)
       .Produces(StatusCodes.Status401Unauthorized)
       .WithName("ExcluirAlunosAsync")
       .WithTags("Alunos - Escrita");


    #endregion
}

void MapUsuarioActions(WebApplication app)
{
    #region Endpoints de Usuario

    app.MapPost("/usuarios", async (
        InserirUsuarioDto inserirUsuarioDto,
        IUsuarioApplicationServices usuarioApplicationServices) =>
    {
        if (!MiniValidator.TryValidate(inserirUsuarioDto, out var errors))
            return Results.ValidationProblem(errors);

        var id = await usuarioApplicationServices.SalvarUsuarioAsync(inserirUsuarioDto);

        return id != Guid.Empty
         ? Results.Created("usuarios", new { Id = id })
         : Results.BadRequest("Problemas ao salvar o usuario");
    })
       .ProducesValidationProblem()
       .Produces<Guid>(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest)
       .WithName("SalvarUsuarioAsync")
       .WithTags("Usuários - Escrita")
       .AllowAnonymous();

    #endregion
}

void MapAuthActions(WebApplication app)
{
    #region endpoint para token

    app.MapPost("/login", async (
        LoginUsuarioDto loginUsuarioDto,
        ITokenServices tokenServices) =>
    {
        if (!MiniValidator.TryValidate(loginUsuarioDto, out var errors))
            return Results.ValidationProblem(errors);

        var token = await tokenServices.GenerateTokenAsync(loginUsuarioDto);

        return !string.IsNullOrEmpty(token)
         ? Results.Ok(new { User = loginUsuarioDto.Login, Token = token })
         : Results.NotFound("usuário não existe");
    })
       .ProducesValidationProblem()
       .Produces<Guid>(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest)
       .WithName("GerarTokenAsync")
       .WithTags("Autenticação")
       .AllowAnonymous();

    app.MapGet("/autenticado", (ClaimsPrincipal user) =>
    {
        return Results.Ok(new { Mensagem = $"Autenticado como {user.Identity.Name}" });

    })
      .Produces(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status401Unauthorized)
      .Produces(StatusCodes.Status403Forbidden)
      .WithName("VerificarSeUserEstaAutenticado")
      .WithTags("Autenticação")
      .RequireAuthorization();

    #endregion
}
