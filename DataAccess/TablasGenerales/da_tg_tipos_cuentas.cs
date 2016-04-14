using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_tipos_cuentas: SCDataAccess<co_tg_tipos_cuentas>
    {
        public da_tg_tipos_cuentas(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_tipos_cuentas GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_tipos_cuentas_sel", this.Trans);
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
                return this.ReadDataGeneric(cuentas, "pa08_tg_tipos_cuentas_selList", this.Trans);
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
                return this.CreateDataGeneric(cuentas, "pa08_tg_tipos_cuentas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_tipos_cuentas> Insert(IList<co_tg_tipos_cuentas> cuentas)
        {
            try
            {
                return this.CreateDataGeneric(cuentas, "pa08_tg_tipos_cuentas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_tipos_cuentas cuentas)
        {
            try
            {
                this.UpdateDataGeneric(cuentas, "pa08_tg_tipos_cuentas_ac", this.Trans);
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
                this.UpdateDataGeneric(cuentas, "pa08_tg_tipos_cuentas_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_tipos_cuentas_ac", this.Trans);
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
                this.DeleteDataGeneric(cuentas, "pa08_tg_tipos_cuentas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_tipos_cuentas_no> GetNomina(co_tg_tipos_cuentas_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_tipos_cuentas_no> nom = new SCDataAccessNominas<co_tg_tipos_cuentas_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_tipos_cuentas_no", this.Trans);
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

