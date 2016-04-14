using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_perfilesopciones: SCDataAccess<co_ca_perfilesopciones>
    {
        public da_ca_perfilesopciones(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_perfilesopciones GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_perfilesopciones_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfilesopciones> GetData(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                return this.ReadDataGeneric(perfilesopciones, "pa08_ca_perfilesopciones_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_perfilesopciones Insert(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                return this.CreateDataGeneric(perfilesopciones, "pa08_ca_perfilesopciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfilesopciones> Insert(IList<co_ca_perfilesopciones> perfilesopciones)
        {
            try
            {
                return this.CreateDataGeneric(perfilesopciones, "pa08_ca_perfilesopciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                this.UpdateDataGeneric(perfilesopciones, "pa08_ca_perfilesopciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_perfilesopciones> perfilesopciones)
        {
            try
            {
                this.UpdateDataGeneric(perfilesopciones, "pa08_ca_perfilesopciones_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_perfilesopciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                this.DeleteDataGeneric(perfilesopciones, "pa08_ca_perfilesopciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_perfilesopciones_no> GetNomina(co_ca_perfilesopciones_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_perfilesopciones_no> nom = new SCDataAccessNominas<co_ca_perfilesopciones_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_perfilesopciones_no", this.Trans);
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

