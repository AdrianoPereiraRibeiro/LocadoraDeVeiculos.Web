namespace ControleCinema.Dominio.Extensions;

public static class Int32Extensions
{
    public static string FormatarEmHorasEMinutos(this int minutosTotal)
    {
        var horas = minutosTotal / 60;
        var minutos = minutosTotal % 60;

        return $"{horas}h {minutos}m";
    }
}