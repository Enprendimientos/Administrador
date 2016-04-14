using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
  public class da_ca_usuariosperfiles : SCDataAccess<co_ca_usuariosperfiles>
  {
    public da_ca_usuariosperfiles(FWPTransaction Transaccion)
    {
      this.Trans = Transaccion;
    }

    public co_ca_usuariosperfiles GetData(int id)
    {
      try
      {
        return this.ReadDataGeneric(id, "pa08_ca_usuariosperfiles_sel", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_usuariosperfiles> GetData(co_ca_usuariosperfiles usuariosperfiles)
    {
      try
      {
        return this.ReadDataGeneric(usuariosperfiles, "pa08_ca_usuariosperfiles_selList", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public co_ca_usuariosperfiles Insert(co_ca_usuariosperfiles usuariosperfiles)
    {
      try
      {
        return this.CreateDataGeneric(usuariosperfiles, "pa08_ca_usuariosperfiles_in", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_usuariosperfiles> Insert(IList<co_ca_usuariosperfiles> usuariosperfiles)
    {
      try
      {
        return this.CreateDataGeneric(usuariosperfiles, "pa08_ca_usuariosperfiles_in", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Update(co_ca_usuariosperfiles usuariosperfiles)
    {
      try
      {
        this.UpdateDataGeneric(usuariosperfiles, "pa08_ca_usuariosperfiles_ac", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Update(IList<co_ca_usuariosperfiles> usuariosperfiles)
    {
      try
      {
        this.UpdateDataGeneric(usuariosperfiles, "pa08_ca_usuariosperfiles_ac", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Delete(int id)
    {
      try
      {
        this.DeleteDataGeneric(id, "pa08_ca_usuariosperfiles_el", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Delete(co_ca_usuariosperfiles usuariosperfiles)
    {
      try
      {
        this.DeleteDataGeneric(usuariosperfiles, "pa08_ca_usuariosperfiles_elRecords", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public Nomina<co_ca_usuariosperfiles_no> GetNomina(co_ca_usuariosperfiles_no Nomina)
    {
      try
      {
        SCDataAccessNominas<co_ca_usuariosperfiles_no> nom = new SCDataAccessNominas<co_ca_usuariosperfiles_no>();
        return nom.ReadDataGeneric(Nomina, "pa08_ca_usuariosperfiles_no", this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public DataSet GetInforme(String SQLText)
    {
      try
      {
        SCDataAccessInformes<String> inf = new SCDataAccessInformes<String>();
        return inf.ReadDataGeneric(SQLText, this.Trans);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<T> GetInforme<T>(T Informe)
    {
      //SCDataAccessInformes<T> inf = new SCDataAccessInformes<T>();
      //return inf.ReadDataGeneric(Informe, "", this.Trans);
      return new List<T>();
    }

  }
}

