using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_sexos
    {
        public co_tg_sexos GetData(int id)
        {
            try
            {
                br_tg_sexos BRsexos = new br_tg_sexos();
                return BRsexos.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_sexos> GetData(co_tg_sexos sexos)
        {
            try
            {
                br_tg_sexos BRsexos = new br_tg_sexos();
                return BRsexos.GetData(sexos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_sexos Save(co_tg_sexos sexos)
        {
            try
            {
                br_tg_sexos BRsexos = new br_tg_sexos();
                if (sexos.id == 0)
                {
                    return BRsexos.Insert(sexos);
                }
                else 
                {
                    BRsexos.Update(sexos);
                    return sexos;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_sexos> Save(IList<co_tg_sexos> sexoss)
        {
            try
            {
                br_tg_sexos BRsexos = new br_tg_sexos();
                List<co_tg_sexos> ObjReturn = new List<co_tg_sexos>();
                foreach (co_tg_sexos of in sexoss) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRsexos.Insert(of));
                    }
                    else 
                    { 
                        BRsexos.Update(of);
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
                br_tg_sexos BRsexos = new br_tg_sexos();
                BRsexos.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_sexos_no> GetNomina(co_tg_sexos_no Nomina)
        {
            try
            {
                br_tg_sexos BRsexos = new br_tg_sexos();
                return BRsexos.GetNomina(Nomina);
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
                br_tg_sexos BRsexos = new br_tg_sexos();
                return BRsexos.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_sexos BRsexos = new br_tg_sexos();
            return BRsexos.GetInforme(Informe);
        } 
    }
}


