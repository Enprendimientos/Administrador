using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
  [Serializable]
  public class co_ca_perfiles : SCCommon
  {
    private EstadoRegistro _perf_esvigente;
    private String _perf_descripcion;
    private int _perf_orden;


    public co_ca_perfiles()
    {
      _perf_esvigente = EstadoRegistro.TODOS;
    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_perfil
    {
      get { return this.id; }
      set { this.id = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String perf_perfil
    {
      get { return this.descripcion; }
      set { this.descripcion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
    public EstadoRegistro perf_esvigente
    {
      get { return this._perf_esvigente; }
      set { this._perf_esvigente = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=500, Null=True")]
    public String perf_descripcion
    {
      get { return this._perf_descripcion; }
      set { this._perf_descripcion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
    public int perf_orden
    {
      get { return this._perf_orden; }
      set { this._perf_orden = value; }

    }



  }
}

