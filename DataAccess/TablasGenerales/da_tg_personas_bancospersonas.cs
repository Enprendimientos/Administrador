using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace DataAccess.TablasGenerales
{
    public class da_tg_personas_bancospersonas: SCDataAccess<co_tg_personas_bancospersonas>
    {
        public da_tg_personas_bancospersonas(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_tg_personas_bancospersonas GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_tg_personas_bancospersonas_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_bancospersonas> GetData(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                return this.ReadDataGeneric(bancospersonas, "pa08_tg_personas_bancospersonas_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_personas_bancospersonas Insert(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                return this.CreateDataGeneric(bancospersonas, "pa08_tg_personas_bancospersonas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_bancospersonas> Insert(IList<co_tg_personas_bancospersonas> bancospersonas)
        {
            try
            {
                return this.CreateDataGeneric(bancospersonas, "pa08_tg_personas_bancospersonas_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                this.UpdateDataGeneric(bancospersonas, "pa08_tg_personas_bancospersonas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_tg_personas_bancospersonas> bancospersonas)
        {
            try
            {
                this.UpdateDataGeneric(bancospersonas, "pa08_tg_personas_bancospersonas_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_tg_personas_bancospersonas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                this.DeleteDataGeneric(bancospersonas, "pa08_tg_personas_bancospersonas_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_personas_bancospersonas_no> GetNomina(co_tg_personas_bancospersonas_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_tg_personas_bancospersonas_no> nom = new SCDataAccessNominas<co_tg_personas_bancospersonas_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_tg_personas_bancospersonas_no", this.Trans);
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

