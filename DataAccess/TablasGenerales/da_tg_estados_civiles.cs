using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_estados_civiles: SCDataAccess<co_tg_estados_civiles>
    {
        public da_tg_estados_civiles(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_estados_civiles GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_estados_civiles_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_estados_civiles> GetData(co_tg_estados_civiles civiles)
        {
            try
            {
                return this.ReadDataGeneric(civiles, "pa08_tg_estados_civiles_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_estados_civiles Insert(co_tg_estados_civiles civiles)
        {
            try
            {
                return this.CreateDataGeneric(civiles, "pa08_tg_estados_civiles_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_estados_civiles> Insert(IList<co_tg_estados_civiles> civiles)
        {
            try
            {
                return this.CreateDataGeneric(civiles, "pa08_tg_estados_civiles_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_estados_civiles civiles)
        {
            try
            {
                this.UpdateDataGeneric(civiles, "pa08_tg_estados_civiles_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_estados_civiles> civiles)
        {
            try
            {
                this.UpdateDataGeneric(civiles, "pa08_tg_estados_civiles_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_estados_civiles_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_estados_civiles civiles)
        {
            try
            {
                this.DeleteDataGeneric(civiles, "pa08_tg_estados_civiles_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_estados_civiles_no> GetNomina(co_tg_estados_civiles_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_estados_civiles_no> nom = new SCDataAccessNominas<co_tg_estados_civiles_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_estados_civiles_no", this.Trans);
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

