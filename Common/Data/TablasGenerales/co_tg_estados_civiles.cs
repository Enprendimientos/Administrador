using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_estados_civiles : SCCommon
    {
	        private String _esci_sigla;
        private EstadoRegistro _esci_vigente;
        private SCCommonFecha _esci_fecha_creacion;
        private String _esci_usuario_creacion;
        private SCCommonFecha _esci_fecha_modificacion;
        private String _esci_usuario_modificacion;


        public co_tg_estados_civiles()
        {
		            _esci_vigente = EstadoRegistro.TODOS;
            esci_fecha_creacion = new SCCommonFecha();
            esci_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_estado_civil {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=1024, Null=True")]
        public String esci_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=1024, Null=True")]
        public String esci_sigla {
            get { return this._esci_sigla; }
            set { this._esci_sigla = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro esci_vigente {
            get { return this._esci_vigente; }
            set { this._esci_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha esci_fecha_creacion {
            get { return this._esci_fecha_creacion; }
            set { this._esci_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=1024, Null=True")]
        public String esci_usuario_creacion {
            get { return this._esci_usuario_creacion; }
            set { this._esci_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha esci_fecha_modificacion {
            get { return this._esci_fecha_modificacion; }
            set { this._esci_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=1024, Null=True")]
        public String esci_usuario_modificacion {
            get { return this._esci_usuario_modificacion; }
            set { this._esci_usuario_modificacion = value; }
            
        }


		
    }
}

