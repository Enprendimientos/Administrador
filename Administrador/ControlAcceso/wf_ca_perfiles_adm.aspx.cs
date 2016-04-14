using System;
using System.Web.UI;
using BussinessFacade.ControlAcceso;
using Common.Data.ControlAcceso;
using Ext.Net;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class wf_ca_perfiles_adm : Page
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

      txt_perf_perfil.ReadOnly = true;
      chk_perf_esvigente.ReadOnly = true;
      txt_perf_descripcion.ReadOnly = true;
      num_perf_orden.ReadOnly = true;

    }

    private void CompletarValores(string k)
    {
      co_ca_perfiles obj = new bf_ca_perfiles().GetData(Convert.ToInt32(k));
      txt_perf_perfil.Text = obj.perf_perfil;
      chk_perf_esvigente.Value = Validacion.ConvertirABool(obj.perf_esvigente);
      txt_perf_descripcion.Text = obj.perf_descripcion;
      num_perf_orden.Text = obj.perf_orden.ToString();

    }

    public void click_btn_guardar(object sender, DirectEventArgs e)
    {
      try
      {

        string Tmensaje =Cadenas.REGISTRO_AGREGADO;

        //

        co_ca_perfiles obj = new co_ca_perfiles();
        if (hid_id.Text != "0")
        {
          obj = new bf_ca_perfiles().GetData(Convert.ToInt32(hid_id.Text));
          Tmensaje = Cadenas.REGISTRO_MODIFICADO;
        }
        obj.perf_perfil = txt_perf_perfil.Text;
        obj.perf_esvigente = Validacion.ConvertirAEstadosRegistros(chk_perf_esvigente.Value);
        obj.perf_descripcion = txt_perf_descripcion.Text;
        obj.perf_orden = Convert.ToInt32(num_perf_orden.Text);

        if (hid_id.Text == "0")
        {
          panelCenter.Reset();
        }

        new bf_ca_perfiles().Save(obj);

        Mensajes.Show("Mensaje",Tmensaje);
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
        new bf_ca_perfiles().Delete(Convert.ToInt32(hid_id.Text));
        Mensajes.Show("Mensaje",Cadenas.REGISTRO_ELIMINADO);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }    
  }
}