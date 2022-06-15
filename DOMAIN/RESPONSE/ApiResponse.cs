using DOMAIN.ENUM;

namespace DOMAIN.RESPONSE;

public class DadosNotificacao
{
    public StatusCodes StatusCode { get; set; }
    public string Mensagem { get; set; }
}

public class ApiResponse<T> where T : class
{
    public ApiResponse() { }

    public ApiResponse(bool sucesso, List<DadosNotificacao> notificacaos = null)
    {
        Sucesso = sucesso;
        Notificacoes = notificacaos;
    }

    public ApiResponse(bool sucesso, T dados = null, List<DadosNotificacao> notificacoes = null)
    {
        Sucesso = sucesso;
        Dados = dados;
        Notificacoes = notificacoes;
    }

    public bool Sucesso { get; set; }
    public T Dados { get; set; }
    public List<DadosNotificacao> Notificacoes { get; set; }
}
