using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_regiones : SCCommon
    {
	        private SCCommonIdDescripcion _id_pais;
        private String _regi_sigla;
        private EstadoRegistro _regi_vigente;
        private SCCommonFecha _regi_fecha_creacion;
        private String _regi_usuario_creacion;
        private SCCommonFecha _regi_fecha_modificacion;
        private String _regi_usuario_modificacion;


        public co_tg_regiones()
        {
		            id_pais = new SCCommonIdDescripcion();
            _regi_vigente = EstadoRegistro.TODOS;
            regi_fecha_creacion = new SCCommonFecha();
            regi_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_region {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String regi_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_pais , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=pais_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_pais {
            get { return this._id_pais; }
            set { this._id_pais = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=5, Null=True")]
        public String regi_sigla {
            get { return this._regi_sigla; }
            set { this._regi_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro regi_vigente {
            get { return this._regi_vigente; }
            set { this._regi_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha regi_fecha_creacion {
            get { return this._regi_fecha_creacion; }
            set { this._regi_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String regi_usuario_creacion {
            get { return this._regi_usuario_creacion; }
            set { this._regi_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha regi_fecha_modificacion {
            get { return this._regi_fecha_modificacion; }
            set { this._regi_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String regi_usuario_modificacion {
            get { return this._regi_usuario_modificacion; }
            set { this._regi_usuario_modificacion = value; }
            
        }


		
    }
}

