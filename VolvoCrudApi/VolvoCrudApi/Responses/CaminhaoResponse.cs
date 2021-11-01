using System.Collections.Generic;
using System.Linq;
using VolvoCrudApi.Models;

namespace VolvoCrudApi.Requests
{
    public class CaminhaoResponse
    {
        public int Id { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public ModeloResponse Modelo { get; set; }

        public CaminhaoResponse(int id, int anoFabricacao, int anoModelo, ModeloResponse modelo)
        {
            Id = id;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Modelo = modelo;
        }
    }

    public static class CaminhaoResponseExtension
    {
        public static CaminhaoResponse AsCaminhaoResponse(this Caminhao caminhao)
        {
            return new CaminhaoResponse(
                    caminhao.Id,
                    caminhao.AnoFabricacao,
                    caminhao.AnoModelo,
                    new ModeloResponse(
                        caminhao.Modelo.Id,
                        caminhao.Modelo.Descricao
                )
            );
        }

        public static IEnumerable<CaminhaoResponse> AsCaminhaoResponseList(this IEnumerable<Caminhao> caminhao)
        {
            return caminhao.Select(x => x.AsCaminhaoResponse());
        }
    }
}
