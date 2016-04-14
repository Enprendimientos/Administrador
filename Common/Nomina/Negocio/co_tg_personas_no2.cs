using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Nomina.Negocio
{
  [Serializable]
  public class co_tg_personas_no2 : SCNomina
  {
    private SCCommonIdDescripcion _id_sexo;
    private SCCommonIdDescripcion _id_estado_civil;
    private SCCommonIdDescripcion _id_comuna;
    private int _id_persona;
    private String _pers_nombrecompleto;
    private String _pers_nombres;
    private String _pers_appaterno;
    private String _pers_apmaterno;
    private String _pers_rut;
    private String _pers_nacionalidad;
    private String _pers_telefono;
    private String _pers_celular;
    private String _pers_email;
    private SCCommonFecha _pers_fecha_creacion;
    private String _pers_usuario_creacion;
    private SCCommonFecha _pers_fecha_modificacion;
    private String _pers_usuario_modificacion;
    private EstadoRegistro _pers_vigente;
    private int _id_usuario;
    private String _usua_consuser;
    private EstadoRegistro _usua_esvigente;
    private SCCommonFecha _usua_ultimaconexion;

    public co_tg_personas_no2()
    {
      id_sexo = new SCCommonIdDescripcion();
      id_estado_civil = new SCCommonIdDescripcion();
      id_comuna = new SCCommonIdDescripcion();
      pers_fecha_creacion = new SCCommonFecha();
      pers_fecha_modificacion = new SCCommonFecha();
      _pers_vigente = EstadoRegistro.TODOS;
      _usua_esvigente = EstadoRegistro.TODOS;
      usua_ultimaconexion = new SCCommonFecha();
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_persona
    {
      get { return this._id_persona; }
      set { this._id_persona = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=500, Null=True")]
    public String pers_nombrecompleto
    {
      get { return this._pers_nombrecompleto; }
      set { this._pers_nombrecompleto = value; }

    }

    [Category("DataColumn")]
    [Description("NombreId=id_sexo , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=sexo_nombre, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_sexo
    {
      get { return this._id_sexo; }
      set { this._id_sexo = value; }

    }

    [Category("DataColumn")]
    [Description("NombreId=id_estado_civil , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=esci_nombre, SqlDbType=SqlDbType.varchar, Size=1024, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_estado_civil
    {
      get { return this._id_estado_civil; }
      set { this._id_estado_civil = value; }

    }

    [Category("DataColumn")]
    [Description("NombreId=id_comuna , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=comu_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
    public SCCommonIdDescripcion id_comuna
    {
      get { return this._id_comuna; }
      set { this._id_comuna = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=70, Null=True")]
    public String pers_nombres
    {
      get { return this._pers_nombres; }
      set { this._pers_nombres = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=25, Null=True")]
    public String pers_appaterno
    {
      get { return this._pers_appaterno; }
      set { this._pers_appaterno = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=20, Null=True")]
    public String pers_apmaterno
    {
      get { return this._pers_apmaterno; }
      set { this._pers_apmaterno = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=10, Null=True")]
    public String pers_rut
    {
      get { return this._pers_rut; }
      set { this._pers_rut = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=20, Null=True")]
    public String pers_nacionalidad
    {
      get { return this._pers_nacionalidad; }
      set { this._pers_nacionalidad = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=20, Null=True")]
    public String pers_telefono
    {
      get { return this._pers_telefono; }
      set { this._pers_telefono = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=20, Null=True")]
    public String pers_celular
    {
      get { return this._pers_celular; }
      set { this._pers_celular = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
    public String pers_email
    {
      get { return this._pers_email; }
      set { this._pers_email = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
    public SCCommonFecha pers_fecha_creacion
    {
      get { return this._pers_fecha_creacion; }
      set { this._pers_fecha_creacion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String pers_usuario_creacion
    {
      get { return this._pers_usuario_creacion; }
      set { this._pers_usuario_creacion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
    public SCCommonFecha pers_fecha_modificacion
    {
      get { return this._pers_fecha_modificacion; }
      set { this._pers_fecha_modificacion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String pers_usuario_modificacion
    {
      get { return this._pers_usuario_modificacion; }
      set { this._pers_usuario_modificacion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
    public EstadoRegistro pers_vigente
    {
      get { return this._pers_vigente; }
      set { this._pers_vigente = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_usuario
    {
      get { return this._id_usuario; }
      set { this._id_usuario = value; }
    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
    public String usua_consuser
    {
      get { return this._usua_consuser; }
      set { this._usua_consuser = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
    public SCCommonFecha usua_ultimaconexion
    {
      get { return this._usua_ultimaconexion; }
      set { this._usua_ultimaconexion = value; }

    }

    [Category("DataColumn")]
    [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
    public EstadoRegistro usua_esvigente
    {
      get { return this._usua_esvigente; }
      set { this._usua_esvigente = value; }
    }

  }
}
