using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_usuarios: SCDataAccess<co_ca_usuarios>
    {
        public da_ca_usuarios(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_usuarios GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_usuarios_sel", this.Trans);
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
                return this.ReadDataGeneric(usuarios, "pa08_ca_usuarios_selList", this.Trans);
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
                return this.CreateDataGeneric(usuarios, "pa08_ca_usuarios_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuarios> Insert(IList<co_ca_usuarios> usuarios)
        {
            try
            {
                return this.CreateDataGeneric(usuarios, "pa08_ca_usuarios_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_usuarios usuarios)
        {
            try
            {
                this.UpdateDataGeneric(usuarios, "pa08_ca_usuarios_ac", this.Trans);
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
                this.UpdateDataGeneric(usuarios, "pa08_ca_usuarios_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_usuarios_ac", this.Trans);
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
                this.DeleteDataGeneric(usuarios, "pa08_ca_usuarios_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuarios_no> GetNomina(co_ca_usuarios_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_usuarios_no> nom = new SCDataAccessNominas<co_ca_usuarios_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_usuarios_no", this.Trans);
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

