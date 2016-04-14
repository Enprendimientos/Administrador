using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_tipos_cuentas : SCCommon
    {
	        private String _ticu_sigla;
        private EstadoRegistro _ticu_vigente;
        private SCCommonFecha _ticu_fecha_creacion;
        private String _ticu_usuario_creacion;
        private SCCommonFecha _ticu_fecha_modificacion;
        private String _ticu_usuario_modificacion;


        public co_tg_tipos_cuentas()
        {
		            _ticu_vigente = EstadoRegistro.TODOS;
            ticu_fecha_creacion = new SCCommonFecha();
            ticu_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_tipo_cuenta {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String ticu_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=5, Null=True")]
        public String ticu_sigla {
            get { return this._ticu_sigla; }
            set { this._ticu_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro ticu_vigente {
            get { return this._ticu_vigente; }
            set { this._ticu_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha ticu_fecha_creacion {
            get { return this._ticu_fecha_creacion; }
            set { this._ticu_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String ticu_usuario_creacion {
            get { return this._ticu_usuario_creacion; }
            set { this._ticu_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha ticu_fecha_modificacion {
            get { return this._ticu_fecha_modificacion; }
            set { this._ticu_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String ticu_usuario_modificacion {
            get { return this._ticu_usuario_modificacion; }
            set { this._ticu_usuario_modificacion = value; }
            
        }


		
    }
}

