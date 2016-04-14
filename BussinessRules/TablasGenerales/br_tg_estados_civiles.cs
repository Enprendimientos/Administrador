using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_estados_civiles : SCBusinessRules<co_tg_estados_civiles>
    {
        public br_tg_estados_civiles(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_estados_civiles(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_estados_civiles GetData(int id)
        {
            try
            {
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                return DAciviles.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_estados_civiles> GetData(co_tg_estados_civiles civiles)
        {
            try
            {
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                return DAciviles.GetData(civiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_estados_civiles Insert(co_tg_estados_civiles civiles)
        {
            try
            {
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                return DAciviles.Insert(civiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_estados_civiles> Insert(IList<co_tg_estados_civiles> civiles)
        {
            IList<co_tg_estados_civiles> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                ilistReturn = DAciviles.Insert(civiles);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_estados_civiles civiles)
        {
            try
            {
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                DAciviles.Update(civiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_estados_civiles> civiles)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                DAciviles.Update(civiles);
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
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                DAciviles.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_estados_civiles civiles)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                DAciviles.Delete(civiles);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_estados_civiles_no> GetNomina(co_tg_estados_civiles_no Nomina)
        {
            try
            {
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                return DAciviles.GetNomina(Nomina);
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
                da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
                return DAciviles.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_estados_civiles DAciviles = new da_tg_estados_civiles(this.myTrans);
            return DAciviles.GetInforme(Informe);
        } 
    }
}

