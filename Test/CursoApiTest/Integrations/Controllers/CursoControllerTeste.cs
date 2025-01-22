using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoBogus;
using curso.api;
using curso.api.Business.Entities;
using curso.api.Configurations;
using curso.api.Models.Cursos;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Test.CursoApiTest.Integrations.Controllers
{
    public class CursoControllerTeste : UsuarioControllerTests
    {
        public CursoControllerTeste(WebApplicationFactory<Startup> factory, ITestOutputHelper output) : base(factory, output)
        {
        }

        [Fact]
        //wanGevenThen
        public async Task Cadastrar_InformandoNomeEDescricaoUsuarioAuthorization_StatusCodeCreated()
        {
            //Arrange
           CursoViewModelInput cursoViewmodelInput = new AutoFaker<CursoViewModelInput>();

            var jwttokem2 = loginviewmodelOutput.Token;

            // add Tokem no Header
            _httpClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",jwttokem2);
            
            // Body da request
            HttpContent content = new StringContent(JsonConvert.SerializeObject(cursoViewmodelInput), 
            Encoding.UTF8,"application/json");

            //Act
             var resultado = await _httpClient.PostAsync("api/v1/cursos",content);

            //Assert  
            _output.WriteLine($"{nameof(CursoControllerTeste)}_{nameof(Cadastrar_InformandoNomeEDescricaoUsuarioAuthorization_StatusCodeCreated)} = {await resultado.Content.ReadAsStringAsync()}");
            Assert.Equal(HttpStatusCode.Created, resultado.StatusCode);
        }

        [Fact]
        //wanGevenThen
        public async Task Get_InformandoUsuarioAuthorization_StatusCodeOK()
        {
            //Arrange
                // add Tokem no Header
                _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",loginviewmodelOutput.Token);
                CursoViewModelInput cursoViewModelInput = new AutoFaker<CursoViewModelInput>();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(cursoViewModelInput),Encoding.UTF8,"application/json");
                var resultadoCurso = await _httpClient.PostAsync("api/v1/cursos",content);
            //Act
                var resultado = await _httpClient.GetAsync("api/v1/cursos");
                var cursos = JsonConvert.DeserializeObject<IList<CursoViewModelOutput>>(await resultado.Content.ReadAsStringAsync());
            //Assert  
                _output.WriteLine($"{nameof(CursoControllerTeste)}_{nameof(Get_InformandoUsuarioAuthorization_StatusCodeOK)} = {await resultado.Content.ReadAsStringAsync()}");
                 Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
                 Assert.NotNull(cursos);
        }
    }
}