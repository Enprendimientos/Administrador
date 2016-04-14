using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_bancospaises: SCDataAccess<co_tg_bancospaises>
    {
        public da_tg_bancospaises(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_bancospaises GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_bancospaises_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancospaises> GetData(co_tg_bancospaises bancospaises)
        {
            try
            {
                return this.ReadDataGeneric(bancospaises, "pa08_tg_bancospaises_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancospaises Insert(co_tg_bancospaises bancospaises)
        {
            try
            {
                return this.CreateDataGeneric(bancospaises, "pa08_tg_bancospaises_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancospaises> Insert(IList<co_tg_bancospaises> bancospaises)
        {
            try
            {
                return this.CreateDataGeneric(bancospaises, "pa08_tg_bancospaises_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_bancospaises bancospaises)
        {
            try
            {
                this.UpdateDataGeneric(bancospaises, "pa08_tg_bancospaises_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_bancospaises> bancospaises)
        {
            try
            {
                this.UpdateDataGeneric(bancospaises, "pa08_tg_bancospaises_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_bancospaises_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_bancospaises bancospaises)
        {
            try
            {
                this.DeleteDataGeneric(bancospaises, "pa08_tg_bancospaises_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancospaises_no> GetNomina(co_tg_bancospaises_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_bancospaises_no> nom = new SCDataAccessNominas<co_tg_bancospaises_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_bancospaises_no", this.Trans);
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

