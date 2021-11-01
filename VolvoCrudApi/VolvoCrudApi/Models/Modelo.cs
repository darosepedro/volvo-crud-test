using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace VolvoCrudApi.Models
{
    public class Modelo: Base
    {
        public string Descricao { get; set; }
        public virtual ICollection<Caminhao> Caminhoes { get; set; }
        public Modelo(string descricao)
        {
            Descricao = descricao;
        }
        //Usado para o Seed Method
        public Modelo(int Id, string descricao)
        {
            base.Id = Id;
            Descricao = descricao;
        }
    }

    public class ModeloEntityConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.Property(x => x.Descricao).HasColumnType("nvarchar(50)");

            builder.HasMany(x => x.Caminhoes)
                   .WithOne(x => x.Modelo).IsRequired();
        }
    }
}
