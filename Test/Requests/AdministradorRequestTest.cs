using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Api.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Minimalapi.Dominio.Entidades;
using Minimalapi.Dominio.ModelViews;
using Minimalapi.Dominio.Servicos;
using Minimalapi.DTOs;
using Minimalapi.Infraestrutura.Db;

namespace Test.Requests;

[TestClass]

public class AdministradorRequestTest
{
    [ClassInitialize]

    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]

    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

    [TestMethod]
    public async Task TestarGetSetPropriedades()
    {
        //Arrange
        var loginDTO = new LoginDTO
        {
            Email = "adm@teste.com",
            Senha = "123456"
        };
        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application/json");
        //act
        var response = await Setup.client.PostAsync("/Administradores/login", content);

        
        //Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


        var result = await response.Content.ReadAsByteArrayAsync();
        var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsNotNull(admLogado?.Email ?? "");
        Assert.IsNotNull(admLogado?.Perfil ?? "");
        Assert.IsNotNull(admLogado?.Token ?? "");
    }

}