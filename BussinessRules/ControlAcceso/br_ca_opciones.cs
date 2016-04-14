using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_opciones : SCBusinessRules<co_ca_opciones>
    {
        public br_ca_opciones(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_opciones(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_opciones GetData(int id)
        {
            try
            {
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                return DAopciones.GetData(id);
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
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                return DAopciones.GetData(opciones);
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
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                return DAopciones.Insert(opciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_opciones> Insert(IList<co_ca_opciones> opciones)
        {
            IList<co_ca_opciones> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                ilistReturn = DAopciones.Insert(opciones);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_opciones opciones)
        {
            try
            {
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                DAopciones.Update(opciones);
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
                this.myTrans.BeginTransaction();            
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                DAopciones.Update(opciones);
                this.myTrans.Commit();                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                DAopciones.Delete(id);
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
                this.myTrans.BeginTransaction();            
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                DAopciones.Delete(opciones);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_opciones_no> GetNomina(co_ca_opciones_no Nomina)
        {
            try
            {
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                return DAopciones.GetNomina(Nomina);
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
                da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
                return DAopciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_opciones DAopciones = new da_ca_opciones(this.myTrans);
            return DAopciones.GetInforme(Informe);
        } 
    }
}

