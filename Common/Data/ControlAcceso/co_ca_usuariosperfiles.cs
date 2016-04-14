using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
  [Serializable]
  public class co_ca_usuariosperfiles : SCCommon
  {
    private SCCommonIdDescripcion _id_perfil;
    private SCCommonIdDescripcion _id_usuario;

    public co_ca_usuariosperfiles()
    {
      id_perfil = new SCCommonIdDescripcion();
      id_usuario = new SCCommonIdDescripcion();
    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_usuarioperfil
    {
      get { return this.id; }
      set { this.id = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String uspe_descripcion
    {
      get { return this.descripcion; }
      set { this.descripcion = value; }
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

