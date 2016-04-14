using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
    [Serializable]
    public class co_ca_usuariospasswords : SCCommon
    {
	        private SCCommonIdDescripcion _id_usuario;
        private SCCommonFecha _uspa_feccambiopass;
        private String _uspa_passwordold;
        private String _uspa_passwordnew;


        public co_ca_usuariospasswords()
        {
		            id_usuario = new SCCommonIdDescripcion();
            uspa_feccambiopass = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_usuariopassword {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String uspa_description {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_usuario , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=usua_consuser, SqlDbType=SqlDbType.varchar, Size=100, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_usuario {
            get { return this._id_usuario; }
            set { this._id_usuario = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha uspa_feccambiopass {
            get { return this._uspa_feccambiopass; }
            set { this._uspa_feccambiopass = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=20, Null=True")]
        public String uspa_passwordold {
            get { return this._uspa_passwordold; }
            set { this._uspa_passwordold = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=20, Null=True")]
        public String uspa_passwordnew {
            get { return this._uspa_passwordnew; }
            set { this._uspa_passwordnew = value; }
            
        }


		
    }
}

