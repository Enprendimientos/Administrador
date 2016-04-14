using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_constantes: SCDataAccess<co_tg_constantes>
    {
        public da_tg_constantes(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_constantes GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_constantes_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantes> GetData(co_tg_constantes constantes)
        {
            try
            {
                return this.ReadDataGeneric(constantes, "pa08_tg_constantes_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_constantes Insert(co_tg_constantes constantes)
        {
            try
            {
                return this.CreateDataGeneric(constantes, "pa08_tg_constantes_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantes> Insert(IList<co_tg_constantes> constantes)
        {
            try
            {
                return this.CreateDataGeneric(constantes, "pa08_tg_constantes_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_constantes constantes)
        {
            try
            {
                this.UpdateDataGeneric(constantes, "pa08_tg_constantes_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_constantes> constantes)
        {
            try
            {
                this.UpdateDataGeneric(constantes, "pa08_tg_constantes_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.DeleteDataGeneric(id, "pa08_tg_constantes_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_constantes constantes)
        {
            try
            {
                this.DeleteDataGeneric(constantes, "pa08_tg_constantes_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_constantes_no> GetNomina(co_tg_constantes_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_constantes_no> nom = new SCDataAccessNominas<co_tg_constantes_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_constantes_no", this.Trans);
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
                SCDataAccessInformes<String> inf = new SCDataAccessInformes<String>();
                return inf.ReadDataGeneric(SQLText, this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe){
            //SCDataAccessInformes<T> inf = new SCDataAccessInformes<T>();
            //return inf.ReadDataGeneric(Informe, "", this.Trans);
            return new List<T>();
        } 

    }
}

