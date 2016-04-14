using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_bancospaises : SCCommon
    {
	        private SCCommonIdDescripcion _id_pais;
        private SCCommonIdDescripcion _id_banco;


        public co_tg_bancospaises()
        {
		            id_pais = new SCCommonIdDescripcion();
            id_banco = new SCCommonIdDescripcion();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_bancopais {
            get { return this.id; }
            set { this.id = value; }
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String bapa_nombre {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_pais , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=pais_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_pais {
            get { return this._id_pais; }
            set { this._id_pais = value; }
            
        }

        [Category("DataColumn")]
        [Description("NombreId=id_banco , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=banc_nombre, SqlDbType=SqlDbType.varchar, Size=200, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_banco {
            get { return this._id_banco; }
            set { this._id_banco = value; }
            
        }


		
    }
}

