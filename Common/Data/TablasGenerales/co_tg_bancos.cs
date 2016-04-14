using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable()]
    public class co_tg_bancos : SCCommon
    {
	        private String _banc_sigla;
        private EstadoRegistro _banc_vigente;
        private SCCommonFecha _banc_fecha_creacion;
        private String _banc_usuario_creacion;
        private SCCommonFecha _banc_fecha_modificacion;
        private String _banc_usuario_modificacion;


        public co_tg_bancos()
        {
		            _banc_vigente = EstadoRegistro.TODOS;
            banc_fecha_creacion = new SCCommonFecha();
            banc_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_banco {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String banc_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=10, Null=True")]
        public String banc_sigla {
            get { return this._banc_sigla; }
            set { this._banc_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro banc_vigente {
            get { return this._banc_vigente; }
            set { this._banc_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha banc_fecha_creacion {
            get { return this._banc_fecha_creacion; }
            set { this._banc_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String banc_usuario_creacion {
            get { return this._banc_usuario_creacion; }
            set { this._banc_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha banc_fecha_modificacion {
            get { return this._banc_fecha_modificacion; }
            set { this._banc_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String banc_usuario_modificacion {
            get { return this._banc_usuario_modificacion; }
            set { this._banc_usuario_modificacion = value; }
            
        }


		
    }
}

