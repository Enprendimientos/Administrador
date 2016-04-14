using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_direcciones : SCCommon
    {
	        private String _dire_villa_o_poblacion;
        private String _dire_direccion;
        private String _dire_numero;
        private String _dire_departamento;
        private EstadoRegistro _dire_vigente;
        private SCCommonFecha _dire_fecha_creacion;
        private String _dire_usuario_creacion;
        private SCCommonFecha _dire_fecha_modificacion;
        private String _dire_usuario_modificacion;


        public co_tg_direcciones()
        {
		            _dire_vigente = EstadoRegistro.TODOS;
            dire_fecha_creacion = new SCCommonFecha();
            dire_fecha_modificacion = new SCCommonFecha();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_direccion {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String dire_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=200, Null=True")]
        public String dire_villa_o_poblacion {
            get { return this._dire_villa_o_poblacion; }
            set { this._dire_villa_o_poblacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=500, Null=True")]
        public String dire_direccion {
            get { return this._dire_direccion; }
            set { this._dire_direccion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=10, Null=True")]
        public String dire_numero {
            get { return this._dire_numero; }
            set { this._dire_numero = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=10, Null=True")]
        public String dire_departamento {
            get { return this._dire_departamento; }
            set { this._dire_departamento = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.Bit, Size=0, Null=True")]
        public EstadoRegistro dire_vigente {
            get { return this._dire_vigente; }
            set { this._dire_vigente = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha dire_fecha_creacion {
            get { return this._dire_fecha_creacion; }
            set { this._dire_fecha_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String dire_usuario_creacion {
            get { return this._dire_usuario_creacion; }
            set { this._dire_usuario_creacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.smalldatetime, Size=0, Null=True")]
        public SCCommonFecha dire_fecha_modificacion {
            get { return this._dire_fecha_modificacion; }
            set { this._dire_fecha_modificacion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String dire_usuario_modificacion {
            get { return this._dire_usuario_modificacion; }
            set { this._dire_usuario_modificacion = value; }
            
        }


		
    }
}

