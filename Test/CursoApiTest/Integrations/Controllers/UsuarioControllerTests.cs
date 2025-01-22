using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using curso.api;
using System.Net.Http;
using curso.api.Models.Usuarios;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using AutoBogus;
using Bogus;

namespace Test.CursoApiTest.Integrations.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
    {
        protected readonly WebApplicationFactory<Startup> _factory;
        protected readonly ITestOutputHelper _output;
        protected readonly HttpClient _httpClient;
        protected  RegistroViewModelInput registroViewModelInput;
        protected LoginViewModelOutput loginviewmodelOutput;
        public UsuarioControllerTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
            _httpClient = _factory.CreateClient();

        }

        [Fact]
        //WhenGivenThen
        //Quando_dados_EntãoResultadoEsperado
        public async Task Registrar_InformandoUsuarioESenhaNãoExistentes_statusCodeOK()
        {
            //Arrange
                 registroViewModelInput = new AutoFaker<RegistroViewModelInput>()
                                            .RuleFor(p => p.Login, faker => faker.Person.UserName)
                                            .RuleFor(p => p.Email, faker => faker.Person.Email);
                 /*registroViewModelInput = new RegistroViewModelInput()
                {
                    Login = "israel6",
                    Email = "israel@teste1",
                    Senha = "12345"
                };*/

            StringContent content = new StringContent(JsonConvert.SerializeObject(registroViewModelInput), Encoding.UTF8, "application/json");

            //Act
                var httpClientRequest  = await _httpClient.PostAsync("api/v1/usuario/registrar",content);
                var RequestViewModelInput = JsonConvert.DeserializeObject<RegistroViewModelInput>(await httpClientRequest.Content.ReadAsStringAsync());
            //Assert
                _output.WriteLine($"{nameof(UsuarioControllerTests)}_{nameof(Registrar_InformandoUsuarioESenhaNãoExistentes_statusCodeOK)}= {await httpClientRequest.Content.ReadAsStringAsync()}");
                Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);
                Assert.Equal(registroViewModelInput.Login, RequestViewModelInput.Login);

        }
        [Fact]
        public async Task Logar_InformandoUsuarioESenhaExistentes_statusCodeOK()
        {
            //Arrange
                var loginViewModelInput = new LoginViewModelInput
                {
                    Login = registroViewModelInput.Login,
                    Senha = registroViewModelInput.Senha
                };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput), Encoding.UTF8, "application/json");

            //Act
              var httpClientRequest  = await _httpClient.PostAsync("api/v1/usuario/logar",content);
              loginviewmodelOutput = JsonConvert.DeserializeObject<LoginViewModelOutput>( await httpClientRequest.Content.ReadAsStringAsync());
            //Assert
                Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
                Assert.NotNull(loginviewmodelOutput.Token);
                Assert.Equal(loginViewModelInput.Login,loginviewmodelOutput.Usuario.Login);
                _output.WriteLine($"{nameof(UsuarioControllerTests)}_{nameof(Logar_InformandoUsuarioESenhaExistentes_statusCodeOK)}= {await httpClientRequest.Content.ReadAsStringAsync()}");


        }

        public async Task InitializeAsync()
        {
           await Registrar_InformandoUsuarioESenhaNãoExistentes_statusCodeOK();
           await Logar_InformandoUsuarioESenhaExistentes_statusCodeOK();
        }

        public async Task DisposeAsync()
        {
             _httpClient.Dispose();
        }
    }

}