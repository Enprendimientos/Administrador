using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using DataAccess.ControlAcceso;
using Fwp.common;

namespace BussinessRules.ControlAcceso
{
    public class br_ca_usuarios : SCBusinessRules<co_ca_usuarios>
    {
        public br_ca_usuarios(){
             this.myTrans = new FWPTransaction();
        }

        public br_ca_usuarios(FWPTransaction Trans)
        {
            this.myTrans = Trans;
            this.myTrans.MyStates = FWPTransaction.States.Taken;
        }

        public co_ca_usuarios GetData(int id)
        {
            try
            {
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                return DAusuarios.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuarios> GetData(co_ca_usuarios usuarios)
        {
            try
            {
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                return DAusuarios.GetData(usuarios);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuarios Insert(co_ca_usuarios usuarios)
        {
            try
            {
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                return DAusuarios.Insert(usuarios);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuarios> Insert(IList<co_ca_usuarios> usuarios)
        {
            IList<co_ca_usuarios> ilistReturn;
            try
            {
            	this.myTrans.BeginTransaction();
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                ilistReturn = DAusuarios.Insert(usuarios);
                this.myTrans.Commit();
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
            return ilistReturn;
        }

        public void Update(co_ca_usuarios usuarios)
        {
            try
            {
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                DAusuarios.Update(usuarios);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_usuarios> usuarios)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                DAusuarios.Update(usuarios);
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
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                DAusuarios.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_usuarios usuarios)
        {
            try
            {
                this.myTrans.BeginTransaction();            
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                DAusuarios.Delete(usuarios);
                this.myTrans.Commit();                
                
            }
            catch (Exception e)
            {
                this.myTrans.Rollback();            
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuarios_no> GetNomina(co_ca_usuarios_no Nomina)
        {
            try
            {
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                return DAusuarios.GetNomina(Nomina);
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
                da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
                return DAusuarios.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            da_ca_usuarios DAusuarios = new da_ca_usuarios(this.myTrans);
            return DAusuarios.GetInforme(Informe);
        } 
    }
}

