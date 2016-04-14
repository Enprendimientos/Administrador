using System;
using System.Collections.Generic;
using BussinessRules.Negocio;
using Common.Data.ControlAcceso;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.Negocio
{
  public class bf_negocios
  {
   
    public Nomina<co_tg_personas_no2> GetNominaPersonas(co_tg_personas_no2 Nomina)
    {
      try
      {
        br_negocios bussiness = new br_negocios();
        return bussiness.GetNominaPersonas(Nomina);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Save(co_tg_personas persona, co_ca_usuarios usuario)
    {
      try
      {
        br_negocios bussiness = new br_negocios();
        bussiness.Save(persona, usuario);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    /// <summary>
    /// Obtiene un listado de los perfiles que ya se encuentran asociados al usuario seleccionado.
    /// </summary>
    /// <param name="asociarperfiles">objeto que contiene los parametros para la consulta</param>
    /// <returns>Retorna un Listado de perfiles</returns>
    public IList<co_ca_asociarperfiles> GetPerfilesAsociados(co_ca_asociarperfiles asociarperfiles)
    {
      try
      {
        br_negocios bussiness = new br_negocios();
        return bussiness.GetPerfilesAsociados(asociarperfiles);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    /// <summary>
    /// Obtiene un listado de perfiles que se encuentran disponibles para asociar al Usuario seleccionado
    /// </summary>
    /// <param name="asociarperfiles">objeto que contiene los parametros para la consulta</param>
    /// <returns>Retorna un Listado de perfiles</returns>
    public IList<co_ca_asociarperfiles> GetPerfilesDisponibles(co_ca_asociarperfiles asociarperfiles)
    {
      try
      {
        br_negocios bussiness = new br_negocios();
        return bussiness.GetPerfilesDisponibles(asociarperfiles);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_menu> GetMenuPadre()
    {
      try
      {
        br_negocios business = new br_negocios();
        return business.GetMenuPadre();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
