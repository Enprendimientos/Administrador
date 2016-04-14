using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_bancos_personas : SCBusinessRules<co_tg_bancos_personas>
    {
        public br_tg_bancos_personas(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_bancos_personas(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_bancos_personas GetData(int id)
        {
            try
            {
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                return DApersonas.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos_personas> GetData(co_tg_bancos_personas personas)
        {
            try
            {
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                return DApersonas.GetData(personas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancos_personas Insert(co_tg_bancos_personas personas)
        {
            try
            {
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                return DApersonas.Insert(personas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos_personas> Insert(IList<co_tg_bancos_personas> personas)
        {
            IList<co_tg_bancos_personas> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                ilistReturn = DApersonas.Insert(personas);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_bancos_personas personas)
        {
            try
            {
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                DApersonas.Update(personas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_bancos_personas> personas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                DApersonas.Update(personas);
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
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                DApersonas.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_bancos_personas personas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                DApersonas.Delete(personas);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancos_personas_no> GetNomina(co_tg_bancos_personas_no Nomina)
        {
            try
            {
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                return DApersonas.GetNomina(Nomina);
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
                da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
                return DApersonas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_bancos_personas DApersonas = new da_tg_bancos_personas(this.myTrans);
            return DApersonas.GetInforme(Informe);
        } 
    }
}

