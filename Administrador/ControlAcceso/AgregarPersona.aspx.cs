using System;
using Administrador.RefreshPage;
using BussinessFacade.ControlAcceso;
using BussinessFacade.Negocio;
using BussinessFacade.TablasGenerales;
using Common.Data.ControlAcceso;
using Common.Data.TablasGenerales;
using Ext.Net;
using Fwp.SystemFramework;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class AgregarPersona : BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      //base.Page_Load(sender,e);
      if (!IsPostBack && !X.IsAjaxRequest)
      {
        string tipo = Request.QueryString["op"];
        int id = NumInt.Init(Request.QueryString["k"]);
        hid_id.Text = id.ToString();

        switch (tipo)
        {
          case "in":
            Ingreso();
            break;
          case "mo":
            Modificar(id);
            break;
          case "el":
            Eliminar(id);
            break;
        }
      }
    }

    private void Ingreso()
    {
      btnEliminar.Hide();
    }

    private void Modificar(int id)
    {
      try
      {
        btnEliminar.Hide();
        CompletarValores(id);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    private void Eliminar(int id)
    {
      btnGuardar.Hide();
      CompletarValores(id);
      BloquearCampos();
    }

    private void CompletarValores(int id)
    {
      try
      {
        co_ca_usuarios usuario = new bf_ca_usuarios().GetData(id);
        co_tg_personas persona = new bf_tg_personas().GetData(usuario.id_persona.id);
        Security sec = new Security();

        txtNombres.Text = persona.pers_nombres;
        txtPaterno.Text = persona.pers_appaterno;
        txtMaterno.Text = persona.pers_apmaterno;
        txtEmail.Text = persona.pers_email;
        txtTelefono.Text = persona.pers_telefono;

        txtUsuario.Text = usuario.usua_consuser;
        txtClave.Text= sec.Decrypt(usuario.usua_password);
        txtRepiteClave.Text = sec.Decrypt(usuario.usua_password);
        txtVigente.Value = Validacion.ConvertirABool(usuario.usua_esvigente);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    private void BloquearCampos()
    {
      txtNombres.ReadOnly = true;
      txtPaterno.ReadOnly = true;
      txtMaterno.ReadOnly = true;
      txtEmail.ReadOnly = true;
      txtTelefono.ReadOnly = true;
      txtUsuario.ReadOnly = true;
      txtClave.ReadOnly = true;
      txtRepiteClave.ReadOnly = true; 
      txtVigente.ReadOnly = true;
    }
    protected void btnGuardar_Click(object sender, DirectEventArgs e)
    {
      try
      {
        int idUsuario = NumInt.Init(hid_id.Text);

        co_tg_personas persona = new co_tg_personas();
        co_ca_usuarios usuario = new co_ca_usuarios();
        String mensaje;

        if (idUsuario!=0)
        {
          usuario = new bf_ca_usuarios().GetData(idUsuario);
          persona = new bf_tg_personas().GetData(usuario.id_persona.id);
          mensaje = Cadenas.REGISTRO_MODIFICADO;
        }
        else
        {
          mensaje = Cadenas.REGISTRO_AGREGADO;
        }

        persona.pers_nombres = txtNombres.Text;
        persona.pers_appaterno = txtPaterno.Text;
        persona.pers_apmaterno = txtMaterno.Text;
        persona.pers_email = txtEmail.Text;
        persona.pers_telefono = txtTelefono.Text;
        persona.pers_vigente = Validacion.ConvertirAEstadosRegistros(txtVigente.Value);
        persona.pers_nombrecompleto = txtNombres.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;

        usuario.usua_consuser = txtUsuario.Text;
        usuario.usua_password = txtClave.Text;
        usuario.usua_esvigente = Validacion.ConvertirAEstadosRegistros(txtVigente.Value);

        new bf_negocios().Save(persona,usuario);
        Mensajes.Show("Mensaje", mensaje, "CloseIframe()",MessageBox.Icon.INFO);
      }
      catch (Exception ex)
      {
        Mensajes.Error( ex.Message);
      }
    }

    public void btnBorrar_Click(object sender, DirectEventArgs e)
    {
      try
      {
        co_ca_usuarios usuario = new bf_ca_usuarios().GetData(Convert.ToInt32(hid_id.Text));
        co_tg_personas persona = new bf_tg_personas().GetData(usuario.id_persona.id);
        Security sec = new Security();

        usuario.usua_password = sec.Decrypt(usuario.usua_password);
        usuario.usua_esvigente = Validacion.ConvertirAEstadosRegistros(false);
        persona.pers_vigente = Validacion.ConvertirAEstadosRegistros(false);

        new bf_negocios().Save(persona,usuario);

        Mensajes.Show("Mensaje", Cadenas.REGISTRO_ELIMINADO, "CloseIframe()", MessageBox.Icon.INFO);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
  }
}