using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_personas_bancospersonas : SCBusinessRules<co_tg_personas_bancospersonas>
    {
        public br_tg_personas_bancospersonas(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_personas_bancospersonas(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_personas_bancospersonas GetData(int id)
        {
            try
            {
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                return DAbancospersonas.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_bancospersonas> GetData(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                return DAbancospersonas.GetData(bancospersonas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_personas_bancospersonas Insert(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                return DAbancospersonas.Insert(bancospersonas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_bancospersonas> Insert(IList<co_tg_personas_bancospersonas> bancospersonas)
        {
            IList<co_tg_personas_bancospersonas> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                ilistReturn = DAbancospersonas.Insert(bancospersonas);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                DAbancospersonas.Update(bancospersonas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_personas_bancospersonas> bancospersonas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                DAbancospersonas.Update(bancospersonas);
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
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                DAbancospersonas.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                DAbancospersonas.Delete(bancospersonas);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_personas_bancospersonas_no> GetNomina(co_tg_personas_bancospersonas_no Nomina)
        {
            try
            {
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                return DAbancospersonas.GetNomina(Nomina);
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
                da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
                return DAbancospersonas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_personas_bancospersonas DAbancospersonas = new da_tg_personas_bancospersonas(this.myTrans);
            return DAbancospersonas.GetInforme(Informe);
        } 
    }
}

