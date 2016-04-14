using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_usuariosperfiles : SCBusinessRules<co_ca_usuariosperfiles>
    {
        public br_ca_usuariosperfiles(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_usuariosperfiles(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_usuariosperfiles GetData(int id)
        {
            try
            {
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                return DAusuariosperfiles.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariosperfiles> GetData(co_ca_usuariosperfiles usuariosperfiles)
        {
            try
            {
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                return DAusuariosperfiles.GetData(usuariosperfiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuariosperfiles Insert(co_ca_usuariosperfiles usuariosperfiles)
        {
            try
            {
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                return DAusuariosperfiles.Insert(usuariosperfiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariosperfiles> Insert(IList<co_ca_usuariosperfiles> usuariosperfiles)
        {
            IList<co_ca_usuariosperfiles> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                ilistReturn = DAusuariosperfiles.Insert(usuariosperfiles);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_usuariosperfiles usuariosperfiles)
        {
            try
            {
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                DAusuariosperfiles.Update(usuariosperfiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_usuariosperfiles> usuariosperfiles)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                DAusuariosperfiles.Update(usuariosperfiles);
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
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                DAusuariosperfiles.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_usuariosperfiles usuariosperfiles)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                DAusuariosperfiles.Delete(usuariosperfiles);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuariosperfiles_no> GetNomina(co_ca_usuariosperfiles_no Nomina)
        {
            try
            {
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                return DAusuariosperfiles.GetNomina(Nomina);
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
                da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
                return DAusuariosperfiles.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_usuariosperfiles DAusuariosperfiles = new da_ca_usuariosperfiles(this.myTrans);
            return DAusuariosperfiles.GetInforme(Informe);
        } 
    }
}

