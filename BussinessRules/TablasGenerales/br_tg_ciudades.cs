using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using DataAccess.TablasGenerales;
using Fwp.common;

namespace BussinessRules.TablasGenerales
{
    public class br_tg_ciudades : SCBusinessRules<co_tg_ciudades>
    {
        public br_tg_ciudades(){
             this.myTrans = new FWPTransaction();
        }

        public br_tg_ciudades(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_tg_ciudades GetData(int id)
        {
            try
            {
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                return DAciudades.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_ciudades> GetData(co_tg_ciudades ciudades)
        {
            try
            {
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                return DAciudades.GetData(ciudades);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_ciudades Insert(co_tg_ciudades ciudades)
        {
            try
            {
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                return DAciudades.Insert(ciudades);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_ciudades> Insert(IList<co_tg_ciudades> ciudades)
        {
            IList<co_tg_ciudades> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                ilistReturn = DAciudades.Insert(ciudades);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_tg_ciudades ciudades)
        {
            try
            {
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                DAciudades.Update(ciudades);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_ciudades> ciudades)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                DAciudades.Update(ciudades);
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
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                DAciudades.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_ciudades ciudades)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                DAciudades.Delete(ciudades);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_ciudades_no> GetNomina(co_tg_ciudades_no Nomina)
        {
            try
            {
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                return DAciudades.GetNomina(Nomina);
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
                da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
                return DAciudades.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_tg_ciudades DAciudades = new da_tg_ciudades(this.myTrans);
            return DAciudades.GetInforme(Informe);
        } 
    }
}

