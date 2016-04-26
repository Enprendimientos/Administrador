using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessFacade.ControlAcceso;
using BussinessFacade.Negocio;
using Common.Data.ControlAcceso;
using Ext.Net;
using Fwp.common;
using Utilidades;
using Menu = Ext.Net.Menu;
using MenuItem = Ext.Net.MenuItem;
using Parameter = Ext.Net.Parameter;

namespace Administrador
{
  public partial class Desktop : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //string accesos = FWPConfiguration.get_Accesos(Session.SessionID);
      if (!IsPostBack && !X.IsAjaxRequest)
      {
        //if (accesos == null)
        //{
        //  Response.Redirect("Default.aspx");
        //}
        ConfigurarEscritorio();
      }
    }

    protected void ConfigurarEscritorio()
    {
      try
      {
        //Coloco el Nombre de Usuario y Nombre de la Persona Logueada
        dskPrincipal.StartMenu.Title = FWPConfiguration.get_Cons_User(Session.SessionID) + ", " +
                                       FWPConfiguration.get_Name_Person(Session.SessionID).Replace("%20", " ");
        co_ca_menu menu = new co_ca_menu();
        menu.id_perfil = FWPConfiguration.get_Perfil(Session.SessionID);
        menu.id_usuario = FWPConfiguration.get_ID_User(Session.SessionID);
        IList<co_ca_menu> listMenu = new bf_negocios().GetMenuEscritorio(menu);
        CargaMenuPadre(listMenu);
        //CargaMenuTemp(listMenu);
        CargaPerfiles(null, null);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
    protected void CargaMenuTemp(IList<co_ca_menu> listMenu)
    {
      try
      {
        foreach (co_ca_menu menu in listMenu.Where(menu => menu.id_menupadre != 0))
        {

          MenuItem hijo = new MenuItem();
          hijo.ID = "MH_" + menu.menu_nombreventana;
          hijo.IconCls = "#Application";
          hijo.Text = menu.menu_nombre;
          hijo.DestroyMenu = false;

          Parameter titulo = new Parameter("title", menu.menu_nombre);
          string strurl = menu.menu_url + "?k=" +
                       menu.id_menu + "&u=" + FWPConfiguration.get_ID_User(Session.SessionID);
          strurl = strurl + "&z=" + FWPConfiguration.get_Accesos(Session.SessionID);
          Parameter url = new Parameter("url", strurl);
          Parameter id = new Parameter("id", menu.menu_nombreventana);
          Parameter icono = new Parameter("icono", "#Application");

          hijo.DirectEvents.Click.Event += Button_WindowDesktop;
          hijo.DirectEvents.Click.ExtraParams.Add(url);
          hijo.DirectEvents.Click.ExtraParams.Add(titulo);
          hijo.DirectEvents.Click.ExtraParams.Add(icono);
          hijo.DirectEvents.Click.ExtraParams.Add(id);

          dskPrincipal.StartMenu.MenuItems.Add(hijo);
        }
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    /// <summary>
    /// Metodo Que carga el Menu Principal a partir de este menu se generan todos los demas
    /// </summary>
    /// <param name="listMenu">Lista de Menus a Cargar</param>
    protected void CargaMenuPadre(IList<co_ca_menu> listMenu)
    {
      try
      {
        //Cargo primero el MenuPadre == 0 ya que ese es siempre nuestro menu principal
        foreach (co_ca_menu menu in listMenu.Where(menu => menu.id_menupadre == 0).OrderBy(c => c.id_menupadre).OrderBy(c => c.menu_orden))
        {
          MenuItem menuPadre = new MenuItem { Text = menu.menu_nombre, IconCls = "#Application", ID = "MP_" + menu.menu_nombreventana };
          menuPadre.Menu.Add(CreaMenuHijos(menu.id_menu, listMenu));

          dskPrincipal.StartMenu.MenuItems.Add(menuPadre);
        }
      }
      catch (Exception e)
      {
        Mensajes.Error(e.Message);
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="idMenuPadre"></param>
    /// <param name="listMenu"></param>
    protected Menu CreaMenuHijos(int idMenuPadre, IList<co_ca_menu> listMenu)
    {
      try
      {
        IList<MenuItem> menusHijos = new List<MenuItem>();
        Menu menus = new Menu();

        foreach (co_ca_menu menuHijo in listMenu.Where(menusHijo => menusHijo.id_menupadre == idMenuPadre).OrderBy(c => c.menu_orden))
        {
          co_ca_menu hijo1 = menuHijo;
          IEnumerable<co_ca_menu> hijos = listMenu.Where(menHijos => menHijos.id_menupadre == hijo1.id_menu);

          MenuItem hijo;
          if (hijos.Any())
          {
            hijo = new MenuItem { Text = menuHijo.menu_nombre, IconCls = "#Application", ID = "MP_" + menuHijo.menu_nombreventana };
            hijo.Menu.Add(CreaMenuHijos(menuHijo.id_menu, listMenu));
          }
          else
          {
            hijo = new MenuItem();
            hijo.ID = "MH_" + menuHijo.menu_nombreventana;
            hijo.IconCls = "#Application";
            hijo.Text = menuHijo.menu_nombre;
            hijo.DestroyMenu = false;

            Parameter titulo = new Parameter("title", menuHijo.menu_nombre);
            string strurl = menuHijo.menu_url;

            string urltemp = "k=" + menuHijo.id_menu + "&u=" + FWPConfiguration.get_ID_User(Session.SessionID)
              + "&p=" + FWPConfiguration.get_Perfil(Session.SessionID) + "&z=" + FWPConfiguration.get_Accesos(Session.SessionID);
            if (strurl.Contains("?"))
            {
              strurl = strurl + "&" + urltemp;
            }
            else
            {
              strurl = strurl + "?" + urltemp;
            }

            Parameter url = new Parameter("url", strurl);
            Parameter id = new Parameter("id", menuHijo.menu_nombreventana);
            Parameter icono = new Parameter("icono", "#Application");

            hijo.DirectEvents.Click.Event += Button_WindowDesktop;
            hijo.DirectEvents.Click.ExtraParams.Add(url);
            hijo.DirectEvents.Click.ExtraParams.Add(titulo);
            hijo.DirectEvents.Click.ExtraParams.Add(icono);
            hijo.DirectEvents.Click.ExtraParams.Add(id);

          }
          menusHijos.Add(hijo);
        }
        menus.Items.Add(menusHijos);
        return menus;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    /// <summary>
    /// Metodo que crea todos los SubMenus(Menu Hijos), Si el Hijo a su vez tiene Hijos, tbn los crea
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void Button_WindowDesktop(object sender, DirectEventArgs args)
    {
      try
      {
        Window win = new Window();
        win.Title = args.ExtraParams["title"];
        win.Loader = new ComponentLoader(new ComponentLoader.Config { Mode = LoadMode.Frame, Url = args.ExtraParams["url"] });
        win.Maximized = false;
        win.Maximizable = true;
        win.ID = "WIN_" + args.ExtraParams["id"];
        win.IconCls = args.ExtraParams["icono"];
        win.MinWidth = 900;
        win.MinHeight = 500;

        dskPrincipal.CreateWindow(win);

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    protected void btnMiPerfil_Click(object sender, DirectEventArgs e)
    {
      throw new NotImplementedException();
    }

    protected void btnCerrarSesion_Click(object sender, DirectEventArgs e)
    {
      int idUsuario = FWPConfiguration.get_ID_User(Session.SessionID);
      co_ca_usuarios usuario = new bf_ca_usuarios().GetData(idUsuario);
      if (usuario != null)
      {
        usuario.usua_ultimaconexion.Fecha = DateTime.Now;
        new bf_ca_usuarios().Save(usuario);
      }

      FWPConfiguration.OnSessionEnd(Session.SessionID);
      Session["id_usuario"] = null;
      FWPConfiguration.OnSessionStart(Session.SessionID);

      Response.Redirect("Default.aspx");
    }
    public void menuCambiarFondo_Click(object sender, DirectEventArgs e)
    {
      Random ran = new Random();
      int fondo = ran.Next(1,12);
      dskPrincipal.DesktopConfig.Wallpaper = "Images/wallpapers/fondo" + fondo.ToString() + ".jpg";
    }

    protected void CargaPerfiles(object sender, DirectEventArgs eventArgs)
    {
      try
      {
        IList<co_ca_usuariosperfiles> up = new bf_ca_usuariosperfiles().
          GetData(new co_ca_usuariosperfiles { id_usuario = { id = FWPConfiguration.get_ID_User(Session.SessionID) } });
        co_ca_perfiles perfil = new bf_ca_perfiles().GetData(FWPConfiguration.get_Perfil(Session.SessionID));
        Menu menu = new Menu();
        foreach (co_ca_usuariosperfiles usuper in up)
        {
          CheckMenuItem item = new CheckMenuItem();
          item.Text = usuper.id_perfil.descripcion;
          item.Group = "perfil";
          item.CheckHandler = "function(item, checked) {checked && #{btnPerfil}.setText('" + usuper.id_perfil.descripcion + "');}";
          if (perfil.id_perfil == usuper.id_perfil.id)
          {
            item.Checked = true;
          }
          item.DirectEvents.Click.Event += OnCheckedChangedPerfil;
          Parameter idPerfil = new Parameter("idPerfil", usuper.id_perfil.id.ToString());
          Parameter descripcion = new Parameter("descripcion", usuper.id_perfil.descripcion);
          item.DirectEvents.Click.ExtraParams.Add(idPerfil);
          item.DirectEvents.Click.ExtraParams.Add(descripcion);
          menu.Add(item);
        }

        btnPerfil.Text = perfil.perf_descripcion;
        btnPerfil.Menu.Add(menu);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    #region DirectMethods
    [DirectMethod(Namespace = "Principal")]
    protected void OnCheckedChangedPerfil(object sender, DirectEventArgs eventArgs)
    {
      try
      {
        int idPerfil = int.TryParse(eventArgs.ExtraParams["idPerfil"], out idPerfil) ? idPerfil : 0;
        if (idPerfil == 0) return;
        FWPConfiguration.set_Perfil(Session.SessionID, idPerfil);
        Response.Redirect(Request.RawUrl);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
    #endregion
  }
}