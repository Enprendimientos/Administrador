using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
  public class bf_ca_menu
  {
    public co_ca_menu GetData(int id)
    {
      try
      {
        br_ca_menu BRmenu = new br_ca_menu();
        return BRmenu.GetData(id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_menu> GetData(co_ca_menu menu)
    {
      try
      {
        br_ca_menu BRmenu = new br_ca_menu();
        return BRmenu.GetData(menu);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public co_ca_menu Save(co_ca_menu menu)
    {
      try
      {
        br_ca_menu BRmenu = new br_ca_menu();
        if (menu.id == 0)
        {
          return BRmenu.Insert(menu);
        }
        else
        {
          BRmenu.Update(menu);
          return menu;
        }

      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_menu> Save(IList<co_ca_menu> menus)
    {
      try
      {
        br_ca_menu BRmenu = new br_ca_menu();
        List<co_ca_menu> ObjReturn = new List<co_ca_menu>();
        foreach (co_ca_menu of in menus)
        {
          if (of.id == 0)
          {
            ObjReturn.Add(BRmenu.Insert(of));
          }
          else
          {
            BRmenu.Update(of);
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
        br_ca_menu BRmenu = new br_ca_menu();
        BRmenu.Delete(id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public Nomina<co_ca_menu_no> GetNomina(co_ca_menu_no Nomina)
    {
      try
      {
        br_ca_menu BRmenu = new br_ca_menu();
        return BRmenu.GetNomina(Nomina);
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
        br_ca_menu BRmenu = new br_ca_menu();
        return BRmenu.GetInforme(SQLText);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<T> GetInforme<T>(T Informe)
    {
      br_ca_menu BRmenu = new br_ca_menu();
      return BRmenu.GetInforme(Informe);
    }
  }
}


