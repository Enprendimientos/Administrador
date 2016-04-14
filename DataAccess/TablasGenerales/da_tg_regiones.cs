using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_regiones: SCDataAccess<co_tg_regiones>
    {
        public da_tg_regiones(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_regiones GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_regiones_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_regiones> GetData(co_tg_regiones regiones)
        {
            try
            {
                return this.ReadDataGeneric(regiones, "pa08_tg_regiones_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_regiones Insert(co_tg_regiones regiones)
        {
            try
            {
                return this.CreateDataGeneric(regiones, "pa08_tg_regiones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_regiones> Insert(IList<co_tg_regiones> regiones)
        {
            try
            {
                return this.CreateDataGeneric(regiones, "pa08_tg_regiones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_regiones regiones)
        {
            try
            {
                this.UpdateDataGeneric(regiones, "pa08_tg_regiones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_regiones> regiones)
        {
            try
            {
                this.UpdateDataGeneric(regiones, "pa08_tg_regiones_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_regiones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_regiones regiones)
        {
            try
            {
                this.DeleteDataGeneric(regiones, "pa08_tg_regiones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_regiones_no> GetNomina(co_tg_regiones_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_regiones_no> nom = new SCDataAccessNominas<co_tg_regiones_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_regiones_no", this.Trans);
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

