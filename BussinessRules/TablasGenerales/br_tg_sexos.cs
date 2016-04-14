using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_sexos : SCBusinessRules<co_tg_sexos>
    {
        public br_tg_sexos(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_sexos(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_sexos GetData(int id)
        {
            try
            {
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                return DAsexos.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_sexos> GetData(co_tg_sexos sexos)
        {
            try
            {
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                return DAsexos.GetData(sexos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_sexos Insert(co_tg_sexos sexos)
        {
            try
            {
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                return DAsexos.Insert(sexos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_sexos> Insert(IList<co_tg_sexos> sexos)
        {
            IList<co_tg_sexos> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                ilistReturn = DAsexos.Insert(sexos);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_sexos sexos)
        {
            try
            {
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                DAsexos.Update(sexos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_sexos> sexos)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                DAsexos.Update(sexos);
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
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                DAsexos.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_sexos sexos)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                DAsexos.Delete(sexos);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_sexos_no> GetNomina(co_tg_sexos_no Nomina)
        {
            try
            {
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                return DAsexos.GetNomina(Nomina);
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
                da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
                return DAsexos.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_sexos DAsexos = new da_tg_sexos(this.myTrans);
            return DAsexos.GetInforme(Informe);
        } 
    }
}

