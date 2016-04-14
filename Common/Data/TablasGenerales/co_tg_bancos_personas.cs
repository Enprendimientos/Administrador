using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_bancos_personas : SCCommon
    {
	        private SCCommonIdDescripcion _id_banco;
        private SCCommonIdDescripcion _id_tipo_cuenta;
        private int _bape_nro_cuenta;
        private EstadoRegistro _bape_vigente;
        private SCCommonFecha _bape_fecha_creacion;
        private String _bape_usuario_creacion;
        private SCCommonFecha _bape_fecha_modificacion;
        private String _bape_usuario_modificacion;


        public co_tg_bancos_personas()
        {
		            id_banco = new SCCommonIdDescripcion();
            id_tipo_cuenta = new SCCommonIdDescripcion();
            _bape_vigente = EstadoRegistro.TODOS;
            bape_fecha_creacion = new SCCommonFecha();
            bape_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_banco_persona {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String bape_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_banco , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=banc_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_banco {
            get { return this._id_banco; }
            set { this._id_banco = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_tipo_cuenta , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=ticu_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_tipo_cuenta {
            get { return this._id_tipo_cuenta; }
            set { this._id_tipo_cuenta = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=True")]
        public int bape_nro_cuenta {
            get { return this._bape_nro_cuenta; }
            set { this._bape_nro_cuenta = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro bape_vigente {
            get { return this._bape_vigente; }
            set { this._bape_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha bape_fecha_creacion {
            get { return this._bape_fecha_creacion; }
            set { this._bape_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String bape_usuario_creacion {
            get { return this._bape_usuario_creacion; }
            set { this._bape_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha bape_fecha_modificacion {
            get { return this._bape_fecha_modificacion; }
            set { this._bape_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String bape_usuario_modificacion {
            get { return this._bape_usuario_modificacion; }
            set { this._bape_usuario_modificacion = value; }
            
        }


		
    }
}

