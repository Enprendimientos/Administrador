using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_perfilesopciones : SCBusinessRules<co_ca_perfilesopciones>
    {
        public br_ca_perfilesopciones(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_perfilesopciones(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_perfilesopciones GetData(int id)
        {
            try
            {
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                return DAperfilesopciones.GetData(id);
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
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                return DAperfilesopciones.GetData(perfilesopciones);
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
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                return DAperfilesopciones.Insert(perfilesopciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfilesopciones> Insert(IList<co_ca_perfilesopciones> perfilesopciones)
        {
            IList<co_ca_perfilesopciones> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                ilistReturn = DAperfilesopciones.Insert(perfilesopciones);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                DAperfilesopciones.Update(perfilesopciones);
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
                this.myTrans.BeginTransaction();            
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                DAperfilesopciones.Update(perfilesopciones);
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
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                DAperfilesopciones.Delete(id);
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
                this.myTrans.BeginTransaction();            
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                DAperfilesopciones.Delete(perfilesopciones);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_perfilesopciones_no> GetNomina(co_ca_perfilesopciones_no Nomina)
        {
            try
            {
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                return DAperfilesopciones.GetNomina(Nomina);
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
                da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
                return DAperfilesopciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_perfilesopciones DAperfilesopciones = new da_ca_perfilesopciones(this.myTrans);
            return DAperfilesopciones.GetInforme(Informe);
        } 
    }
}

