using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_comunas : SCBusinessRules<co_tg_comunas>
    {
        public br_tg_comunas(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_comunas(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_comunas GetData(int id)
        {
            try
            {
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                return DAcomunas.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_comunas> GetData(co_tg_comunas comunas)
        {
            try
            {
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                return DAcomunas.GetData(comunas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_comunas Insert(co_tg_comunas comunas)
        {
            try
            {
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                return DAcomunas.Insert(comunas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_comunas> Insert(IList<co_tg_comunas> comunas)
        {
            IList<co_tg_comunas> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                ilistReturn = DAcomunas.Insert(comunas);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_comunas comunas)
        {
            try
            {
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                DAcomunas.Update(comunas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_comunas> comunas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                DAcomunas.Update(comunas);
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
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                DAcomunas.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_comunas comunas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                DAcomunas.Delete(comunas);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_comunas_no> GetNomina(co_tg_comunas_no Nomina)
        {
            try
            {
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                return DAcomunas.GetNomina(Nomina);
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
                da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
                return DAcomunas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_comunas DAcomunas = new da_tg_comunas(this.myTrans);
            return DAcomunas.GetInforme(Informe);
        } 
    }
}

