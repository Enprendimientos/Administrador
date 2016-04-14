using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_constantestipos : SCBusinessRules<co_tg_constantestipos>
    {
        public br_tg_constantestipos(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_constantestipos(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_constantestipos GetData(int id)
        {
            try
            {
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                return DAconstantestipos.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantestipos> GetData(co_tg_constantestipos constantestipos)
        {
            try
            {
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                return DAconstantestipos.GetData(constantestipos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_constantestipos Insert(co_tg_constantestipos constantestipos)
        {
            try
            {
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                return DAconstantestipos.Insert(constantestipos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantestipos> Insert(IList<co_tg_constantestipos> constantestipos)
        {
            IList<co_tg_constantestipos> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                ilistReturn = DAconstantestipos.Insert(constantestipos);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_constantestipos constantestipos)
        {
            try
            {
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                DAconstantestipos.Update(constantestipos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_constantestipos> constantestipos)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                DAconstantestipos.Update(constantestipos);
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
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                DAconstantestipos.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_constantestipos constantestipos)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                DAconstantestipos.Delete(constantestipos);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_constantestipos_no> GetNomina(co_tg_constantestipos_no Nomina)
        {
            try
            {
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                return DAconstantestipos.GetNomina(Nomina);
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
                da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
                return DAconstantestipos.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_constantestipos DAconstantestipos = new da_tg_constantestipos(this.myTrans);
            return DAconstantestipos.GetInforme(Informe);
        } 
    }
}

