using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_tipos_cuentas
    {
        public co_tg_tipos_cuentas GetData(int id)
        {
            try
            {
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                return BRcuentas.GetData(id);
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
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                return BRcuentas.GetData(cuentas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_tipos_cuentas Save(co_tg_tipos_cuentas cuentas)
        {
            try
            {
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                if (cuentas.id == 0)
                {
                    return BRcuentas.Insert(cuentas);
                }
                else 
                {
                    BRcuentas.Update(cuentas);
                    return cuentas;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_tipos_cuentas> Save(IList<co_tg_tipos_cuentas> cuentass)
        {
            try
            {
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                List<co_tg_tipos_cuentas> ObjReturn = new List<co_tg_tipos_cuentas>();
                foreach (co_tg_tipos_cuentas of in cuentass) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRcuentas.Insert(of));
                    }
                    else 
                    { 
                        BRcuentas.Update(of);
                        ObjReturn.Add(of);
                    }
                }
                return ObjReturn;
                
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
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                BRcuentas.Delete(id);
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
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                return BRcuentas.GetNomina(Nomina);
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
                br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
                return BRcuentas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_tipos_cuentas BRcuentas = new br_tg_tipos_cuentas();
            return BRcuentas.GetInforme(Informe);
        } 
    }
}


