using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_menu: SCDataAccess<co_ca_menu>
    {
        public da_ca_menu(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_menu GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_menu_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menu> GetData(co_ca_menu menu)
        {
            try
            {
                return this.ReadDataGeneric(menu, "pa08_ca_menu_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_menu Insert(co_ca_menu menu)
        {
            try
            {
                return this.CreateDataGeneric(menu, "pa08_ca_menu_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menu> Insert(IList<co_ca_menu> menu)
        {
            try
            {
                return this.CreateDataGeneric(menu, "pa08_ca_menu_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_menu menu)
        {
            try
            {
                this.UpdateDataGeneric(menu, "pa08_ca_menu_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_menu> menu)
        {
            try
            {
                this.UpdateDataGeneric(menu, "pa08_ca_menu_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_menu_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_menu menu)
        {
            try
            {
                this.DeleteDataGeneric(menu, "pa08_ca_menu_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_menu_no> GetNomina(co_ca_menu_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_menu_no> nom = new SCDataAccessNominas<co_ca_menu_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_menu_no", this.Trans);
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

