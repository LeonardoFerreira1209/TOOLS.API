namespace APPLICATION.DOMAIN.DTOS.RESPONSE.CEP;

/// <summary>
/// Objeto de retorno do CEP
/// </summary>
public class CepResponse
{
    public Guid id { get; set; }

    /// <summary>
    /// Código de endereçamento postal. 
    /// </summary>
    public string cep { get; set; }

    /// <summary>
    /// Logradouro do endereço. 
    /// </summary>
    public string logradouro { get; set; }

    /// <summary>
    /// Complemento do endereço. 
    /// </summary>
    public string complemento { get; set; }

    /// <summary>
    /// Bairro do endereço. 
    /// </summary>
    public string bairro { get; set; }

    /// <summary>
    /// Localidade do endereço. 
    /// </summary>
    public string localidade { get; set; }

    /// <summary>
    /// Unidade federativa do endereço. 
    /// </summary>
    public string uf { get; set; }

    /// <summary>
    /// Ibge do endereço. 
    /// </summary>
    public string ibge { get; set; }

    /// <summary>
    /// Gia do endereço. 
    /// </summary>
    public string gia { get; set; }

    /// <summary>
    /// DDD do endereço. 
    /// </summary>
    public string ddd { get; set; }

    /// <summary>
    /// Siafi do endereço. 
    /// </summary>
    public string siafi { get; set; }
}
