using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using BussinessFacade.ControlAcceso;
using Common.Data.ControlAcceso;
using Ext.Net;
using Fwp.common;
using Fwp.SystemFramework;
using Utilidades;

namespace Administrador
{
  public partial class Default : Page
  {

    public const int INTENTOS_FALLIDOS = 5;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack && X.IsAjaxRequest)
      {
        string accesos = FWPConfiguration.get_Accesos(Session.SessionID);

        if (accesos != null)
        {
          Response.Redirect("Desktop.aspx");
        }
      }
    }

    protected void btnIngresar_Click(object sender, DirectEventArgs e)
    {
      try
      {
        Security sec = new Security();
        co_ca_usuarios usuario = new co_ca_usuarios();
        usuario.usua_consuser = txtUsuario.Text;
        usuario.usua_password = sec.Encrypt(txtClave.Text);

        IList<co_ca_usuarios>usuariosList= new bf_ca_usuarios().GetData(usuario);
        if (usuariosList != null && usuariosList.Any() && usuariosList.Count == 1)
        {
          usuario = usuariosList.FirstOrDefault();
          Session["id_usuario"] = usuario.id_usuario;
          FWPConfiguration.set_Cons_User(Session.SessionID, usuario.usua_consuser);
          FWPConfiguration.set_ID_User(Session.SessionID, usuario.id_usuario);
          FWPConfiguration.set_Perfil(Session.SessionID, cmbPerfil.SelectedItem.Value.ValidaEntero(cmbPerfil.FieldLabel));
          FWPConfiguration.set_ID_Person(Session.SessionID, usuario.id_persona.id);
          FWPConfiguration.set_Name_Person(Session.SessionID, usuario.id_persona.descripcion);
          //FWPConfiguration.set_Accesos(Session.SessionID, accesos);

          usuario.usua_ultimaconexion.Fecha = DateTime.Now;
          usuario.usua_intentosfallidos = 0;

          new bf_ca_usuarios().Save(usuario);
          if (usuario.usua_cambiopassword == TiposBases.EstadoRegistro.ACT)
          {
            Mensajes.Show("Mensaje", "La clave ingresada es una Clave Temporal, debe ingresar una nueva Clave",
              "window.location.href='CambiarContrasena.aspx'", MessageBox.Icon.INFO);
          }
          else
          {
            Response.Redirect("Desktop.aspx");
          }
        }
        else
        {
          Mensajes.Error(Cadenas.LOGUEO_INCORRECTO);
          //veo si ingreso bien el usuario para asi contar los intentos fallidos 
          var user = new bf_ca_usuarios().GetData(new co_ca_usuarios { usua_consuser = txtUsuario.Text });
          if (user.Any())
          {
            var coCaUsuarios = user.FirstOrDefault();
            if (coCaUsuarios != null)
            {
              coCaUsuarios.usua_intentosfallidos = coCaUsuarios.usua_intentosfallidos + 1;
              coCaUsuarios.usua_cambiopassword=TiposBases.EstadoRegistro.ACT;
              if (coCaUsuarios.usua_intentosfallidos <= INTENTOS_FALLIDOS)
              {
                Mensajes.Error(Cadenas.EXCEDIO_INTENTOS_FALLIDOS);
                coCaUsuarios.usua_esvigente = TiposBases.EstadoRegistro.DES;
              }
              new bf_ca_usuarios().Save(coCaUsuarios);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void txtUsuario_Blur(object sender, DirectEventArgs e)
    {
      try
      {
        if (!string.IsNullOrEmpty(txtUsuario.Text))
        {
          co_ca_usuarios usuario = new co_ca_usuarios();
          usuario.usua_consuser = txtUsuario.Text;

          IList<co_ca_usuarios> usuariosList = new bf_ca_usuarios().GetData(usuario);
          if (usuariosList.Any() && usuariosList.Count == 1)
          {
            CargarPerfiles(usuario.id_usuario);
          }
        }
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    #region Funciones

    private void CargarPerfiles(int idUsuario)
    {
      try
      {
        IList<co_ca_usuariosperfiles> usuariosperfiles = new bf_ca_usuariosperfiles().GetData(new co_ca_usuariosperfiles { id_usuario = { id = idUsuario } });
        cmbPerfil.GetStore().DataSource = usuariosperfiles;
        cmbPerfil.GetStore().DataBind();
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
    #endregion
  }
}