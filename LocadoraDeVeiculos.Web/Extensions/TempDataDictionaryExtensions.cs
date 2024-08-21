using System.Text.Json;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LocadoraDeVeiculos.Web.Extensions;

public static class TempDataDictionaryExtensions
{
    public static void SerializarMensagemViewModel(
        this ITempDataDictionary dicionario, MensagemViewModel mensagemVm)
    {
        dicionario["Mensagem"] = JsonSerializer.Serialize(mensagemVm);
    }
    
    public static MensagemViewModel? DesserializarMensagemViewModel(this ITempDataDictionary dicionario)
    {
        var mensagemStr = dicionario["Mensagem"]?.ToString();

        if (mensagemStr is null) return null;

        return JsonSerializer.Deserialize<MensagemViewModel>(mensagemStr);
    }
}