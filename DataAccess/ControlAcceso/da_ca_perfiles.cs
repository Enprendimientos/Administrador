using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_perfiles: SCDataAccess<co_ca_perfiles>
    {
        public da_ca_perfiles(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_perfiles GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_perfiles_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfiles> GetData(co_ca_perfiles perfiles)
        {
            try
            {
                return this.ReadDataGeneric(perfiles, "pa08_ca_perfiles_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_perfiles Insert(co_ca_perfiles perfiles)
        {
            try
            {
                return this.CreateDataGeneric(perfiles, "pa08_ca_perfiles_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfiles> Insert(IList<co_ca_perfiles> perfiles)
        {
            try
            {
                return this.CreateDataGeneric(perfiles, "pa08_ca_perfiles_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_perfiles perfiles)
        {
            try
            {
                this.UpdateDataGeneric(perfiles, "pa08_ca_perfiles_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_perfiles> perfiles)
        {
            try
            {
                this.UpdateDataGeneric(perfiles, "pa08_ca_perfiles_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_perfiles_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_perfiles perfiles)
        {
            try
            {
                this.DeleteDataGeneric(perfiles, "pa08_ca_perfiles_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_perfiles_no> GetNomina(co_ca_perfiles_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_perfiles_no> nom = new SCDataAccessNominas<co_ca_perfiles_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_perfiles_no", this.Trans);
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

