using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_constantestipos: SCDataAccess<co_tg_constantestipos>
    {
        public da_tg_constantestipos(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_constantestipos GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_constantestipos_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantestipos> GetData(co_tg_constantestipos constantestipos)
        {
            try
            {
                return this.ReadDataGeneric(constantestipos, "pa08_tg_constantestipos_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_constantestipos Insert(co_tg_constantestipos constantestipos)
        {
            try
            {
                return this.CreateDataGeneric(constantestipos, "pa08_tg_constantestipos_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantestipos> Insert(IList<co_tg_constantestipos> constantestipos)
        {
            try
            {
                return this.CreateDataGeneric(constantestipos, "pa08_tg_constantestipos_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_constantestipos constantestipos)
        {
            try
            {
                this.UpdateDataGeneric(constantestipos, "pa08_tg_constantestipos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_constantestipos> constantestipos)
        {
            try
            {
                this.UpdateDataGeneric(constantestipos, "pa08_tg_constantestipos_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_constantestipos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_constantestipos constantestipos)
        {
            try
            {
                this.DeleteDataGeneric(constantestipos, "pa08_tg_constantestipos_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_constantestipos_no> GetNomina(co_tg_constantestipos_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_constantestipos_no> nom = new SCDataAccessNominas<co_tg_constantestipos_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_constantestipos_no", this.Trans);
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

