using VolvoCrudApi.Models;

namespace VolvoCrudApi.Requests
{
    //Não usei fluent validation aqui, então para ver um exemplo 
    //vá para as classes CaminhaoUpdateRequest e CaminhaoInserRequest
    public class ModeloRequest
    {
        public string Descricao { get; set; }
    }

    public static class ModeloRequestExtension
    {
        //Aqui faço uso de um Extension Method (crei pelo menos outros 5 neste projeto)
        public static Modelo AsModelo(this ModeloRequest modeloRequest)
        {
            return new Modelo(modeloRequest.Descricao);
        }

    }
}
