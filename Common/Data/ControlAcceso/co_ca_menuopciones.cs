using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
    [Serializable]
    public class co_ca_menuopciones : SCCommon
    {
	        private SCCommonIdDescripcion _id_menu;
        private SCCommonIdDescripcion _id_opcion;


        public co_ca_menuopciones()
        {
		            id_menu = new SCCommonIdDescripcion();
            id_opcion = new SCCommonIdDescripcion();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_menuopcion {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String meop_descripcion {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_menu , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=menu_nombre, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_menu {
            get { return this._id_menu; }
            set { this._id_menu = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_opcion , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=opci_opcion, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_opcion {
            get { return this._id_opcion; }
            set { this._id_opcion = value; }
            
        }


		
    }
}

