using System;
using System.Collections.Generic;
using System.Linq;
using Administrador.RefreshPage;
using BussinessFacade.ControlAcceso;
using BussinessFacade.Negocio;
using Common.Nomina.ControlAcceso;
using Common.Nomina.Negocio;
using Ext.Net;
using Fwp.common;
using FwpServerControls;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class NominaPersonas : BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      //base.Page_Load(sender,e);
      //Response.Write(Session.Timeout.ToString());
    }
    
    protected void strGrilla_OnReadData(object sender, StoreReadDataEventArgs e)
    {
      try
      {
        int start = e.Start;
        int limit = NumInt.Init(e.Parameters.GetParameter("limit").Value);
        limit = limit == 0 ? e.Limit : limit;
        int page = (start / limit) + 1;

        co_tg_personas_no2 Nomina = new co_tg_personas_no2();
        Nomina.Pagina = page;
        Nomina.RegistrosPorPaginas = limit;
        Nomina.ColumnaOrden = e.Sort[0].Property;
        Nomina.OrdenColumna = (FwpDataGridDataBound.Orden)
          Enum.Parse(typeof(FwpDataGridDataBound.Orden), e.Sort[0].Direction.ToString(), true);

        Nomina<co_tg_personas_no2> data = new bf_negocios().GetNominaPersonas(Nomina);

        IList<object> lista = new List<object>();

        if (data.DataSource.Any())
        {
          foreach (co_tg_personas_no2 p in data.DataSource)
          {
            lista.Add(new
            {
              id_persona = p.id_persona,
              pers_apmaterno = p.pers_apmaterno,
              pers_appaterno = p.pers_appaterno,
              pers_celular = p.pers_celular,
              pers_email = p.pers_email,
              pers_fecha_creacion = p.pers_fecha_creacion.Fecha,
              pers_fecha_modificacion = p.pers_fecha_modificacion.Fecha,
              pers_nacionalidad = p.pers_nacionalidad,
              pers_nombrecompleto = p.pers_nombrecompleto,
              pers_nombres = p.pers_nombres,
              pers_rut = p.pers_rut,
              pers_telefono = p.pers_telefono,
              pers_usuario_creacion = p.pers_usuario_creacion,
              pers_usuario_modificacion = p.pers_usuario_modificacion,
              pers_vigente = Validacion.ConvertirABool(p.pers_vigente),
              id_comuna = p.id_comuna.id,
              comu_nombre = p.id_comuna.descripcion,
              id_estado_civil = p.id_estado_civil.id,
              esci_nombre = p.id_estado_civil.descripcion,
              id_sexo = p.id_sexo.id,
              sexo_nombre = p.id_sexo.descripcion,
              id_usuario = p.id_usuario,
              usua_consuser = p.usua_consuser,
              usua_ultimaconexion = p.usua_ultimaconexion.Fecha,
              usua_esvigente = Validacion.ConvertirABool(p.usua_esvigente)
            });
          }

          strGrilla.DataSource = lista;
          strGrilla.PageSize = limit;
          PageProxy pageProxy = strGrilla.Proxy[0] as PageProxy;
          if (pageProxy != null) pageProxy.Total = data.Registros;
          strGrilla.DataBind();
        }


      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void OpenWindow_OnEvent(object sender, DirectEventArgs e)
    {
      try
      {
        string url = "AgregarPersona.aspx";
        string command = e.ExtraParams["command"];
        string id = e.ExtraParams["id"];
        string title = string.Empty;
        Icon icono = Icon.None;

        switch (command)
        {
          case "Agregar":
            title = "Agregar Persona";
            icono = Icon.UserAdd;
            url += "?op=in";
            break;
          case "Modificar":
            title = "Editar Persona";
            icono = Icon.UserEdit;
            url += "?op=mo&k=" + id;
            break;
          case "Eliminar":
            title = "Eliminar Persona";
            icono = Icon.UserDelete;
            url += "?op=el&k=" + id;
            break;
        }

        this.winMantenedor.Html = url.GetFrameURL();
        this.winMantenedor.Title = title;
        this.winMantenedor.Icon = icono;
        this.winMantenedor.Show();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void strPerfiles_OnReadData(object sender, StoreReadDataEventArgs e)
    {
      try
      {
        int start = e.Start;
        int limit = NumInt.Init(e.Parameters.GetParameter("limit").Value);
        limit = limit == 0 ? e.Limit : limit;
        int page = (start / limit) + 1;

        int id_usuario = NumInt.Init(e.Parameters["id_usuario"]);

        co_ca_usuariosperfiles_no Nomina = new co_ca_usuariosperfiles_no();
        Nomina.Pagina = page;
        Nomina.RegistrosPorPaginas = limit;
        Nomina.ColumnaOrden = e.Sort[0].Property;
        Nomina.OrdenColumna = (FwpDataGridDataBound.Orden)
          Enum.Parse(typeof(FwpDataGridDataBound.Orden), e.Sort[0].Direction.ToString(), true);
        Nomina.id_usuario.id = id_usuario;

        Nomina<co_ca_usuariosperfiles_no> data = new bf_ca_usuariosperfiles().GetNomina(Nomina);

        strPerfiles.DataSource = data.DataSource;
        strPerfiles.PageSize = limit;
        PageProxy pageProxy = strPerfiles.Proxy[0] as PageProxy;
        if (pageProxy != null) pageProxy.Total = data.Registros;
        strPerfiles.DataBind();
        btnAgregarPerfil.Disabled = false;

      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void OpenWinMantenedorPerfiles(object sender, DirectEventArgs e)
    {
      try
      {
        string url = "AsociarPerfil.aspx";
        string command = e.ExtraParams["command"];
        string id_usuario = e.ExtraParams["id_usuario"];
        string title = string.Empty;
        Icon icono = Icon.None;

        switch (command)
        {
          case "Agregar":
            title = "Agregar Perfil";
            icono = Icon.GroupAdd;
            url += "?op=in&id_usuario=" + id_usuario;
            break;
          case "Modificar":
            title = "Editar Perfil";
            icono = Icon.GroupEdit;
            url += "?op=mo&id_usuario=" + id_usuario;
            break;
          case "Eliminar":
            title = "Eliminar Perfil";
            icono = Icon.GroupDelete;
            url += "?op=el&id_usuario=" + id_usuario;
            break;
        }


        this.winMantenedorPerfiles.Html = url.GetFrameURL();
        this.winMantenedorPerfiles.Title = title;
        this.winMantenedorPerfiles.Icon = icono;
        this.winMantenedorPerfiles.Show();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }

    }
  }
}