using System;
using System.Collections.Generic;
using Common.Data.ControlAcceso;
using Common.Nomina.Negocio;
using Common.Nomina.TablasGenerales;
using Fwp.common;

namespace DataAccess.Negocio
{
  public class da_negocios : SCDataAccess<co_tg_personas_no>
  {
    public da_negocios(FWPTransaction Transaccion)
    {
      this.Trans = Transaccion;
    }
    public Nomina<co_tg_personas_no2> GetNominaPersonas(co_tg_personas_no2 Nomina)
    {
      try
      {
        SCDataAccessNominas<co_tg_personas_no2> nom = new SCDataAccessNominas<co_tg_personas_no2>();
        return nom.ReadDataGeneric(Nomina, "pa08_tg_personas_no2", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_asociarperfiles> GetPerfilesAsociados(co_ca_asociarperfiles asociarperfiles)
    {
      try
      {
        SCDataAccess<co_ca_asociarperfiles> access = new SCDataAccess<co_ca_asociarperfiles>();
        return access.ReadData(asociarperfiles, "pa08_ca_perfiles_asociados_usuario", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_asociarperfiles> GetPerfilesDisponibles(co_ca_asociarperfiles asociarperfiles)
    {
      try
      {
        SCDataAccess<co_ca_asociarperfiles> access = new SCDataAccess<co_ca_asociarperfiles>();
        return access.ReadData(asociarperfiles, "pa08_ca_perfiles_disponibles_usuario", this.Trans);
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
        SCDataAccess<co_ca_menu> access = new SCDataAccess<co_ca_menu>();
        return access.ReadData(new co_ca_menu(), "pa08_ca_menuPadre_selList", this.Trans);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public IList<co_ca_menu> GetMenuEscritorio()
    {
      try
      {
        SCDataAccess<co_ca_menu> access = new SCDataAccess<co_ca_menu>();
        return access.ReadData(new co_ca_menu(), "pa08_ca_menu_escritorio", this.Trans);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }
}
