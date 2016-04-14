using System;
using BussinessFacade.ControlAcceso;
using Common.Data.ControlAcceso;
using Ext.Net;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class wf_ca_menu_adm : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string tipo = Request.QueryString["op"];
        string id = Request.QueryString["k"];

        switch (tipo)
        {
          case "in":
            op_ingreso();
            break;
          case "mo":
            op_modificar(id);
            break;
          case "el":
            op_eliminar(id);
            break;
        }

      }
    }

    private void op_ingreso()
    {
      btn_borrar.Hide();
      hid_id.Text = "0";
    }

    private void op_modificar(string k)
    {
      btn_borrar.Hide();
      hid_id.Text = k;

      CompletarValores(k);

    }

    private void op_eliminar(string k)
    {
      btn_guardar.Hide();
      toolbar.Hide();
      hid_id.Text = k;

      CompletarValores(k);

      txt_menu_nombre.ReadOnly = true;
      txt_menu_url.ReadOnly = true;
      num_menu_ancho.ReadOnly = true;
      num_menu_alto.ReadOnly = true;
      num_menu_orden.ReadOnly = true;
      chk_menu_activo.ReadOnly = true;
      txt_menu_icono.ReadOnly = true;

    }

    private void CompletarValores(string k)
    {
      co_ca_menu obj = new bf_ca_menu().GetData(Convert.ToInt32(k));
      txt_menu_nombre.Text = obj.menu_nombre;
      txt_menu_url.Text = obj.menu_url;
      num_menu_ancho.Text = obj.menu_ancho.ToString();
      num_menu_alto.Text = obj.menu_alto.ToString();
      num_menu_orden.Text = obj.menu_orden.ToString();
      chk_menu_activo.Value = Validacion.ConvertirABool(obj.menu_activo);
      txt_menu_icono.Text = obj.menu_icono;

    }



    public void click_btn_guardar(object sender, DirectEventArgs e)
    {
      try
      {

        string Tmensaje = Cadenas.REGISTRO_AGREGADO;

        //

        co_ca_menu obj = new co_ca_menu();
        if (hid_id.Text != "0")
        {
          obj = new bf_ca_menu().GetData(Convert.ToInt32(hid_id.Text));
          Tmensaje = Cadenas.REGISTRO_MODIFICADO;
        }
        obj.menu_nombre = txt_menu_nombre.Text;
        obj.menu_url = txt_menu_url.Text;
        obj.menu_ancho = Convert.ToInt32(num_menu_ancho.Text);
        obj.menu_alto = Convert.ToInt32(num_menu_alto.Text);
        obj.menu_orden = Convert.ToInt32(num_menu_orden.Text);
        obj.menu_activo = Validacion.ConvertirAEstadosRegistros(chk_menu_activo.Value);
        obj.menu_icono = txt_menu_icono.Text;

        if (hid_id.Text == "0")
        {
          panelCenter.Reset();
        }

        new bf_ca_menu().Save(obj);

        //

        Mensajes.Show("Mensaje", Tmensaje, MessageBox.Icon.INFO);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    public void click_btn_borrar(object sender, DirectEventArgs e)
    {
      try
      {
        new bf_ca_menu().Delete(Convert.ToInt32(hid_id.Text));
        Mensajes.Show("Mensaje", Cadenas.REGISTRO_ELIMINADO, MessageBox.Icon.INFO);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
  }
}