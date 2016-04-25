using System;
using System.Collections.Generic;
using System.Linq;
using Administrador.RefreshPage;
using BussinessFacade.Negocio;
using Common.Data.ControlAcceso;
using Ext.Net;
using Utilidades;
using BussinessFacade.ControlAcceso;
using Fwp.common;

namespace Administrador.ControlAcceso
{
  public partial class AgregarMenu : BasePage
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

        Array asrt = Enum.GetValues(typeof(Icon));
        for (int index = 0; index < asrt.Length; index++)
        {
          ResourceManager1.RegisterIcon((Icon)Enum.Parse(typeof(Icon), asrt.GetValue(index).ToString(), true));
        }

        CargarCombos();
      }
    }

    #region DatosIniciales

    private void Ingreso()
    {
      btnBorrar.Hide();

    }

    private void Modificar(int id)
    {
      btnBorrar.Hide();
      CompletarValores(id);
    }

    private void Eliminar(int id)
    {
      btnGuardar.Hide();
      CompletarValores(id);
      BloquearCampos();
    }

    public void CompletarValores(int idMenu)
    {
      try
      {
        co_ca_menu menu = new bf_ca_menu().GetData(idMenu);
        txtNombreMenu.Text = menu.menu_nombre;
        cmbMenuPadre.SetValueAndFireSelect(menu.id_menupadre);
        cmbIconos.SetValueAndFireSelect(menu.menu_icono);
        txtUrl.Text = menu.menu_url;
        txtUrlReal.Text = menu.menu_urlReal;
        txtAncho.Text = menu.menu_ancho.ToString();
        txtAlto.Text = menu.menu_alto.ToString();
        txtOrden.Text = menu.menu_orden.ToString();
        chkVigente.Value = Validacion.ConvertirABool(menu.menu_activo);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    public void BloquearCampos()
    {
      txtNombreMenu.ReadOnly = true;
      cmbMenuPadre.ReadOnly = true;
      cmbIconos.ReadOnly = true;
      txtUrl.ReadOnly = true;
      txtUrlReal.ReadOnly = true;
      txtAlto.ReadOnly = true;
      txtAncho.ReadOnly = true;
      txtOrden.ReadOnly = true;
      chkVigente.ReadOnly = true;
    }
    #endregion

    #region Botones
    protected void btnGuardar_Click(object sender, DirectEventArgs e)
    {
      try
      {
        int idMenu =  hid_id.Text.ValidaEntero(hid_id.FieldLabel);
        string mensaje;
        string nombreVentana = ObtenerNombreVentana(txtNombreMenu.Text);
        co_ca_menu menu = new co_ca_menu();
        
        if(idMenu!=0){
          menu = new bf_ca_menu().GetData(idMenu);
          mensaje=Cadenas.REGISTRO_MODIFICADO;
        }else{
          mensaje = Cadenas.REGISTRO_AGREGADO;
        }
        
        menu.menu_nombre = txtNombreMenu.Text;
        menu.id_menupadre = cmbMenuPadre.SelectedItem.Value.ValidaEntero(cmbMenuPadre.FieldLabel);
        menu.menu_url = txtUrl.Text;
        menu.menu_urlReal = txtUrlReal.Text;
        menu.menu_icono = cmbIconos.SelectedItem.Value;
        menu.menu_alto = txtAlto.Text.ValidaEntero(txtAlto.FieldLabel);
        menu.menu_ancho = txtAncho.Text.ValidaEntero(txtAncho.FieldLabel);
        menu.menu_orden = txtOrden.Text.ValidaEntero
          (txtOrden.FieldLabel);
        menu.menu_activo = Validacion.ConvertirAEstadosRegistros(chkVigente.Value);
        menu.menu_nombreventana = nombreVentana;
        
        new bf_ca_menu().Save(menu);

        Mensajes.Show("Mensaje", mensaje, "CloseIframe();", MessageBox.Icon.INFO);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    protected void btnBorrar_Click(object sender, DirectEventArgs e)
    {
      //se dejara con estado vigente=false
      try
      {
        int idMenu = hid_id.Text.ValidaEntero(hid_id.FieldLabel);
        co_ca_menu menu = new bf_ca_menu().GetData(idMenu);
        menu.menu_activo = TiposBases.EstadoRegistro.DES;
        new bf_ca_menu().Save(menu);

        Mensajes.Show("Mensaje", Cadenas.REGISTRO_ELIMINADO, MessageBox.Icon.INFO);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
    #endregion
    #region Funciones
    private static string ObtenerNombreVentana(string text)
    {
      string[] cadena = text.Split(' ');
      return cadena.Aggregate(string.Empty, (current, cad) => current + cad.Substring(0, 3).ToUpper());
    }
    #endregion
    #region Combos

    private void CargarCombos()
    {
      ComboMenuPadre();
      ComboIconos();
    }
    protected void ComboMenuPadre()
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

    protected void ComboIconos()
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
    #endregion
  }
}