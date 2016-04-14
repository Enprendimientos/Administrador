using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_estados_civiles
    {
        public co_tg_estados_civiles GetData(int id)
        {
            try
            {
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                return BRciviles.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_estados_civiles> GetData(co_tg_estados_civiles civiles)
        {
            try
            {
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                return BRciviles.GetData(civiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_estados_civiles Save(co_tg_estados_civiles civiles)
        {
            try
            {
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                if (civiles.id == 0)
                {
                    return BRciviles.Insert(civiles);
                }
                else 
                {
                    BRciviles.Update(civiles);
                    return civiles;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_estados_civiles> Save(IList<co_tg_estados_civiles> civiless)
        {
            try
            {
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                List<co_tg_estados_civiles> ObjReturn = new List<co_tg_estados_civiles>();
                foreach (co_tg_estados_civiles of in civiless) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRciviles.Insert(of));
                    }
                    else 
                    { 
                        BRciviles.Update(of);
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
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                BRciviles.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_estados_civiles_no> GetNomina(co_tg_estados_civiles_no Nomina)
        {
            try
            {
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                return BRciviles.GetNomina(Nomina);
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
                br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
                return BRciviles.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_estados_civiles BRciviles = new br_tg_estados_civiles();
            return BRciviles.GetInforme(Informe);
        } 
    }
}


