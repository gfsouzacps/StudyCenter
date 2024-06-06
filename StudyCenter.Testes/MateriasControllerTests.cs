using Moq;
using Microsoft.AspNetCore.Mvc;
using StudyCenter.API.Controllers;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

/*

1.Arrange (Prepara��o):
  - A se��o Arrange � onde voc� configura o ambiente necess�rio para o teste. Isso pode incluir a cria��o de objetos, a configura��o de estados iniciais e a prepara��o de quaisquer depend�ncias necess�rias 
    para a execu��o do teste.

2.Act (A��o):
  - A se��o Act � onde voc� executa a a��o que est� sendo testada. Isso pode incluir a chamada de um m�todo ou fun��o espec�fica que voc� est� testando, passando quaisquer argumentos necess�rios e capturando 
    o resultado da a��o.

3.Assert (Assertividade):
  - A se��o Assert � onde voc� verifica se o resultado da a��o � o que voc� espera. Isso envolve a verifica��o de valores de retorno, o estado de objetos ou quaisquer outros crit�rios definidos para determinar 
    se a a��o foi bem-sucedida. Se os resultados n�o correspondem �s expectativas, o teste falha.
 
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
                        NomeMateria = "Mat�ria de teste",
                        Topicos = new List<Topicos>()
                    }
                };

            // 2.2 - Definir que o metodo "ObterTodosAsync" (utilizado no endpoint) deve retornar o mock da minha materia
            mockInterface.Setup(interfaceMateria => interfaceMateria.ObterTodosAsync()).ReturnsAsync(materias);

            #endregion

            #region Act
            // Act: Se��o onde voc� executa a a��o que deseja testar. Neste caso, chamo o m�todo GetMaterias da controller que tem meu dbcontext e minha interface mockada.
            var result = await controller.GetMaterias();

            #endregion

            #region Assert
            // Assert: Se��o onde verifico se o resultado da a��o � o que eu espero, nesse caso, se o tipo de resultado retornado � OkObjectResult

            //Aqui est� sendo verificado se o tipo de result.Result � OkObjectResult. Isso geralmente � usado em testes unit�rios para verificar se o resultado de uma a��o � do tipo esperado.
            Assert.IsType<OkObjectResult>(result.Result);

            //Esta linha tamb�m est� verificando se result.Result � do tipo OkObjectResult e, se for, armazena esse resultado na vari�vel okResult.
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            //Aqui est� sendo verificado se okResult.Value � atribu�vel a IEnumerable<Materias>. Ou seja, verifica se o valor retornado pela a��o pode ser tratado como uma cole��o de objetos do tipo Materias.
            var returnedMaterias = Assert.IsAssignableFrom<IEnumerable<Materias>>(okResult.Value);

            //Esta linha est� verificando se a cole��o returnedMaterias cont�m apenas um elemento. Isso � �til quando voc� espera que a a��o retorne uma �nica inst�ncia de Materias.
            Assert.Single(returnedMaterias);

            #endregion
        }
    }
}
