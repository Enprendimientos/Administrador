using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_personas_direcciones : SCBusinessRules<co_tg_personas_direcciones>
    {
        public br_tg_personas_direcciones(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_personas_direcciones(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_personas_direcciones GetData(int id)
        {
            try
            {
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                return DAdirecciones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_direcciones> GetData(co_tg_personas_direcciones direcciones)
        {
            try
            {
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                return DAdirecciones.GetData(direcciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_personas_direcciones Insert(co_tg_personas_direcciones direcciones)
        {
            try
            {
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                return DAdirecciones.Insert(direcciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_direcciones> Insert(IList<co_tg_personas_direcciones> direcciones)
        {
            IList<co_tg_personas_direcciones> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                ilistReturn = DAdirecciones.Insert(direcciones);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_personas_direcciones direcciones)
        {
            try
            {
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                DAdirecciones.Update(direcciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_personas_direcciones> direcciones)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                DAdirecciones.Update(direcciones);
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
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                DAdirecciones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_personas_direcciones direcciones)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                DAdirecciones.Delete(direcciones);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_personas_direcciones_no> GetNomina(co_tg_personas_direcciones_no Nomina)
        {
            try
            {
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                return DAdirecciones.GetNomina(Nomina);
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
                da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
                return DAdirecciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_personas_direcciones DAdirecciones = new da_tg_personas_direcciones(this.myTrans);
            return DAdirecciones.GetInforme(Informe);
        } 
    }
}

