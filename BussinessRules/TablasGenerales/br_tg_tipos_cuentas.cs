using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_tipos_cuentas : SCBusinessRules<co_tg_tipos_cuentas>
    {
        public br_tg_tipos_cuentas(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_tipos_cuentas(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_tipos_cuentas GetData(int id)
        {
            try
            {
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                return DAcuentas.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_tipos_cuentas> GetData(co_tg_tipos_cuentas cuentas)
        {
            try
            {
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                return DAcuentas.GetData(cuentas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_tipos_cuentas Insert(co_tg_tipos_cuentas cuentas)
        {
            try
            {
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                return DAcuentas.Insert(cuentas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_tipos_cuentas> Insert(IList<co_tg_tipos_cuentas> cuentas)
        {
            IList<co_tg_tipos_cuentas> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                ilistReturn = DAcuentas.Insert(cuentas);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_tipos_cuentas cuentas)
        {
            try
            {
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                DAcuentas.Update(cuentas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_tipos_cuentas> cuentas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                DAcuentas.Update(cuentas);
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
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                DAcuentas.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_tipos_cuentas cuentas)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                DAcuentas.Delete(cuentas);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_tipos_cuentas_no> GetNomina(co_tg_tipos_cuentas_no Nomina)
        {
            try
            {
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                return DAcuentas.GetNomina(Nomina);
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
                da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
                return DAcuentas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_tipos_cuentas DAcuentas = new da_tg_tipos_cuentas(this.myTrans);
            return DAcuentas.GetInforme(Informe);
        } 
    }
}

