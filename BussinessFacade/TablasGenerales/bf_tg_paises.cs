using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_paises
    {
        public co_tg_paises GetData(int id)
        {
            try
            {
                br_tg_paises BRpaises = new br_tg_paises();
                return BRpaises.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_paises> GetData(co_tg_paises paises)
        {
            try
            {
                br_tg_paises BRpaises = new br_tg_paises();
                return BRpaises.GetData(paises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_paises Save(co_tg_paises paises)
        {
            try
            {
                br_tg_paises BRpaises = new br_tg_paises();
                if (paises.id == 0)
                {
                    return BRpaises.Insert(paises);
                }
                else 
                {
                    BRpaises.Update(paises);
                    return paises;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_paises> Save(IList<co_tg_paises> paisess)
        {
            try
            {
                br_tg_paises BRpaises = new br_tg_paises();
                List<co_tg_paises> ObjReturn = new List<co_tg_paises>();
                foreach (co_tg_paises of in paisess) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRpaises.Insert(of));
                    }
                    else 
                    { 
                        BRpaises.Update(of);
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
                br_tg_paises BRpaises = new br_tg_paises();
                BRpaises.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_paises_no> GetNomina(co_tg_paises_no Nomina)
        {
            try
            {
                br_tg_paises BRpaises = new br_tg_paises();
                return BRpaises.GetNomina(Nomina);
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
                br_tg_paises BRpaises = new br_tg_paises();
                return BRpaises.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_paises BRpaises = new br_tg_paises();
            return BRpaises.GetInforme(Informe);
        } 
    }
}


