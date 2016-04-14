using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_paises : SCBusinessRules<co_tg_paises>
    {
        public br_tg_paises(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_paises(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_paises GetData(int id)
        {
            try
            {
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                return DApaises.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_paises> GetData(co_tg_paises paises)
        {
            try
            {
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                return DApaises.GetData(paises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_paises Insert(co_tg_paises paises)
        {
            try
            {
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                return DApaises.Insert(paises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_paises> Insert(IList<co_tg_paises> paises)
        {
            IList<co_tg_paises> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                ilistReturn = DApaises.Insert(paises);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_paises paises)
        {
            try
            {
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                DApaises.Update(paises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_paises> paises)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                DApaises.Update(paises);
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
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                DApaises.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_paises paises)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                DApaises.Delete(paises);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_paises_no> GetNomina(co_tg_paises_no Nomina)
        {
            try
            {
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                return DApaises.GetNomina(Nomina);
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
                da_tg_paises DApaises = new da_tg_paises(this.myTrans);
                return DApaises.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_paises DApaises = new da_tg_paises(this.myTrans);
            return DApaises.GetInforme(Informe);
        } 
    }
}

