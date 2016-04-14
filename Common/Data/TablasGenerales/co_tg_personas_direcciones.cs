using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_personas_direcciones : SCCommon
    {
	        private SCCommonIdDescripcion _id_persona;
        private SCCommonIdDescripcion _id_direccion;


        public co_tg_personas_direcciones()
        {
		            id_persona = new SCCommonIdDescripcion();
            id_direccion = new SCCommonIdDescripcion();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_personadireccion {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
        public String pedi_descripcion {
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
        [Description("NombreId=id_direccion , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=dire_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_direccion {
            get { return this._id_direccion; }
            set { this._id_direccion = value; }
            
        }


		
    }
}

