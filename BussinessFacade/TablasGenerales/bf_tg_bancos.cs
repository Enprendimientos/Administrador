using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_bancos
    {
        public co_tg_bancos GetData(int id)
        {
            try
            {
                br_tg_bancos BRbancos = new br_tg_bancos();
                return BRbancos.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos> GetData(co_tg_bancos bancos)
        {
            try
            {
                br_tg_bancos BRbancos = new br_tg_bancos();
                return BRbancos.GetData(bancos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancos Save(co_tg_bancos bancos)
        {
            try
            {
                br_tg_bancos BRbancos = new br_tg_bancos();
                if (bancos.id == 0)
                {
                    return BRbancos.Insert(bancos);
                }
                else 
                {
                    BRbancos.Update(bancos);
                    return bancos;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancos> Save(IList<co_tg_bancos> bancoss)
        {
            try
            {
                br_tg_bancos BRbancos = new br_tg_bancos();
                List<co_tg_bancos> ObjReturn = new List<co_tg_bancos>();
                foreach (co_tg_bancos of in bancoss) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRbancos.Insert(of));
                    }
                    else 
                    { 
                        BRbancos.Update(of);
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
                br_tg_bancos BRbancos = new br_tg_bancos();
                BRbancos.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancos_no> GetNomina(co_tg_bancos_no Nomina)
        {
            try
            {
                br_tg_bancos BRbancos = new br_tg_bancos();
                return BRbancos.GetNomina(Nomina);
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
                br_tg_bancos BRbancos = new br_tg_bancos();
                return BRbancos.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_bancos BRbancos = new br_tg_bancos();
            return BRbancos.GetInforme(Informe);
        } 
    }
}


