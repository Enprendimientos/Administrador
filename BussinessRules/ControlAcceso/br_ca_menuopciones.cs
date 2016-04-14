using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_menuopciones : SCBusinessRules<co_ca_menuopciones>
    {
        public br_ca_menuopciones(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_menuopciones(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_menuopciones GetData(int id)
        {
            try
            {
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                return DAmenuopciones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menuopciones> GetData(co_ca_menuopciones menuopciones)
        {
            try
            {
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                return DAmenuopciones.GetData(menuopciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_menuopciones Insert(co_ca_menuopciones menuopciones)
        {
            try
            {
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                return DAmenuopciones.Insert(menuopciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menuopciones> Insert(IList<co_ca_menuopciones> menuopciones)
        {
            IList<co_ca_menuopciones> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                ilistReturn = DAmenuopciones.Insert(menuopciones);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_menuopciones menuopciones)
        {
            try
            {
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                DAmenuopciones.Update(menuopciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_menuopciones> menuopciones)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                DAmenuopciones.Update(menuopciones);
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
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                DAmenuopciones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_menuopciones menuopciones)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                DAmenuopciones.Delete(menuopciones);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_menuopciones_no> GetNomina(co_ca_menuopciones_no Nomina)
        {
            try
            {
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                return DAmenuopciones.GetNomina(Nomina);
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
                da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
                return DAmenuopciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_menuopciones DAmenuopciones = new da_ca_menuopciones(this.myTrans);
            return DAmenuopciones.GetInforme(Informe);
        } 
    }
}

