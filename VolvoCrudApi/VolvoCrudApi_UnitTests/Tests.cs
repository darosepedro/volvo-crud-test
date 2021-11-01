using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using VolvoCrudApi;
using VolvoCrudApi.Controllers;
using VolvoCrudApi.Models;
using VolvoCrudApi.Repositories;
using VolvoCrudApi.Requests;
using Xunit;

namespace VolvoCrudApi_UnitTests
{
    public class Tests
    {

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
