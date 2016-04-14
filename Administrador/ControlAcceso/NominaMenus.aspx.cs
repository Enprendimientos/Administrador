using System;
using System.Collections.Generic;
using System.Linq;
using Administrador.RefreshPage;
using BussinessFacade.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Ext.Net;
using Fwp.common;
using FwpServerControls;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class NominaMenus :BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      //base.Page_Load(sender,e);
      if (!IsPostBack)
      {
        CargarMenuPadre();
      }
    }

    private void CargarMenuPadre()
    {
      Node root = new Node{Text = "Menus"};
      treeMenu.Root.Add(root);
      IList<co_ca_menu> ListMenu = new bf_ca_menu().GetData(new co_ca_menu{id_menupadre = -1});
      if (ListMenu.Any())
      {
        foreach (co_ca_menu menuPadre in ListMenu)
        {
          IList<co_ca_menu> ListMenuHijos = new bf_ca_menu().GetData(new co_ca_menu { id_menupadre = menuPadre.id_menu });
          if (ListMenuHijos.Any())
          {
            Node nodeMenuPadre = new Node { Text = menuPadre.menu_nombre, IconCls = "#"+menuPadre.menu_icono };
            root.Children.Add(nodeMenuPadre);
            CreaMenuHijo(menuPadre.id_menu, nodeMenuPadre);
          }
        }
      }
    }

    private void CreaMenuHijo(int id_menu, Node MenuPadre)
    {
      IList<co_ca_menu> ListMenuHijos = new bf_ca_menu().GetData(new co_ca_menu { id_menupadre = id_menu });
      if (ListMenuHijos.Any())
      {
        foreach (co_ca_menu hijo in ListMenuHijos)
        {
          Node nodeMenuHijo = new Node { Text = hijo.menu_nombre, IconCls = "#"+ hijo.menu_icono };
          MenuPadre.Children.Add(nodeMenuHijo);
          IList<co_ca_menu> ListMenuHijoHijo = new bf_ca_menu().GetData(new co_ca_menu { id_menupadre = hijo.id_menu });
          if (ListMenuHijoHijo.Any())
          {
            CreaMenuHijo(hijo.id_menu, nodeMenuHijo);
          }
          else
          {
            nodeMenuHijo.Leaf = true;
          }
         
        }
      }
    }

    public void OnReadData_st_grilla(object sender, StoreReadDataEventArgs e)
    {
      int start = e.Start;
      int limit = NumInt.Init(e.Parameters.GetParameter("limit").Value);
      limit = limit == 0 ? e.Limit : limit;
      int page = (start / limit) + 1;

      co_ca_menu_no Nomina = new co_ca_menu_no();

      Nomina.Pagina = page;
      Nomina.RegistrosPorPaginas = limit;
      Nomina.ColumnaOrden = e.Sort[0].Property;
      Nomina.OrdenColumna = (FwpDataGridDataBound.Orden)
        Enum.Parse(typeof(FwpDataGridDataBound.Orden), e.Sort[0].Direction.ToString(), true);

      IList<object> lista = new List<object>();

      AgregarFiltros_st_grilla(ref Nomina);

      Nomina<co_ca_menu_no> data = new bf_ca_menu().GetNomina(Nomina);

      foreach (co_ca_menu_no n in data.DataSource)
      {
        lista.Add(
            new
            {
              id_menu = n.id_menu,
              menu_nombre = n.menu_nombre,
              id_menupadre = n.id_menupadre,
              menu_nombrepadre= n.menu_nombrepadre,
              menu_url = n.menu_url,
              menu_opciones = n.menu_opciones,
              menu_ancho = n.menu_ancho,
              menu_alto = n.menu_alto,
              menu_orden = n.menu_orden,
              menu_activo = n.menu_activo,
              menu_nombreventana = n.menu_nombreventana,
              menu_urlReal = n.menu_urlReal,
              menu_icono = n.menu_icono,

            });
      }

      st_grilla.DataSource = lista;
      st_grilla.PageSize = limit;
      PageProxy pageProxy = st_grilla.Proxy[0] as PageProxy;
      if (pageProxy != null) pageProxy.Total = data.Registros;
      st_grilla.DataBind();
    }

    private void AgregarFiltros_st_grilla(ref co_ca_menu_no nomina)
    {
      nomina.menu_nombre = FiltrosNomina.ValidarFiltros<string>(nomina.menu_nombre, filtertxt_menu_nombre.Text);
      nomina.id_menupadre = FiltrosNomina.ValidarFiltros<int>(nomina.id_menupadre, filterint_id_menupadre.Text);
      nomina.menu_url = FiltrosNomina.ValidarFiltros<string>(nomina.menu_url, filtertxt_menu_url.Text);
      nomina.menu_orden = FiltrosNomina.ValidarFiltros<int>(nomina.menu_orden, filterint_menu_orden.Text);
      nomina.menu_activo = FiltrosNomina.ValidarFiltros<TiposBases.EstadoRegistro>(nomina.menu_activo, filterbol_menu_activo.SelectedItem.Value);
      nomina.menu_nombreventana = FiltrosNomina.ValidarFiltros<string>(nomina.menu_nombreventana, filtertxt_menu_nombreventana.Text);
      nomina.menu_urlReal = FiltrosNomina.ValidarFiltros<string>(nomina.menu_urlReal, filtertxt_menu_urlReal.Text);
      nomina.menu_icono = FiltrosNomina.ValidarFiltros<string>(nomina.menu_icono, filtertxt_menu_icono.Text);
    }

    public void Open_win_mantenedor(object sender, DirectEventArgs e)
    {
      string url = "";
      string command = e.ExtraParams["command"];
      string id = e.ExtraParams["Id"];
      string titulo = String.Empty;
      Icon icono = Icon.None;
      switch (command)
      {
        case "AgregarMenuPadre":
          url += "AgregarMenuPadre.aspx?op=in";
          icono = Icon.Add;
          titulo = "Agregar Menú Padre";
          break;
        case "AgregarMenu":
          url += "AgregarMenu.aspx?op=in";
          icono = Icon.Add;
          titulo = "Agregar Menú";
          break;
        case "Modificar":
          url += "?op=mo&k=" + id;
          icono = Icon.Pencil;
          titulo = "Modificar Menú";
          break;
        case "Eliminar":
          url += "?op=el&k=" + id;
          icono = Icon.Delete;
          titulo = "Eliminar Menú";
          break;
      }

      this.win_mantenedor.Html = url.GetFrameURL();
      this.win_mantenedor.Title = titulo;
      this.win_mantenedor.Icon = icono;
      this.win_mantenedor.Show();
    }
    
  }
}