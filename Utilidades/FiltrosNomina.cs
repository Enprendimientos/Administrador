using System;
using System.Globalization;
using Fwp.common;

namespace Utilidades
{
  public class FiltrosNomina
  {
    public static T ValidarFiltros<T>(object valorinicial, object valor)
    {
      if (typeof(T) == typeof(string))
      {
        return (T)(object)(string.IsNullOrEmpty((string)valor) ? (string)valorinicial : (string)valor);
      }
      if (typeof(T) == typeof(int))
      {
        return (T)(object)(string.IsNullOrEmpty((string)valor) ? valorinicial : Convert.ToInt32(valor));
      }
      if (typeof(T) == typeof(decimal))
      {
        return (T)(object)(string.IsNullOrEmpty((string)valor) ? valorinicial : Convert.ToDecimal(valor, new CultureInfo("en-US")));
      }
      if (typeof(T) == typeof(DateTime))
      {
        return (T)(object)(valor ?? valorinicial);
      }
      if (typeof(T) == typeof(TiposBases.EstadoRegistro) && Enum.IsDefined(typeof(TiposBases.EstadoRegistro), valor))
      {
        return (T)Enum.Parse(typeof(TiposBases.EstadoRegistro), valor.ToString(), true);
      }
      return (T)valorinicial;
    }
  }
}
