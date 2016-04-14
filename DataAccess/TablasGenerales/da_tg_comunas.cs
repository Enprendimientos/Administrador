using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_comunas: SCDataAccess<co_tg_comunas>
    {
        public da_tg_comunas(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_comunas GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_comunas_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_comunas> GetData(co_tg_comunas comunas)
        {
            try
            {
                return this.ReadDataGeneric(comunas, "pa08_tg_comunas_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_comunas Insert(co_tg_comunas comunas)
        {
            try
            {
                return this.CreateDataGeneric(comunas, "pa08_tg_comunas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_comunas> Insert(IList<co_tg_comunas> comunas)
        {
            try
            {
                return this.CreateDataGeneric(comunas, "pa08_tg_comunas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_comunas comunas)
        {
            try
            {
                this.UpdateDataGeneric(comunas, "pa08_tg_comunas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_comunas> comunas)
        {
            try
            {
                this.UpdateDataGeneric(comunas, "pa08_tg_comunas_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_comunas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_comunas comunas)
        {
            try
            {
                this.DeleteDataGeneric(comunas, "pa08_tg_comunas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_comunas_no> GetNomina(co_tg_comunas_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_comunas_no> nom = new SCDataAccessNominas<co_tg_comunas_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_comunas_no", this.Trans);
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

