using System;
using System.Collections.Generic;
using Common.Data.ControlAcceso;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.ControlAcceso;
using DataAccess.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;
using Fwp.SystemFramework;

namespace BussinessRules.Negocio
{
  public class br_negocios : SCBusinessRules<co_tg_personas>
  {
    public br_negocios()
    {
      this.myTrans = new FWPTransaction();
    }
    public br_negocios(FWPTransaction Trans)
    {
      this.myTrans = Trans;
      this.myTrans.MyStates = FWPTransaction.States.Taken;
    }
    public Nomina<co_tg_personas_no2> GetNominaPersonas(co_tg_personas_no2 Nomina)
    {
      try
      {
        da_negocios access = new da_negocios(this.myTrans);
        return access.GetNominaPersonas(Nomina);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Save(co_tg_personas persona, co_ca_usuarios usuario)
    {
      FWPTransaction Trans = new FWPTransaction();
      const string TRANS_NAME = "TransPersona";
      Trans.MyStates = FWPTransaction.States.Taken;
      Trans.myTransaction = Trans.MyConnection.BeginTransaction(TRANS_NAME);
      try
      {
        Security sec = new Security();
        
        if (persona.id == 0)
        {
          persona.pers_fecha_creacion.Fecha = DateTime.Now;
          persona = new da_tg_personas(Trans).Insert(persona);
        }
        else
        {
          persona.pers_fecha_modificacion.Fecha = DateTime.Now;
          new da_tg_personas(Trans).Update(persona);
        }
        usuario.usua_password = sec.Encrypt(usuario.usua_password);
        if (usuario.id_persona.id==0 && usuario.id==0)
        {
          usuario.id_persona.id = persona.id_persona;
          new da_ca_usuarios(Trans).Insert(usuario);
        }
        else
        {
          new da_ca_usuarios(Trans).Update(usuario);
        }
        Trans.myTransaction.Commit();
        Trans.MyStates = FWPTransaction.States.Liberate;
      }
      catch (Exception e)
      {
        Trans.MyStates = FWPTransaction.States.Liberate;
        Trans.myTransaction.Rollback(TRANS_NAME);
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_asociarperfiles> GetPerfilesAsociados(co_ca_asociarperfiles asociarperfiles)
    {
      try
      {
        da_negocios access = new da_negocios(this.myTrans);
        return access.GetPerfilesAsociados(asociarperfiles);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public IList<co_ca_asociarperfiles> GetPerfilesDisponibles(co_ca_asociarperfiles asociarperfiles)
    {
      try
      {
        da_negocios access = new da_negocios(this.myTrans);
        return access.GetPerfilesDisponibles(asociarperfiles);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public IList<co_ca_menu> GetMenuPadre()
    {
      try
      {
        da_negocios acces = new da_negocios(this.myTrans);
        return acces.GetMenuPadre();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }
}
