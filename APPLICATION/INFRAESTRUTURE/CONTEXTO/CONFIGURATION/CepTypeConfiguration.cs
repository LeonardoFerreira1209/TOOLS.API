using APPLICATION.DOMAIN.DTOS.ENTITIES;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APPLICATION.INFRAESTRUTURE.CONTEXTO.CONFIGURATION;

public class CepTypeConfiguration : IEntityTypeConfiguration<CepEntity>
{
    public void Configure(EntityTypeBuilder<CepEntity> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Cep);
        builder.Property(b => b.Logradouro);
        builder.Property(b => b.Bairro);
        builder.Property(b => b.Ibge);
        builder.Property(b => b.Complemento);
        builder.Property(b => b.Ddd);
        builder.Property(b => b.Uf);
        builder.Property(b => b.Siafi);
        builder.Property(b => b.Localidade);
        builder.Property(b => b.Gia);
    }
}
