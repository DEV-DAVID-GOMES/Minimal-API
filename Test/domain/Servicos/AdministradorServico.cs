using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minimalapi.Dominio.Entidades;
using Minimalapi.Dominio.Servicos;
using Minimalapi.Infraestrutura.Db;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            // Arrange
            using var context = CriarContextoDeTeste();
            context.Database.EnsureDeleted(); // Limpa o banco de dados para cada teste
            context.Database.EnsureCreated(); // Cria o banco de dados se ele não existir

            var administradorServico = new AdministradorServico(context);
            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            // Act
            administradorServico.Incluir(adm);
            var admDoBanco = administradorServico.BuscarPorId(adm.Id);

            // Assert
            Assert.IsNotNull(admDoBanco, "O administrador buscado não pode ser nulo.");
            Assert.AreEqual(adm.Email, admDoBanco.Email, "Os emails não correspondem.");
            Assert.AreEqual(adm.Id, admDoBanco.Id, "Os IDs não correspondem.");
        }
    }
}
