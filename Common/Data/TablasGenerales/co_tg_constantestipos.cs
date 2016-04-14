using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_constantestipos : SCCommon
    {
	

        public co_tg_constantestipos()
        {
		
        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_constantetipo {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String ct_constantetipo {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }


		
    }
}

