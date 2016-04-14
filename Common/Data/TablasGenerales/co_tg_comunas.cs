using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_comunas : SCCommon
    {
	        private SCCommonIdDescripcion _id_ciudad;
        private String _comu_sigla;
        private EstadoRegistro _comu_vigente;
        private SCCommonFecha _comu_fecha_creacion;
        private String _comu_usuario_creacion;
        private SCCommonFecha _comu_fecha_modificacion;
        private String _comu_usuario_modificacion;


        public co_tg_comunas()
        {
		            id_ciudad = new SCCommonIdDescripcion();
            _comu_vigente = EstadoRegistro.TODOS;
            comu_fecha_creacion = new SCCommonFecha();
            comu_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_comuna {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String comu_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_ciudad , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=ciud_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_ciudad {
            get { return this._id_ciudad; }
            set { this._id_ciudad = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=5, Null=True")]
        public String comu_sigla {
            get { return this._comu_sigla; }
            set { this._comu_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro comu_vigente {
            get { return this._comu_vigente; }
            set { this._comu_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha comu_fecha_creacion {
            get { return this._comu_fecha_creacion; }
            set { this._comu_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String comu_usuario_creacion {
            get { return this._comu_usuario_creacion; }
            set { this._comu_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha comu_fecha_modificacion {
            get { return this._comu_fecha_modificacion; }
            set { this._comu_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String comu_usuario_modificacion {
            get { return this._comu_usuario_modificacion; }
            set { this._comu_usuario_modificacion = value; }
            
        }


		
    }
}

