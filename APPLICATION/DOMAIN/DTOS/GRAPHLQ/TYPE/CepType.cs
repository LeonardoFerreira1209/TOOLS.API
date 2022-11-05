using APPLICATION.DOMAIN.DTOS.RESPONSE;

namespace APPLICATION.DOMAIN.DTOS.GRAPHLQ.TYPE;

/// <summary>
/// Tipo de retorno do GRAPQL.
/// </summary>
public class CepType : ObjectType<CepResponse>
{
    /// <summary>
    /// Setando configurações através do CepResponse
    /// </summary>
    /// <param name="descriptor"></param>
    protected override void Configure(IObjectTypeDescriptor<CepResponse> descriptor)
    {
        descriptor.BindFields(BindingBehavior.Explicit);

        descriptor.Name("Endereço");

        descriptor.Field(c => c.cep)
            .Type<StringType>().Name("Cep").Description("CEP - Código de endereçamento postal.");

        descriptor.Field(c => c.logradouro)
            .Type<StringType>().Name("Logradouro").Description("Logradouro - Dados do endereço (Rua, Avenida, Numero...).");

        descriptor.Field(c => c.bairro)
            .Type<StringType>().Name("Bairro").Description("Bairro - Nome do bairro.");

        descriptor.Field(c => c.complemento)
            .Type<StringType>().Name("Complemento").Description("Complemento - Nome do Complemento.");

        descriptor.Field(c => c.localidade)
            .Type<StringType>().Name("Localidade").Description("Localidade - Descrição do local onde o endereço se encontra.");

        descriptor.Field(c => c.uf)
            .Type<StringType>().Name("UF").Description("UF - Unidade federativa.");

        descriptor.Field(c => c.siafi)
            .Type<StringType>().Name("Siafi").Description("Siafi - Codigo do Siafi.");

        descriptor.Field(c => c.gia)
            .Type<StringType>().Name("Gia").Description("Gia - Código da Gia.");

        descriptor.Field(c => c.ddd)
            .Type<StringType>().Name("DDD").Description("DDD - DDD do emdereço (18, 19, 20...).");
    }
}
