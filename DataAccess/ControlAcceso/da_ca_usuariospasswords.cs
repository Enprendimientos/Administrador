using System;
using System.Collections.Generic;
using System.Data;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace DataAccess.ControlAcceso
{
    public class da_ca_usuariospasswords: SCDataAccess<co_ca_usuariospasswords>
    {
        public da_ca_usuariospasswords(FWPTransaction Transaccion)
        {
            this.Trans = Transaccion;
        }

        public co_ca_usuariospasswords GetData(int id)
        {
            try
            {
                return this.ReadDataGeneric(id, "pa08_ca_usuariospasswords_sel", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariospasswords> GetData(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                return this.ReadDataGeneric(usuariospasswords, "pa08_ca_usuariospasswords_selList", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuariospasswords Insert(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                return this.CreateDataGeneric(usuariospasswords, "pa08_ca_usuariospasswords_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariospasswords> Insert(IList<co_ca_usuariospasswords> usuariospasswords)
        {
            try
            {
                return this.CreateDataGeneric(usuariospasswords, "pa08_ca_usuariospasswords_in", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                this.UpdateDataGeneric(usuariospasswords, "pa08_ca_usuariospasswords_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(IList<co_ca_usuariospasswords> usuariospasswords)
        {
            try
            {
                this.UpdateDataGeneric(usuariospasswords, "pa08_ca_usuariospasswords_ac", this.Trans);
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
                this.DeleteDataGeneric(id, "pa08_ca_usuariospasswords_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                this.DeleteDataGeneric(usuariospasswords, "pa08_ca_usuariospasswords_ac", this.Trans);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuariospasswords_no> GetNomina(co_ca_usuariospasswords_no Nomina)
        {
            try
            {
                 SCDataAccessNominas<co_ca_usuariospasswords_no> nom = new SCDataAccessNominas<co_ca_usuariospasswords_no>();
                 return nom.ReadDataGeneric(Nomina, "pa08_ca_usuariospasswords_no", this.Trans);
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

