using APPLICATION.DOMAIN.DTOS.RESPONSE;
using APPLICATION.DOMAIN.ENTITY.CEP;
using APPLICATION.DOMAIN.ENUM;
using APPLICATION.ENUMS;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.ComponentModel;

namespace APPLICATION.DOMAIN.UTILS.EXTENSIONS;

public static class Extensions
{
    private static T ObterAtributoDoTipo<T>(this Enum valorEnum) where T : Attribute
    {
        var type = valorEnum.GetType();

        var memInfo = type.GetMember(valorEnum.ToString());

        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

        return attributes.Length > 0 ? (T)attributes[0] : null;
    }

    /// <summary>
    /// Obtem a descrição de um Enum.
    /// </summary>
    /// <param name="valorEnum"></param>
    /// <returns></returns>
    public static string ObterDescricao(this Enum valorEnum)
    {
        return valorEnum.ObterAtributoDoTipo<DescriptionAttribute>().Description;
    }

    /// <summary>
    /// Obtem o código de um Enum
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string ToCode(this ErrorCode valor)
    {
        return valor.GetHashCode().ToString();
    }

    /// <summary>
    /// Obtém a data atual referente a Brasilia.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static DateTime DataAtualBrasilia(this DateTime data)
    {
        DateTime dateTime = DateTime.UtcNow;

        TimeZoneInfo hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        return TimeZoneInfo.ConvertTimeFromUtc(dateTime, hrBrasilia);
    }

    /// <summary>
    /// Serializa objeto ignorando objetos nulos.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static string SerializeIgnoreNullValues(this object item)
    {
        var jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        return JsonConvert.SerializeObject(item, jsonSerializerSettings);
    }

    /// <summary>
    /// Retorna uma lista de DadosNotificacao.
    /// </summary>
    /// <param name="resultado"></param>
    /// <returns></returns>
    public static List<DadosNotificacao> GetErros(this ValidationResult resultado)
    {
        var erros = new List<DadosNotificacao>();

        foreach (var erro in resultado.Errors)
        {
            erros.Add(new DadosNotificacao((StatusCodes)Convert.ToInt32(erro.ErrorCode), erro.ErrorMessage));
        }

        return erros;
    }

    #region CEP
    /// <summary>
    /// Converte um IEnumerable de CepEntity para uma lista de CepResponse.
    /// </summary>
    /// <param name="ceps"></param>
    /// <returns></returns>
    public async static Task<IEnumerable<CepResponse>> ToCepResponse(this IEnumerable<CepEntity> ceps)
    {
        return await Task.FromResult(ceps.Select(cep => new CepResponse
        {
            id = cep.Id,
            cep = cep.Cep,
            bairro = cep.Bairro,
            complemento = cep.Complemento,
            ddd = cep.Ddd,
            gia = cep.Gia,
            ibge = cep.Ibge,
            localidade = cep.Localidade,
            logradouro = cep.Logradouro,
            siafi = cep.Siafi,
            uf = cep.Uf

        }).ToList());
    }
    #endregion
}

