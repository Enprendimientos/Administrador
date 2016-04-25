using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
  [Serializable]
  public class co_ca_menu : SCCommon
  {
    private int _id_menupadre;
    private String _menu_url;
    private String _menu_opciones;
    private int _menu_ancho;
    private int _menu_alto;
    private int _menu_orden;
    private EstadoRegistro _menu_activo;
    private String _menu_nombreventana;
    private String _menu_urlReal;
    private String _menu_icono;
    private int _id_perfil;
    private int _id_usuario;


    public co_ca_menu()
    {
      _menu_activo = EstadoRegistro.TODOS;

    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_menu
    {
      get { return this.id; }
      set { this.id = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String menu_nombre
    {
      get { return this.descripcion; }
      set { this.descripcion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int id_menupadre
    {
      get { return this._id_menupadre; }
      set { this._id_menupadre = value; }

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

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int id_usuario {
      get { return this._id_usuario; }
      set { this._id_usuario = value; }
    }
    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int id_perfil {
      get { return this._id_perfil; }
      set { this._id_perfil = value; }
    }
  }
}

