using System;
using System.Collections.Generic;
using System.Linq;
using Administrador.RefreshPage;
using BussinessFacade.ControlAcceso;
using BussinessFacade.Negocio;
using Common.Data.ControlAcceso;
using Ext.Net;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class AsociarPerfil :BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      //base.Page_Load(sender,e);
      //Response.Write(Session.Timeout.ToString());

      if (!IsPostBack && !X.IsAjaxRequest)
      {
        string tipo = Request.QueryString["op"];
        string id_usuario = Request.QueryString["id_usuario"];

        switch (tipo)
        {
          case "in":
            Ingreso(id_usuario);
            break;
          case "op":
            Modificar(id_usuario);
            break;
          case "el":
            Eliminar(id_usuario);
            break;
        }
      }
    }

    private void Ingreso(string idUsuario)
    {
      hid_id_usuario.Text = idUsuario;
      CompletarValores(idUsuario);
    }

    private void Modificar(string id_usuario)
    {
      hid_id_usuario.Text = id_usuario;
      CompletarValores(id_usuario);
    }

    private void Eliminar(string id_usuario)
    {
      hid_id_usuario.Text = id_usuario;
      CompletarValores(id_usuario);
    }

    private void CompletarValores(string idUsuario)
    {
      try
      {
        int id_usuario = idUsuario.ValidaEntero("id_usuario");
        CompletarValoresDisponibles(id_usuario);
        CompletarValoresAsociados(id_usuario);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    private void CompletarValoresDisponibles(int id_usuario)
    {
      IList<co_ca_asociarperfiles> listPerfiles = new bf_negocios().GetPerfilesDisponibles(new co_ca_asociarperfiles() { id_usuario = id_usuario });
      strPerfilesDisponibles.DataSource = listPerfiles;
      strPerfilesDisponibles.DataBind();
    }

    private void CompletarValoresAsociados(int id_usuario)
    {
      IList<co_ca_asociarperfiles> listPerfiles = new bf_negocios().GetPerfilesAsociados(new co_ca_asociarperfiles() { id_usuario = id_usuario });
      strPerfilesAsociados.DataSource = listPerfiles;
      strPerfilesAsociados.DataBind();
    }

    protected void Drop(object sender, DirectEventArgs e)
    {
      string jsonArray = e.ExtraParams["records"];
      string mode = e.ExtraParams.GetParameter("mode").Value;
      List<object> records = JSON.Deserialize<List<object>>(jsonArray);
      int cont = 0;
      string message = "";
      foreach (dynamic record in records)
      {
        string idPerfil = (string)record.id_perfil;
        int id_perfil = idPerfil.ValidaEntero("id_perfil");
        if (mode == "asocia")
        {
          cont = Asocia(id_perfil);
          message = cont == 1 ? " Perfil Asociado" : " Perfil Asociados";
        }
        else
        {
          cont = Desasocia(id_perfil);
          message = cont == 1 ? " Perfil Desasociado" : " Perfil Desasociados";
        }
      }
      Notification.Show(new NotificationConfig { Title = "Notificación", Html = cont + message });
    }

    private int Asocia(int idPerfil)
    {
      try
      {
        int id_usuario = hid_id_usuario.Text.ValidaEntero(hid_id_usuario.FieldLabel);
        co_ca_usuariosperfiles usuariosperfiles = new co_ca_usuariosperfiles();
        usuariosperfiles.id_perfil.id = idPerfil;
        usuariosperfiles.id_usuario.id = id_usuario;

        new bf_ca_usuariosperfiles().Save(usuariosperfiles);
        return 1;

      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
        return 0;
      }
    }

    private int Desasocia(int id_perfil)
    {
      int ret = 0;
      try
      {
        int id_usuario = hid_id_usuario.Text.ValidaEntero(hid_id_usuario.FieldLabel);
        co_ca_usuariosperfiles usuariosperfiles = new co_ca_usuariosperfiles();
        usuariosperfiles.id_perfil.id = id_perfil;
        usuariosperfiles.id_usuario.id = id_usuario;

        var list = new bf_ca_usuariosperfiles().GetData(usuariosperfiles);
        if (list.Any() && list.Count() == 1)
        {
          co_ca_usuariosperfiles coCaUsuariosperfiles = list.FirstOrDefault();
          if (coCaUsuariosperfiles != null)
          {
            new bf_ca_usuariosperfiles().Delete(coCaUsuariosperfiles.id_usuarioperfil);
            ret = 1;
          }
        }
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
        ret = 0;
      }
      return ret;
    }
  }
}