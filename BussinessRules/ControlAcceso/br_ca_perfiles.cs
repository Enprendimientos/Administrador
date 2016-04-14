using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_perfiles : SCBusinessRules<co_ca_perfiles>
    {
        public br_ca_perfiles(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_perfiles(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_perfiles GetData(int id)
        {
            try
            {
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                return DAperfiles.GetData(id);
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
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                return DAperfiles.GetData(perfiles);
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
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                return DAperfiles.Insert(perfiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfiles> Insert(IList<co_ca_perfiles> perfiles)
        {
            IList<co_ca_perfiles> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                ilistReturn = DAperfiles.Insert(perfiles);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_perfiles perfiles)
        {
            try
            {
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                DAperfiles.Update(perfiles);
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
                this.myTrans.BeginTransaction();            
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                DAperfiles.Update(perfiles);
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
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                DAperfiles.Delete(id);
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
                this.myTrans.BeginTransaction();            
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                DAperfiles.Delete(perfiles);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_perfiles_no> GetNomina(co_ca_perfiles_no Nomina)
        {
            try
            {
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                return DAperfiles.GetNomina(Nomina);
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
                da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
                return DAperfiles.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_perfiles DAperfiles = new da_ca_perfiles(this.myTrans);
            return DAperfiles.GetInforme(Informe);
        } 
    }
}

