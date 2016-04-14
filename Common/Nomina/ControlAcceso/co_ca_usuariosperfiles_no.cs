using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Nomina.ControlAcceso
{
  [Serializable]
  public class co_ca_usuariosperfiles_no : SCNomina
  {
    private int _id_usuarioperfil;
    private string _uspe_descripcion;
    private SCCommonIdDescripcion _id_perfil;
    private SCCommonIdDescripcion _id_usuario;

    public co_ca_usuariosperfiles_no()
    {
      id_perfil = new SCCommonIdDescripcion();
      id_usuario = new SCCommonIdDescripcion();
    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_usuarioperfil
    {
      get { return this._id_usuarioperfil; }
      set { this._id_usuarioperfil = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String uspe_descripcion
    {
      get { return this._uspe_descripcion; }
      set { this._uspe_descripcion = value; }
    }

    [Category("DataColumn")]
    [Description("NombreId=id_perfil , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=perf_perfil, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_perfil
    {
      get { return this._id_perfil; }
      set { this._id_perfil = value; }
    }

    [Category("DataColumn")]
    [Description("NombreId=id_usuario , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=usua_consuser, SqlDbType=SqlDbType.varchar, Size=100, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_usuario
    {
      get { return this._id_usuario; }
      set { this._id_usuario = value; }
    }

  }
}

