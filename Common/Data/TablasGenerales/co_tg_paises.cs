using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_paises : SCCommon
    {
	        private String _pais_icon;
        private String _pais_sigla;
        private EstadoRegistro _pais_vigente;
        private SCCommonFecha _pais_fecha_creacion;
        private String _pais_usuario_creacion;
        private SCCommonFecha _pais_fecha_modificacion;
        private String _pais_usuario_modificacion;


        public co_tg_paises()
        {
		            _pais_vigente = EstadoRegistro.TODOS;
            pais_fecha_creacion = new SCCommonFecha();
            pais_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_pais {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String pais_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String pais_icon {
            get { return this._pais_icon; }
            set { this._pais_icon = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=5, Null=True")]
        public String pais_sigla {
            get { return this._pais_sigla; }
            set { this._pais_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro pais_vigente {
            get { return this._pais_vigente; }
            set { this._pais_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha pais_fecha_creacion {
            get { return this._pais_fecha_creacion; }
            set { this._pais_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String pais_usuario_creacion {
            get { return this._pais_usuario_creacion; }
            set { this._pais_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha pais_fecha_modificacion {
            get { return this._pais_fecha_modificacion; }
            set { this._pais_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String pais_usuario_modificacion {
            get { return this._pais_usuario_modificacion; }
            set { this._pais_usuario_modificacion = value; }
            
        }


		
    }
}

