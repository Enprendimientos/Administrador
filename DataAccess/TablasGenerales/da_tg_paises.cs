using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_paises: SCDataAccess<co_tg_paises>
    {
        public da_tg_paises(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_paises GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_paises_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_paises> GetData(co_tg_paises paises)
        {
            try
            {
                return this.ReadDataGeneric(paises, "pa08_tg_paises_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_paises Insert(co_tg_paises paises)
        {
            try
            {
                return this.CreateDataGeneric(paises, "pa08_tg_paises_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_paises> Insert(IList<co_tg_paises> paises)
        {
            try
            {
                return this.CreateDataGeneric(paises, "pa08_tg_paises_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_paises paises)
        {
            try
            {
                this.UpdateDataGeneric(paises, "pa08_tg_paises_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_paises> paises)
        {
            try
            {
                this.UpdateDataGeneric(paises, "pa08_tg_paises_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_paises_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_paises paises)
        {
            try
            {
                this.DeleteDataGeneric(paises, "pa08_tg_paises_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_paises_no> GetNomina(co_tg_paises_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_paises_no> nom = new SCDataAccessNominas<co_tg_paises_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_paises_no", this.Trans);
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

