using System;
using System.Collections.Generic;
using System.Linq;
using Administrador.RefreshPage;
using BussinessFacade.Negocio;
using Common.Data.ControlAcceso;
using Ext.Net;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class AgregarMenu : BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      //base.Page_Load(sender,e);
      if (!IsPostBack)
      {

        Array asrt = Enum.GetValues(typeof(Icon));
        for (int index = 0; index < asrt.Length; index++)
        {
          this.ResourceManager1.RegisterIcon((Icon)Enum.Parse(typeof(Icon), asrt.GetValue(index).ToString(), true));
        }
      }
    }

    protected void strCmbMenuPadre_OnReadData(object sender, StoreReadDataEventArgs e)
    {
      try
      {
        IList<co_ca_menu> listMenu = new bf_negocios().GetMenuPadre();
        listMenu.Add(new co_ca_menu { id_menu = -1, menu_nombre = "Raíz del Menú" });
        strCmbMenuPadre.DataSource = listMenu.OrderBy(c => c.id_menu);
        strCmbMenuPadre.DataBind();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void strIconos_OnReadData(object sender, StoreReadDataEventArgs e)
    {
      try
      {
        Array asrt = Enum.GetValues(typeof(Icon));
        IList<object> lista = new List<object>();
        for (int index = 0; index < asrt.Length; index++)
        {
          lista.Add(new
          {
            id = index,
            iconoCls = asrt.GetValue(index).ToString().ToLower(),
            icono = asrt.GetValue(index)
          });
        }

        strIconos.DataSource = lista;
        strIconos.DataBind();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void btnGuardar_Click(object sender, DirectEventArgs e)
    {
      try
      {

      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
  }
}