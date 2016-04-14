using System;
using Fwp.common;

namespace Utilidades
{
  public static class Validacion
  {
    public static TiposBases.EstadoRegistro ConvertirAEstadosRegistros(object valor)
    {
      if ((Boolean)valor)
      {
        return TiposBases.EstadoRegistro.ACT;
      }
      return TiposBases.EstadoRegistro.DES;
    }

    public static bool ConvertirABool(TiposBases.EstadoRegistro valor)
    {
      switch (valor)
      {
        case TiposBases.EstadoRegistro.ACT:
          return true;
        case TiposBases.EstadoRegistro.DES:
          return false;
        case TiposBases.EstadoRegistro.TODOS:
          return false;
      }
      return false;
    }

    /// <summary>
    /// Metodo que valida que el número que se esta obteniendo sea un numero Int 
    /// </summary>
    /// <param name="valor">Valor Ingresado</param>
    /// <param name="parametro">Campo</param>
    /// <returns></returns>
    public static Int32 ValidaEntero(this string valor, string parametro)
    {
      int num;
      if (Int32.TryParse(valor, out num))
      {
        return num;
      }
      throw new ArgumentException(Cadenas.PARAMETRO_NO_ENCONTRADO, parametro);
    }
    /// <summary>
    /// Metodo que valida que el numero ingresado sera un numero Decimal
    /// </summary>
    /// <param name="valor"></param>
    /// <param name="parametro">nombre de campo del cual se obtiene el numero</param>
    /// <returns></returns>
    public static decimal ValidaDecimal(this string valor, string parametro)
    {
      decimal num;
      if (decimal.TryParse(valor, out num))
      {
        return num;
      }
      throw new ArgumentException(Cadenas.PARAMETRO_NO_ENCONTRADO, parametro);
    }
  }
}