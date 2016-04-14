using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_menuopciones: SCDataAccess<co_ca_menuopciones>
    {
        public da_ca_menuopciones(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_menuopciones GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_menuopciones_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menuopciones> GetData(co_ca_menuopciones menuopciones)
        {
            try
            {
                return this.ReadDataGeneric(menuopciones, "pa08_ca_menuopciones_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_menuopciones Insert(co_ca_menuopciones menuopciones)
        {
            try
            {
                return this.CreateDataGeneric(menuopciones, "pa08_ca_menuopciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menuopciones> Insert(IList<co_ca_menuopciones> menuopciones)
        {
            try
            {
                return this.CreateDataGeneric(menuopciones, "pa08_ca_menuopciones_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_menuopciones menuopciones)
        {
            try
            {
                this.UpdateDataGeneric(menuopciones, "pa08_ca_menuopciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_menuopciones> menuopciones)
        {
            try
            {
                this.UpdateDataGeneric(menuopciones, "pa08_ca_menuopciones_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_menuopciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_menuopciones menuopciones)
        {
            try
            {
                this.DeleteDataGeneric(menuopciones, "pa08_ca_menuopciones_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_menuopciones_no> GetNomina(co_ca_menuopciones_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_menuopciones_no> nom = new SCDataAccessNominas<co_ca_menuopciones_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_menuopciones_no", this.Trans);
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

