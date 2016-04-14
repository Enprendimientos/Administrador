using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_direcciones: SCDataAccess<co_tg_direcciones>
    {
        public da_tg_direcciones(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_direcciones GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_direcciones_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_direcciones> GetData(co_tg_direcciones direcciones)
        {
            try
            {
                return this.ReadDataGeneric(direcciones, "pa08_tg_direcciones_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_direcciones Insert(co_tg_direcciones direcciones)
        {
            try
            {
                return this.CreateDataGeneric(direcciones, "pa08_tg_direcciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_direcciones> Insert(IList<co_tg_direcciones> direcciones)
        {
            try
            {
                return this.CreateDataGeneric(direcciones, "pa08_tg_direcciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_direcciones direcciones)
        {
            try
            {
                this.UpdateDataGeneric(direcciones, "pa08_tg_direcciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_direcciones> direcciones)
        {
            try
            {
                this.UpdateDataGeneric(direcciones, "pa08_tg_direcciones_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_direcciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_direcciones direcciones)
        {
            try
            {
                this.DeleteDataGeneric(direcciones, "pa08_tg_direcciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_direcciones_no> GetNomina(co_tg_direcciones_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_direcciones_no> nom = new SCDataAccessNominas<co_tg_direcciones_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_direcciones_no", this.Trans);
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

