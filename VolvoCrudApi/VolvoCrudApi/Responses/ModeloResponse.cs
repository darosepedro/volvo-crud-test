using System.Collections.Generic;
using System.Linq;
using VolvoCrudApi.Models;

namespace VolvoCrudApi.Requests
{
    public class ModeloResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ModeloResponse(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }

    public static class ModeloResponseExtension
    {
        public static ModeloResponse AsModeloResponse(this Modelo modelo)
        {
            return new ModeloResponse(
                    modelo.Id,
                    modelo.Descricao
            );
        }

        public static IEnumerable<ModeloResponse> AsModeloResponseList(this IEnumerable<Modelo> modelo)
        {
            return modelo.Select(x => x.AsModeloResponse());
        }
    }
}
