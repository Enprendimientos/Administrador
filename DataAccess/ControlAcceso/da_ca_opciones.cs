using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_opciones: SCDataAccess<co_ca_opciones>
    {
        public da_ca_opciones(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_opciones GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_opciones_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_opciones> GetData(co_ca_opciones opciones)
        {
            try
            {
                return this.ReadDataGeneric(opciones, "pa08_ca_opciones_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_opciones Insert(co_ca_opciones opciones)
        {
            try
            {
                return this.CreateDataGeneric(opciones, "pa08_ca_opciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_opciones> Insert(IList<co_ca_opciones> opciones)
        {
            try
            {
                return this.CreateDataGeneric(opciones, "pa08_ca_opciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_opciones opciones)
        {
            try
            {
                this.UpdateDataGeneric(opciones, "pa08_ca_opciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_opciones> opciones)
        {
            try
            {
                this.UpdateDataGeneric(opciones, "pa08_ca_opciones_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_opciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_opciones opciones)
        {
            try
            {
                this.DeleteDataGeneric(opciones, "pa08_ca_opciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_opciones_no> GetNomina(co_ca_opciones_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_opciones_no> nom = new SCDataAccessNominas<co_ca_opciones_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_opciones_no", this.Trans);
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

