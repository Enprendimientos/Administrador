using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Nomina.ControlAcceso
{
  [Serializable]
  public class co_ca_perfilesopciones_no : SCNomina
  {
    private int _id_perfilopcion;
    private string _peop_descripcion;
    private SCCommonIdDescripcion _id_perfil;
    private SCCommonIdDescripcion _id_opcion;


    public co_ca_perfilesopciones_no()
    {
      id_perfil = new SCCommonIdDescripcion();
      id_opcion = new SCCommonIdDescripcion();

    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_perfilopcion
    {
      get { return this._id_perfilopcion; }
      set { this._id_perfilopcion = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String peop_descripcion
    {
      get { return this._peop_descripcion; }
      set { this._peop_descripcion = value; }

    }

    [Category("DataColumn")]
    [Description("NombreId=id_perfil , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=perf_perfil, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_perfil
    {
      get { return this._id_perfil; }
      set { this._id_perfil = value; }

    }

    [Category("DataColumn")]
    [Description("NombreId=id_opcion , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=opci_opcion, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_opcion
    {
      get { return this._id_opcion; }
      set { this._id_opcion = value; }

    }


  }
}

