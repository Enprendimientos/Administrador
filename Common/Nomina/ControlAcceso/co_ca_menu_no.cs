using System;
using System.ComponentModel;

namespace Common.Nomina.ControlAcceso
{
  [Serializable]
  public class co_ca_menu_no : SCNomina
  {
    private int _id_menu;
    private String _menu_nombre;
    private int _id_menupadre;
    private String _menu_nombrepadre;
    private String _menu_padre;
    private String _menu_url;
    private String _menu_opciones;
    private int _menu_ancho;
    private int _menu_alto;
    private int _menu_orden;
    private EstadoRegistro _menu_activo;
    private String _menu_nombreventana;
    private String _menu_urlReal;
    private String _menu_icono;

    public co_ca_menu_no()
    {
      _menu_activo = EstadoRegistro.TODOS;

    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_menu
    {
      get { return this._id_menu; }
      set { this._id_menu = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String menu_nombre
    {
      get { return this._menu_nombre; }
      set { this._menu_nombre = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int id_menupadre
    {
      get { return this._id_menupadre; }
      set { this._id_menupadre = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String menu_nombrepadre
    {
      get { return this._menu_nombrepadre; }
      set { this._menu_nombrepadre = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String menu_padre
    {
      get { return this._menu_padre; }
      set { this._menu_padre = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=1000, Null=True")]
    public String menu_url
    {
      get { return this._menu_url; }
      set { this._menu_url = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
    public String menu_opciones
    {
      get { return this._menu_opciones; }
      set { this._menu_opciones = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int menu_ancho
    {
      get { return this._menu_ancho; }
      set { this._menu_ancho = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int menu_alto
    {
      get { return this._menu_alto; }
      set { this._menu_alto = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int menu_orden
    {
      get { return this._menu_orden; }
      set { this._menu_orden = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
    public EstadoRegistro menu_activo
    {
      get { return this._menu_activo; }
      set { this._menu_activo = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String menu_nombreventana
    {
      get { return this._menu_nombreventana; }
      set { this._menu_nombreventana = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
    public String menu_urlReal
    {
      get { return this._menu_urlReal; }
      set { this._menu_urlReal = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
    public String menu_icono
    {
      get { return this._menu_icono; }
      set { this._menu_icono = value; }

    }


  }
}

