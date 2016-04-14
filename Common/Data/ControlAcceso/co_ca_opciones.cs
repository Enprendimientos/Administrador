using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.ControlAcceso
{
    [Serializable]
    public class co_ca_opciones : SCCommon
    {
	        private String _opci_constante;


        public co_ca_opciones()
        {
		
        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_opcion {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String opci_opcion {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
        public String opci_constante {
            get { return this._opci_constante; }
            set { this._opci_constante = value; }
            
        }


		
    }
}

