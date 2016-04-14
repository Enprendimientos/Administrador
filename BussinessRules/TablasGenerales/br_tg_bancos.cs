using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_bancos : SCBusinessRules<co_tg_bancos>
    {
        public br_tg_bancos(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_bancos(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_bancos GetData(int id)
        {
            try
            {
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                return DAbancos.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos> GetData(co_tg_bancos bancos)
        {
            try
            {
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                return DAbancos.GetData(bancos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancos Insert(co_tg_bancos bancos)
        {
            try
            {
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                return DAbancos.Insert(bancos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos> Insert(IList<co_tg_bancos> bancos)
        {
            IList<co_tg_bancos> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                ilistReturn = DAbancos.Insert(bancos);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_bancos bancos)
        {
            try
            {
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                DAbancos.Update(bancos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_bancos> bancos)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                DAbancos.Update(bancos);
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
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                DAbancos.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_bancos bancos)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                DAbancos.Delete(bancos);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancos_no> GetNomina(co_tg_bancos_no Nomina)
        {
            try
            {
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                return DAbancos.GetNomina(Nomina);
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
                da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
                return DAbancos.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_bancos DAbancos = new da_tg_bancos(this.myTrans);
            return DAbancos.GetInforme(Informe);
        } 
    }
}

