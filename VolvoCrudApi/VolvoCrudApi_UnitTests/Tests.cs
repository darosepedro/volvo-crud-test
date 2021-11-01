using VolvoCrudApi.Requests;
using Xunit;

namespace VolvoCrudApi_UnitTests
{
    public class Tests
    {
        //Usei Theory, que usa dados dinâmicos como massa de teste.
        //Estes dados dinâmicos estão na classe CaminhaoInsertRequestData, separados
        //em um arquivo chamado Massa.cs
        [Theory]
        [ClassData(typeof(CaminhaoInsertRequestData))]
        public void GetByIdAsync_Returns_Product(CaminhaoInsertRequest massa, bool cenario_valido)
        {
            var validator = new CaminhaoInsertRequestValidator();
            var model = new CaminhaoInsertRequest()
            {
                AnoFabricacao = massa.AnoFabricacao,
                AnoModelo = massa.AnoModelo,
                ModeloId = massa.ModeloId
            };
            var result = validator.Validate(model);
            Assert.Equal(cenario_valido , result.IsValid);
        }
    }
}
