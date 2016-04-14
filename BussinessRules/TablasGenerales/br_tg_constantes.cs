using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_constantes : SCBusinessRules<co_tg_constantes>
    {
        public br_tg_constantes(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_constantes(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_constantes GetData(int id)
        {
            try
            {
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                return DAconstantes.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantes> GetData(co_tg_constantes constantes)
        {
            try
            {
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                return DAconstantes.GetData(constantes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_constantes Insert(co_tg_constantes constantes)
        {
            try
            {
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                return DAconstantes.Insert(constantes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantes> Insert(IList<co_tg_constantes> constantes)
        {
            IList<co_tg_constantes> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                ilistReturn = DAconstantes.Insert(constantes);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_constantes constantes)
        {
            try
            {
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                DAconstantes.Update(constantes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_constantes> constantes)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                DAconstantes.Update(constantes);
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
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                DAconstantes.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_constantes constantes)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                DAconstantes.Delete(constantes);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_constantes_no> GetNomina(co_tg_constantes_no Nomina)
        {
            try
            {
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                return DAconstantes.GetNomina(Nomina);
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
                da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
                return DAconstantes.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_constantes DAconstantes = new da_tg_constantes(this.myTrans);
            return DAconstantes.GetInforme(Informe);
        } 
    }
}

