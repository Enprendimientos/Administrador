using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_ciudades: SCDataAccess<co_tg_ciudades>
    {
        public da_tg_ciudades(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_ciudades GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_ciudades_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_ciudades> GetData(co_tg_ciudades ciudades)
        {
            try
            {
                return this.ReadDataGeneric(ciudades, "pa08_tg_ciudades_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_ciudades Insert(co_tg_ciudades ciudades)
        {
            try
            {
                return this.CreateDataGeneric(ciudades, "pa08_tg_ciudades_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_ciudades> Insert(IList<co_tg_ciudades> ciudades)
        {
            try
            {
                return this.CreateDataGeneric(ciudades, "pa08_tg_ciudades_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_ciudades ciudades)
        {
            try
            {
                this.UpdateDataGeneric(ciudades, "pa08_tg_ciudades_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_ciudades> ciudades)
        {
            try
            {
                this.UpdateDataGeneric(ciudades, "pa08_tg_ciudades_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_ciudades_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_ciudades ciudades)
        {
            try
            {
                this.DeleteDataGeneric(ciudades, "pa08_tg_ciudades_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_ciudades_no> GetNomina(co_tg_ciudades_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_ciudades_no> nom = new SCDataAccessNominas<co_tg_ciudades_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_ciudades_no", this.Trans);
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

