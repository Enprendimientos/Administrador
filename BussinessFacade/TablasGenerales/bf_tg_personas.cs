using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.TablasGenerales;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
  public class bf_tg_personas
  {
    public co_tg_personas GetData(int id)
    {
      try
      {
        br_tg_personas BRpersonas = new br_tg_personas();
        return BRpersonas.GetData(id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_tg_personas> GetData(co_tg_personas personas)
    {
      try
      {
        br_tg_personas BRpersonas = new br_tg_personas();
        return BRpersonas.GetData(personas);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public co_tg_personas Save(co_tg_personas personas)
    {
      try
      {
        br_tg_personas BRpersonas = new br_tg_personas();
        if (personas.id == 0)
        {
          return BRpersonas.Insert(personas);
        }
        else
        {
          BRpersonas.Update(personas);
          return personas;
        }

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_tg_personas> Save(IList<co_tg_personas> personass)
    {
      try
      {
        br_tg_personas BRpersonas = new br_tg_personas();
        List<co_tg_personas> ObjReturn = new List<co_tg_personas>();
        foreach (co_tg_personas of in personass)
        {
          if (of.id == 0)
          {
            ObjReturn.Add(BRpersonas.Insert(of));
          }
          else
          {
            BRpersonas.Update(of);
            ObjReturn.Add(of);
          }
        }
        return ObjReturn;

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
        br_tg_personas BRpersonas = new br_tg_personas();
        BRpersonas.Delete(id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public Nomina<co_tg_personas_no> GetNomina(co_tg_personas_no Nomina)
    {
      try
      {
        br_tg_personas BRpersonas = new br_tg_personas();
        return BRpersonas.GetNomina(Nomina);
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
        br_tg_personas BRpersonas = new br_tg_personas();
        return BRpersonas.GetInforme(SQLText);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<T> GetInforme<T>(T Informe)
    {
      br_tg_personas BRpersonas = new br_tg_personas();
      return BRpersonas.GetInforme(Informe);
    }


  }
}


