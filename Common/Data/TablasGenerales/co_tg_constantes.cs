using System;
using System.ComponentModel;
using Fwp.common;

namespace Common.Data.TablasGenerales
{
    [Serializable]
    public class co_tg_constantes : SCCommon
    {
      private SCCommonIdDescripcion _id_constantetipo;
        private String _ct_constantevalor;
        private String _ct_constantedescripcion;


        public co_tg_constantes()
        {
		            id_constantetipo = new SCCommonIdDescripcion();

        }

	        [Category("Identity")]
        [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
        public int id_constante {
            get { return this.id; }
            set { this.id = value; }
        }


        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=50, Null=True")]
        public String ct_constante {
            get { return this.descripcion; }
            set { this.descripcion = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=8000, Null=True")]
        public String ct_constantevalor {
            get { return this._ct_constantevalor; }
            set { this._ct_constantevalor = value; }
            
        }

        [Category("DataColumn")]
        [Description("SqlDbType=SqlDbType.varchar, Size=100, Null=True")]
        public String ct_constantedescripcion {
            get { return this._ct_constantedescripcion; }
            set { this._ct_constantedescripcion = value; }
            
        }


        [Category("DataColumn")]
        [Description("NombreId=id_constantetipo , SqlDbType=SqlDbType.int, Size=0, Null=True, NombreDescripcion=ct_constantetipo, SqlDbType=SqlDbType.varchar, Size=50, Null=True, Desnormalizado=False")]
        public SCCommonIdDescripcion id_constantetipo
        {
          get { return this._id_constantetipo; }
          set { this._id_constantetipo = value; }

        }
		
    }
}

