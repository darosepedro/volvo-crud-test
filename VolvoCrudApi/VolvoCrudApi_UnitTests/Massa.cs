using System;
using System.Collections.Generic;
using System.Text;
using VolvoCrudApi.Requests;
using Xunit;

namespace VolvoCrudApi_UnitTests
{
    internal class CaminhaoInsertRequestData : TheoryData<CaminhaoInsertRequest, bool>
    {
        public CaminhaoInsertRequestData()
        {
            //Cenário A - Ano modelo menor que ano de fabricação
            Add(new CaminhaoInsertRequest()
            {
                ModeloId = 1,
                AnoFabricacao = 2021,
                AnoModelo = 2019
            } , false); //Cenário inválido

            //Cenário B - Ano modelo igual que ano de fabricação
            Add(new CaminhaoInsertRequest()
            {
                ModeloId = 1,
                AnoFabricacao = 2021,
                AnoModelo = 2021
            }, true); //Cenário válido

            //Cenário C - Ano modelo um ano após ano de fabricação
            Add(new CaminhaoInsertRequest()
            {
                ModeloId = 1,
                AnoFabricacao = 2021,
                AnoModelo = 2022
            }, true); //Cenário válido

            //Cenário D - Ano modelo dois anos após ano de fabricação
            Add(new CaminhaoInsertRequest()
            {
                ModeloId = 1,
                AnoFabricacao = 2021,
                AnoModelo = 2023
            }, false); //Cenário inválido
        }
    }

}
