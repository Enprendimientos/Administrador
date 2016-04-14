using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_bancos: SCDataAccess<co_tg_bancos>
    {
        public da_tg_bancos(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_bancos GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_bancos_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos> GetData(co_tg_bancos bancos)
        {
            try
            {
                return this.ReadDataGeneric(bancos, "pa08_tg_bancos_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancos Insert(co_tg_bancos bancos)
        {
            try
            {
                return this.CreateDataGeneric(bancos, "pa08_tg_bancos_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos> Insert(IList<co_tg_bancos> bancos)
        {
            try
            {
                return this.CreateDataGeneric(bancos, "pa08_tg_bancos_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_bancos bancos)
        {
            try
            {
                this.UpdateDataGeneric(bancos, "pa08_tg_bancos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_bancos> bancos)
        {
            try
            {
                this.UpdateDataGeneric(bancos, "pa08_tg_bancos_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_bancos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_bancos bancos)
        {
            try
            {
                this.DeleteDataGeneric(bancos, "pa08_tg_bancos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancos_no> GetNomina(co_tg_bancos_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_bancos_no> nom = new SCDataAccessNominas<co_tg_bancos_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_bancos_no", this.Trans);
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

