using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_bancospaises : SCBusinessRules<co_tg_bancospaises>
    {
        public br_tg_bancospaises(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_bancospaises(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_bancospaises GetData(int id)
        {
            try
            {
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                return DAbancospaises.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancospaises> GetData(co_tg_bancospaises bancospaises)
        {
            try
            {
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                return DAbancospaises.GetData(bancospaises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancospaises Insert(co_tg_bancospaises bancospaises)
        {
            try
            {
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                return DAbancospaises.Insert(bancospaises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancospaises> Insert(IList<co_tg_bancospaises> bancospaises)
        {
            IList<co_tg_bancospaises> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                ilistReturn = DAbancospaises.Insert(bancospaises);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_bancospaises bancospaises)
        {
            try
            {
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                DAbancospaises.Update(bancospaises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_bancospaises> bancospaises)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                DAbancospaises.Update(bancospaises);
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
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                DAbancospaises.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_bancospaises bancospaises)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                DAbancospaises.Delete(bancospaises);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancospaises_no> GetNomina(co_tg_bancospaises_no Nomina)
        {
            try
            {
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                return DAbancospaises.GetNomina(Nomina);
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
                da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
                return DAbancospaises.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_bancospaises DAbancospaises = new da_tg_bancospaises(this.myTrans);
            return DAbancospaises.GetInforme(Informe);
        } 
    }
}

