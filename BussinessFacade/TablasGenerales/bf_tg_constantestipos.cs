using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_constantestipos
    {
        public co_tg_constantestipos GetData(int id)
        {
            try
            {
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                return BRconstantestipos.GetData(id);
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
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                return BRconstantestipos.GetData(constantestipos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_constantestipos Save(co_tg_constantestipos constantestipos)
        {
            try
            {
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                if (constantestipos.id == 0)
                {
                    return BRconstantestipos.Insert(constantestipos);
                }
                else 
                {
                    BRconstantestipos.Update(constantestipos);
                    return constantestipos;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantestipos> Save(IList<co_tg_constantestipos> constantestiposs)
        {
            try
            {
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                List<co_tg_constantestipos> ObjReturn = new List<co_tg_constantestipos>();
                foreach (co_tg_constantestipos of in constantestiposs) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRconstantestipos.Insert(of));
                    }
                    else 
                    { 
                        BRconstantestipos.Update(of);
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
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                BRconstantestipos.Delete(id);
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
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                return BRconstantestipos.GetNomina(Nomina);
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
                br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
                return BRconstantestipos.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_constantestipos BRconstantestipos = new br_tg_constantestipos();
            return BRconstantestipos.GetInforme(Informe);
        } 
    }
}


