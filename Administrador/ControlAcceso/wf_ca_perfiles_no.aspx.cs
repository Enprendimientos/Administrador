using System;
using System.Collections.Generic;
using Administrador.RefreshPage;
using BussinessFacade.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Ext.Net;
using Fwp.common;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class wf_ca_perfiles_no : BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      //base.Page_Load(sender,e);
      //Response.Write(Session.Timeout.ToString());
    }

    public void OnReadData_st_grilla(object sender, StoreReadDataEventArgs e)
    {
      try
      {

        int page = (e.Start / e.Limit) + 1;

        co_ca_perfiles_no Nomina = new co_ca_perfiles_no();

        Nomina.Pagina = page;
        Nomina.RegistrosPorPaginas = e.Limit;
        Nomina.ColumnaOrden = e.Sort[0].Property;
        Nomina.OrdenColumna = (FwpServerControls.FwpDataGridDataBound.Orden)Enum.Parse(typeof(FwpServerControls.FwpDataGridDataBound.Orden), e.Sort[0].Direction.ToString(), true);

        AgregarFiltros_st_grilla(ref Nomina);

        Nomina<co_ca_perfiles_no> data = new bf_ca_perfiles().GetNomina(Nomina);

        st_grilla.DataSource = data.DataSource;
        PageProxy pageProxy = st_grilla.Proxy[0] as PageProxy;
        if (pageProxy != null) pageProxy.Total = data.Registros;
        st_grilla.DataBind();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    public void Open_win_mantenedor(object sender, DirectEventArgs e)
    {
      try
      {

      string url = e.ExtraParams["url"];
      string command = e.ExtraParams["command"];
      string id = e.ExtraParams["Id"];
      string title = string.Empty;
      Icon icono = Icon.None;
      if (command == "Agregar")
      {
        //codigo de agregar registro
        url += "?op=in";
        icono = Icon.GroupAdd;
        title = "Agregar Perfil";
      }
      else if (command == "Modificar")
      {
        url += "?op=mo&k=" + id;
        icono = Icon.GroupEdit;
        title = "Editar Perfil";
      }
      else if (command == "Eliminar")
      {
        url += "?op=el&k=" + id;
        icono = Icon.GroupDelete;
        title = "Eliminar Perfil";
      }

      this.win_mantenedor.Html = url.GetFrameURL();
      this.win_mantenedor.Title = title;
      this.win_mantenedor.Icon = icono;
      this.win_mantenedor.Show();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    private void AgregarFiltros_st_grilla(ref co_ca_perfiles_no nomina)
    {
      nomina.perf_perfil = FiltrosNomina.ValidarFiltros<string>(nomina.perf_perfil, filtertxt_perf_perfil.Text);
      nomina.perf_esvigente = FiltrosNomina.ValidarFiltros<TiposBases.EstadoRegistro>(nomina.perf_esvigente, filterbol_perf_esvigente.SelectedItem.Value);
      nomina.perf_descripcion = FiltrosNomina.ValidarFiltros<string>(nomina.perf_descripcion, filtertxt_perf_descripcion.Text);
      nomina.perf_orden = FiltrosNomina.ValidarFiltros<int>(nomina.perf_orden, filterint_perf_orden.Text);
    }


  }
}