using FluentValidation;
using System;
using VolvoCrudApi.Models;

namespace VolvoCrudApi.Requests
{
    public class CaminhaoInsertRequest
    {
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int ModeloId { get; set; }
    }

    public class CaminhaoUpdateRequest
    {
        public int Id { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int ModeloId { get; set; }
    }

    //Não fiz uso do recurso, mas é uma boa prática  usar Globalization para as mensagens de erro
    //Referência:
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-5.0
    public class CaminhaoInsertRequestValidator : AbstractValidator<CaminhaoInsertRequest>
    {
        public CaminhaoInsertRequestValidator()
        {
            //Não foi necessário aplicar a regra obrigando apenas FH ou FM, conforme consta no requisisto,
            //pois estamos usando uma tabela para guardar os tipos, o que naturalmente já controla quais tipos
            //poderão ser usados, por FK, com a vantagem de termos uma lista dinâmica, para o caso de necessidade
            //de novos tipos serem acrescentados no futuro
            RuleFor(x => x.ModeloId).NotNull();
            RuleFor(x => x.AnoModelo)
                .GreaterThanOrEqualTo(v => v.AnoFabricacao)
                .LessThanOrEqualTo(v => v.AnoFabricacao + 1)
                .WithMessage("Ano Modelo deve ser Ano Atual ou Posterior (A+1)!");
            RuleFor(x => x.AnoFabricacao)
                .Equal(DateTime.Today.Year)
                .WithMessage("Ano Fabricação deve ser Ano Atual!!");
        }
    }
    //Não fiz uso do recurso, mas é uma boa prática  usar Globalization para as mensagens de erro
    //Referência:
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-5.0
    public class CaminhaoUpdateRequestValidator : AbstractValidator<CaminhaoUpdateRequest>
    {
        public CaminhaoUpdateRequestValidator()
        {
            //Não foi necessário aplicar a regra obrigando apenas FH ou FM, conforme consta no requisisto,
            //pois estamos usando uma tabela para guardar os tipos, o que naturalmente já controla quais tipos
            //poderão ser usados, por FK, com a vantagem de termos uma lista dinâmica, para o caso de necessidade
            //de novos tipos serem acrescentados no futuro
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.ModeloId).NotNull();
            RuleFor(x => x.AnoModelo)
                .GreaterThanOrEqualTo(v => v.AnoFabricacao)
                .LessThanOrEqualTo(v => v.AnoFabricacao + 1)
                .WithMessage("Ano Modelo deve ser Ano Atual ou Posterior (A+1)!");
            RuleFor(x => x.AnoFabricacao)
                .Equal(DateTime.Today.Year)
                .WithMessage("Ano Fabricação deve ser Ano Atual!!");
        }
    }

    public static class CaminhaoRequestExtension
    {
        public static Caminhao AsCaminhao(this CaminhaoInsertRequest caminhaoInsertRequest)
        {
            return new Caminhao(
               caminhaoInsertRequest.AnoFabricacao,
               caminhaoInsertRequest.AnoModelo,
               caminhaoInsertRequest.ModeloId
            );
        }

        public static Caminhao AsCaminhao(this CaminhaoUpdateRequest caminhaoUpdateRequest)
        {
            return new Caminhao(
               caminhaoUpdateRequest.Id,
               caminhaoUpdateRequest.AnoFabricacao,
               caminhaoUpdateRequest.AnoModelo,
               caminhaoUpdateRequest.ModeloId
            );
        }

    }

}
