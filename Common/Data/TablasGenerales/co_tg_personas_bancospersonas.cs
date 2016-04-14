using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_personas_bancospersonas : SCCommon
    {
	        private SCCommonIdDescripcion _id_persona;
        private SCCommonIdDescripcion _id_banco_persona;


        public co_tg_personas_bancospersonas()
        {
		            id_persona = new SCCommonIdDescripcion();
            id_banco_persona = new SCCommonIdDescripcion();

        }

	      [Category("Identity")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=False")]
        public int id_personabancopersona {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String pebape_descripcion {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_persona , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=pers_nombrecompleto, SqlDbType=SqlDbType.varchar, Size=500, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_persona {
            get { return this._id_persona; }
            set { this._id_persona = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_banco_persona , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=bape_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_banco_persona {
            get { return this._id_banco_persona; }
            set { this._id_banco_persona = value; }
            
        }


		
    }
}

