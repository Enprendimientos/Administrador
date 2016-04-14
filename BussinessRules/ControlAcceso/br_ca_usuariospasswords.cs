using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_usuariospasswords : SCBusinessRules<co_ca_usuariospasswords>
    {
        public br_ca_usuariospasswords(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_usuariospasswords(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_usuariospasswords GetData(int id)
        {
            try
            {
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                return DAusuariospasswords.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariospasswords> GetData(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                return DAusuariospasswords.GetData(usuariospasswords);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuariospasswords Insert(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                return DAusuariospasswords.Insert(usuariospasswords);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariospasswords> Insert(IList<co_ca_usuariospasswords> usuariospasswords)
        {
            IList<co_ca_usuariospasswords> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                ilistReturn = DAusuariospasswords.Insert(usuariospasswords);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                DAusuariospasswords.Update(usuariospasswords);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_usuariospasswords> usuariospasswords)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                DAusuariospasswords.Update(usuariospasswords);
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
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                DAusuariospasswords.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                DAusuariospasswords.Delete(usuariospasswords);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuariospasswords_no> GetNomina(co_ca_usuariospasswords_no Nomina)
        {
            try
            {
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                return DAusuariospasswords.GetNomina(Nomina);
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
                da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
                return DAusuariospasswords.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_usuariospasswords DAusuariospasswords = new da_ca_usuariospasswords(this.myTrans);
            return DAusuariospasswords.GetInforme(Informe);
        } 
    }
}

