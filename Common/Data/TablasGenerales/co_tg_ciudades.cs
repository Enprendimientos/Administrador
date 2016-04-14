using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_ciudades : SCCommon
    {
	        private SCCommonIdDescripcion _id_region;
        private String _ciud_sigla;
        private EstadoRegistro _ciud_vigente;
        private SCCommonFecha _ciud_fecha_creacion;
        private String _ciud_usuario_creacion;
        private SCCommonFecha _ciud_fecha_modificacion;
        private String _ciud_usuario_modificacion;


        public co_tg_ciudades()
        {
		            id_region = new SCCommonIdDescripcion();
            _ciud_vigente = EstadoRegistro.TODOS;
            ciud_fecha_creacion = new SCCommonFecha();
            ciud_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_ciudad {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String ciud_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_region , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=regi_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_region {
            get { return this._id_region; }
            set { this._id_region = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=5, Null=True")]
        public String ciud_sigla {
            get { return this._ciud_sigla; }
            set { this._ciud_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro ciud_vigente {
            get { return this._ciud_vigente; }
            set { this._ciud_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha ciud_fecha_creacion {
            get { return this._ciud_fecha_creacion; }
            set { this._ciud_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String ciud_usuario_creacion {
            get { return this._ciud_usuario_creacion; }
            set { this._ciud_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha ciud_fecha_modificacion {
            get { return this._ciud_fecha_modificacion; }
            set { this._ciud_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String ciud_usuario_modificacion {
            get { return this._ciud_usuario_modificacion; }
            set { this._ciud_usuario_modificacion = value; }
            
        }


		
    }
}
