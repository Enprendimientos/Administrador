using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.TablasGenerales;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_personas: SCDataAccess<co_tg_personas>
    {
        public da_tg_personas(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_personas GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_personas_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas> GetData(co_tg_personas personas)
        {
            try
            {
                return this.ReadDataGeneric(personas, "pa08_tg_personas_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_personas Insert(co_tg_personas personas)
        {
            try
            {
                return this.CreateDataGeneric(personas, "pa08_tg_personas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas> Insert(IList<co_tg_personas> personas)
        {
            try
            {
                return this.CreateDataGeneric(personas, "pa08_tg_personas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_personas personas)
        {
            try
            {
                this.UpdateDataGeneric(personas, "pa08_tg_personas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_personas> personas)
        {
            try
            {
                this.UpdateDataGeneric(personas, "pa08_tg_personas_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_personas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_personas personas)
        {
            try
            {
                this.DeleteDataGeneric(personas, "pa08_tg_personas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_personas_no> GetNomina(co_tg_personas_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_personas_no> nom = new SCDataAccessNominas<co_tg_personas_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_personas_no", this.Trans);
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

