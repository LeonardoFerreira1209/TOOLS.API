using APPLICATION.DOMAIN.ENTITY.BASE;

namespace APPLICATION.DOMAIN.ENTITY.CEP;

/// <summary>
/// Entidade de cep
/// </summary>
public class CepEntity : BaseEntity
{
    /// <summary>
    /// Código de endereçamento postal. 
    /// </summary>
    public string Cep { get; set; }

    /// <summary>
    /// Logradouro do endereço. 
    /// </summary>
    public string Logradouro { get; set; }

    /// <summary>
    /// Complemento do endereço. 
    /// </summary>
    public string Complemento { get; set; }

    /// <summary>
    /// Bairro do endereço. 
    /// </summary>
    public string Bairro { get; set; }

    /// <summary>
    /// Localidade do endereço. 
    /// </summary>
    public string Localidade { get; set; }

    /// <summary>
    /// Unidade federativa do endereço. 
    /// </summary>
    public string Uf { get; set; }

    /// <summary>
    /// Ibge do endereço. 
    /// </summary>
    public string Ibge { get; set; }

    /// <summary>
    /// Gia do endereço. 
    /// </summary>
    public string Gia { get; set; }

    /// <summary>
    /// DDD do endereço. 
    /// </summary>
    public string Ddd { get; set; }

    /// <summary>
    /// Siafi do endereço. 
    /// </summary>
    public string Siafi { get; set; }
}
