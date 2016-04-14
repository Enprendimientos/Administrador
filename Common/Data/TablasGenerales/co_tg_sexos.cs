using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_sexos : SCCommon
    {
	        private String _sexo_sigla;
        private EstadoRegistro _sexo_vigente;
        private SCCommonFecha _sexo_fecha_creacion;
        private String _sexo_usuario_creacion;
        private SCCommonFecha _sexo_fecha_modificacion;
        private String _sexo_usuario_modificacion;


        public co_tg_sexos()
        {
		            _sexo_vigente = EstadoRegistro.TODOS;
            sexo_fecha_creacion = new SCCommonFecha();
            sexo_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_sexo {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String sexo_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=5, Null=True")]
        public String sexo_sigla {
            get { return this._sexo_sigla; }
            set { this._sexo_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro sexo_vigente {
            get { return this._sexo_vigente; }
            set { this._sexo_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha sexo_fecha_creacion {
            get { return this._sexo_fecha_creacion; }
            set { this._sexo_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String sexo_usuario_creacion {
            get { return this._sexo_usuario_creacion; }
            set { this._sexo_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha sexo_fecha_modificacion {
            get { return this._sexo_fecha_modificacion; }
            set { this._sexo_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String sexo_usuario_modificacion {
            get { return this._sexo_usuario_modificacion; }
            set { this._sexo_usuario_modificacion = value; }
            
        }


		
    }
}

