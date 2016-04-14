using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Data.TablasGenerales;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
  public class br_ca_menu : SCBusinessRules<co_ca_menu>
  {
    public br_ca_menu()
    {
      this.myTrans = new FWPTransaction();
    }

    public br_ca_menu(FWPTransaction Trans)
    {
      this.myTrans = Trans;
      this.myTrans.MyStates = FWPTransaction.States.Taken;
    }

    public co_ca_menu GetData(int id)
    {
      try
      {
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        return DAmenu.GetData(id);
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
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        return DAmenu.GetData(menu);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public co_ca_menu Insert(co_ca_menu menu)
    {
      /*menu
       constantes
       opcion
       menuOpciones*/
      FWPTransaction Trans = new FWPTransaction();
      const string TRANS_NAME = "TransPersona";
      Trans.MyStates = FWPTransaction.States.Taken;
      Trans.myTransaction = Trans.MyConnection.BeginTransaction(TRANS_NAME);
      try
      {
        da_ca_menu DAmenu = new da_ca_menu(Trans);
        menu = DAmenu.Insert(menu); 

        da_tg_constantes daContantes = new da_tg_constantes(Trans);
        co_tg_constantes constante = new co_tg_constantes();
        constante.ct_constante = "ACC_MENU_" + menu.menu_nombreventana;
        constante.ct_constante = constante.ct_constante.ToUpper();

        constante= daContantes.Insert(constante);

        return menu;
      }
      catch (Exception e)
      {
        Trans.MyStates = FWPTransaction.States.Liberate;
        Trans.myTransaction.Rollback(TRANS_NAME);
        throw new Exception(e.Message);
      }
    }

    public IList<co_ca_menu> Insert(IList<co_ca_menu> menu)
    {
      IList<co_ca_menu> ilistReturn;
      try
      {
        this.myTrans.BeginTransaction();
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        ilistReturn = DAmenu.Insert(menu);
        this.myTrans.Commit();
      }
      catch (Exception e)
      {
        this.myTrans.Rollback();
        throw new Exception(e.Message);
      }
      return ilistReturn;
    }

    public void Update(co_ca_menu menu)
    {
      try
      {
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        DAmenu.Update(menu);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Update(IList<co_ca_menu> menu)
    {
      try
      {
        this.myTrans.BeginTransaction();
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        DAmenu.Update(menu);
        this.myTrans.Commit();
      }
      catch (Exception e)
      {
        this.myTrans.Rollback();
        throw new Exception(e.Message);
      }
    }

    public void Delete(int id)
    {
      try
      {
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        DAmenu.Delete(id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void Delete(co_ca_menu menu)
    {
      try
      {
        this.myTrans.BeginTransaction();
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        DAmenu.Delete(menu);
        this.myTrans.Commit();

      }
      catch (Exception e)
      {
        this.myTrans.Rollback();
        throw new Exception(e.Message);
      }
    }

    public Nomina<co_ca_menu_no> GetNomina(co_ca_menu_no Nomina)
    {
      try
      {
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        return DAmenu.GetNomina(Nomina);
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
        da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
        return DAmenu.GetInforme(SQLText);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public IList<T> GetInforme<T>(T Informe)
    {
      da_ca_menu DAmenu = new da_ca_menu(this.myTrans);
      return DAmenu.GetInforme(Informe);
    }
  }
}

