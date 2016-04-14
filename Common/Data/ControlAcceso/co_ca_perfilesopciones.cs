using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
    [Serializable]
    public class co_ca_perfilesopciones : SCCommon
    {
	        private SCCommonIdDescripcion _id_perfil;
        private SCCommonIdDescripcion _id_opcion;


        public co_ca_perfilesopciones()
        {
		            id_perfil = new SCCommonIdDescripcion();
            id_opcion = new SCCommonIdDescripcion();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_perfilopcion {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String peop_descripcion {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_perfil , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=perf_perfil, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_perfil {
            get { return this._id_perfil; }
            set { this._id_perfil = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_opcion , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=opci_opcion, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_opcion {
            get { return this._id_opcion; }
            set { this._id_opcion = value; }
            
        }


		
    }
}

