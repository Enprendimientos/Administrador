using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
    [Serializable]
    public class co_ca_usuarios : SCCommon
    {
	        private SCCommonIdDescripcion _id_persona;
        private EstadoRegistro _usua_esvigente;
        private SCCommonFecha _usua_ultimaconexion;
        private String _usua_password;
        private EstadoRegistro _usua_cambiopassword;
        private SCCommonFecha _usua_ultimoacceso;
        private SCCommonFecha _usua_feccambiopass;
        private SCCommonFecha _usua_fechaexpiracion;
        private int _usua_intentosfallidos;


        public co_ca_usuarios()
        {
		            id_persona = new SCCommonIdDescripcion();
            _usua_esvigente = EstadoRegistro.TODOS;
            usua_ultimaconexion = new SCCommonFecha();
            _usua_cambiopassword = EstadoRegistro.TODOS;
            usua_ultimoacceso = new SCCommonFecha();
            usua_feccambiopass = new SCCommonFecha();
            usua_fechaexpiracion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_usuario {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
        public String usua_consuser {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_persona , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=pers_nombrecompleto, SqlDbType=SqlDbType.varchar, Size=500, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_persona {
            get { return this._id_persona; }
            set { this._id_persona = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro usua_esvigente {
            get { return this._usua_esvigente; }
            set { this._usua_esvigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha usua_ultimaconexion {
            get { return this._usua_ultimaconexion; }
            set { this._usua_ultimaconexion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String usua_password {
            get { return this._usua_password; }
            set { this._usua_password = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro usua_cambiopassword {
            get { return this._usua_cambiopassword; }
            set { this._usua_cambiopassword = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha usua_ultimoacceso {
            get { return this._usua_ultimoacceso; }
            set { this._usua_ultimoacceso = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha usua_feccambiopass {
            get { return this._usua_feccambiopass; }
            set { this._usua_feccambiopass = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha usua_fechaexpiracion {
            get { return this._usua_fechaexpiracion; }
            set { this._usua_fechaexpiracion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
        public int usua_intentosfallidos {
            get { return this._usua_intentosfallidos; }
            set { this._usua_intentosfallidos = value; }
            
        }


		
    }
}

