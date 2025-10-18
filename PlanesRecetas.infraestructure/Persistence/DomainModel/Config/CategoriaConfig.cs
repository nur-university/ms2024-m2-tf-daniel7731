using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanesRecetas.domain.Care;
using PlanesRecetas.domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.infraestructure.Persistence.DomainModel.Config
{
    internal class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Tipo)
               .WithMany()
               .HasForeignKey(x => x.TipoAlimentoId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
