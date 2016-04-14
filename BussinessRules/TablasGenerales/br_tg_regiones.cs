using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_regiones : SCBusinessRules<co_tg_regiones>
    {
        public br_tg_regiones(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_regiones(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_regiones GetData(int id)
        {
            try
            {
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                return DAregiones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_regiones> GetData(co_tg_regiones regiones)
        {
            try
            {
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                return DAregiones.GetData(regiones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_regiones Insert(co_tg_regiones regiones)
        {
            try
            {
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                return DAregiones.Insert(regiones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_regiones> Insert(IList<co_tg_regiones> regiones)
        {
            IList<co_tg_regiones> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                ilistReturn = DAregiones.Insert(regiones);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_regiones regiones)
        {
            try
            {
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                DAregiones.Update(regiones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_regiones> regiones)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                DAregiones.Update(regiones);
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
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                DAregiones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_regiones regiones)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                DAregiones.Delete(regiones);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_regiones_no> GetNomina(co_tg_regiones_no Nomina)
        {
            try
            {
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                return DAregiones.GetNomina(Nomina);
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
                da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
                return DAregiones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_regiones DAregiones = new da_tg_regiones(this.myTrans);
            return DAregiones.GetInforme(Informe);
        } 
    }
}

