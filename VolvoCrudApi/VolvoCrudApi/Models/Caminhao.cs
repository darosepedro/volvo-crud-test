using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolvoCrudApi.Models
{
    public class Caminhao : Base
    {
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        public Caminhao()
        { }

        public Caminhao(int anoFabricacao, int anoModelo, int modeloId)
        {
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            ModeloId = modeloId;
        }

        public Caminhao(int id, int anoFabricacao, int anoModelo, int modeloId)
        {
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            ModeloId = modeloId;
            Id = id;
        }
    }

    public class CaminhaoValidator : AbstractValidator<Caminhao>
    {
        public CaminhaoValidator()
        {
            RuleFor(x => x.AnoModelo)
                .GreaterThanOrEqualTo(v => v.AnoFabricacao)
                .LessThanOrEqualTo(v => v.AnoFabricacao + 1)
                .WithMessage("Ano Modelo deve ser Ano Atual ou Posterior (A+1)!");
            RuleFor(x => x.AnoFabricacao)
                .Equal(DateTime.Today.Year)
                .WithMessage("Ano Fabricação deve ser Ano Atual!!");
        }
    }

    public class CaminhaoEntityConfiguration : IEntityTypeConfiguration<Caminhao>
    {
        public void Configure(EntityTypeBuilder<Caminhao> builder)
        {
            builder.Property(x => x.AnoModelo).HasColumnType("int");
            builder.Property(x => x.AnoFabricacao).HasColumnType("int");
            //builder.HasOne(x => x.Modelo)
             //      .WithMany(x => x.Caminhoes)
             //      .HasForeignKey<Caminhao>(x => x.ModeloId);
        }
    }
}
