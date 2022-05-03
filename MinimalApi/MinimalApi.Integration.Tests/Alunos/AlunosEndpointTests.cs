using MinimalApi.ApplicationServices.Dtos;
using MinimalApi.Integration.Tests.Bases.Configurations;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MinimalApi.Integration.Tests.Alunos
{
    public class AlunosEndpointTests
    {
        private readonly TestApplication _app;
        private readonly HttpClient _client;

        public AlunosEndpointTests()
        {
            _app = new TestApplication();
            _client = _app.CreateClient();
        }

        [Fact]
        [Trait("AlunosEndpoints", "Inserir novo Aluno")]
        public async Task Deve_Inserir_Um_Novo_Aluno()
        {
            var inserirAlunoDto = new InserirAlunoDto()
            {
                Nome = "John Doe",
                Email = "john_doe1@gmail.com"
            };

            var postContent = ContentHelper.GetStringContent(inserirAlunoDto);

            var client = await _client.PostAsync("alunos", postContent);

            Assert.True(true);
        }
    }
}
