using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_sexos: SCDataAccess<co_tg_sexos>
    {
        public da_tg_sexos(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_sexos GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_sexos_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_sexos> GetData(co_tg_sexos sexos)
        {
            try
            {
                return this.ReadDataGeneric(sexos, "pa08_tg_sexos_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_sexos Insert(co_tg_sexos sexos)
        {
            try
            {
                return this.CreateDataGeneric(sexos, "pa08_tg_sexos_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_sexos> Insert(IList<co_tg_sexos> sexos)
        {
            try
            {
                return this.CreateDataGeneric(sexos, "pa08_tg_sexos_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_sexos sexos)
        {
            try
            {
                this.UpdateDataGeneric(sexos, "pa08_tg_sexos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_sexos> sexos)
        {
            try
            {
                this.UpdateDataGeneric(sexos, "pa08_tg_sexos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.DeleteDataGeneric(id, "pa08_tg_sexos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_sexos sexos)
        {
            try
            {
                this.DeleteDataGeneric(sexos, "pa08_tg_sexos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_sexos_no> GetNomina(co_tg_sexos_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_sexos_no> nom = new SCDataAccessNominas<co_tg_sexos_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_sexos_no", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataSet GetInforme(String SQLText)
        {
            try
            {
                SCDataAccessInformes<String> inf = new SCDataAccessInformes<String>();
                return inf.ReadDataGeneric(SQLText, this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe){
            //SCDataAccessInformes<T> inf = new SCDataAccessInformes<T>();
            //return inf.ReadDataGeneric(Informe, "", this.Trans);
            return new List<T>();
        } 

    }
}

