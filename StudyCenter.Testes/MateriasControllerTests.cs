using Moq;
using Microsoft.AspNetCore.Mvc;
using StudyCenter.API.Controllers;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

/*

1.Arrange (Preparação):
  - A seção Arrange é onde você configura o ambiente necessário para o teste. Isso pode incluir a criação de objetos, a configuração de estados iniciais e a preparação de quaisquer dependências necessárias 
    para a execução do teste.

2.Act (Ação):
  - A seção Act é onde você executa a ação que está sendo testada. Isso pode incluir a chamada de um método ou função específica que você está testando, passando quaisquer argumentos necessários e capturando 
    o resultado da ação.

3.Assert (Assertividade):
  - A seção Assert é onde você verifica se o resultado da ação é o que você espera. Isso envolve a verificação de valores de retorno, o estado de objetos ou quaisquer outros critérios definidos para determinar 
    se a ação foi bem-sucedida. Se os resultados não correspondem às expectativas, o teste falha.
 
 */
namespace StudyCenter.Tests
{
    public class MateriasControllerTests
    {
        [Fact]
        public async Task GetMaterias_DeveRetornarOkSeMateriasExistirem()
        {

            #region Arrange
            /*
             Arrange: Configurando o estado inicial do teste.

                O endpoint "GetMaterias" usa meu dbcontext, interface de QueryRepository, e o proprio objeto Materias, com isso, temos que fazer 
                o mock desses objetos.

             */

            // 1 - Inicio o mock do meu DbContext
            var mockContext = new Mock<StudyCenterDbContext>();

            // 2.1 - Inicio o mock da interface
            var mockInterface = new Mock<IMateriasQueryRepository>();

            // 3 Mock da controller (ja passando o mock do dbcontext e tambem da interface que vai ser usada, como nas outras nao uso, deixei null
            var controller = new MateriasController(mockContext.Object, mockInterface.Object, null, null, null);

            // Mock da materia que sera retornada no ObterTodosAsync
            var materias = new List<Materias>
                {
                    new Materias
                    {
                        IdMateria = 3,
                        NomeMateria = "Matéria de teste",
                        Topicos = new List<Topicos>()
                    }
                };

            // 2.2 - Definir que o metodo "ObterTodosAsync" (utilizado no endpoint) deve retornar o mock da minha materia
            mockInterface.Setup(interfaceMateria => interfaceMateria.ObterTodosAsync()).ReturnsAsync(materias);

            #endregion

            #region Act
            // Act: Seção onde você executa a ação que deseja testar. Neste caso, chamo o método GetMaterias da controller que tem meu dbcontext e minha interface mockada.
            var result = await controller.GetMaterias();

            #endregion

            #region Assert
            // Assert: Seção onde verifico se o resultado da ação é o que eu espero, nesse caso, se o tipo de resultado retornado é OkObjectResult

            //Aqui está sendo verificado se o tipo de result.Result é OkObjectResult. Isso geralmente é usado em testes unitários para verificar se o resultado de uma ação é do tipo esperado.
            Assert.IsType<OkObjectResult>(result.Result);

            //Esta linha também está verificando se result.Result é do tipo OkObjectResult e, se for, armazena esse resultado na variável okResult.
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            //Aqui está sendo verificado se okResult.Value é atribuível a IEnumerable<Materias>. Ou seja, verifica se o valor retornado pela ação pode ser tratado como uma coleção de objetos do tipo Materias.
            var returnedMaterias = Assert.IsAssignableFrom<IEnumerable<Materias>>(okResult.Value);

            //Esta linha está verificando se a coleção returnedMaterias contém apenas um elemento. Isso é útil quando você espera que a ação retorne uma única instância de Materias.
            Assert.Single(returnedMaterias);

            #endregion
        }
    }
}
