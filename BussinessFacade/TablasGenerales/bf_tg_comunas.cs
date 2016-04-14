using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_comunas
    {
        public co_tg_comunas GetData(int id)
        {
            try
            {
                br_tg_comunas BRcomunas = new br_tg_comunas();
                return BRcomunas.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_comunas> GetData(co_tg_comunas comunas)
        {
            try
            {
                br_tg_comunas BRcomunas = new br_tg_comunas();
                return BRcomunas.GetData(comunas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_comunas Save(co_tg_comunas comunas)
        {
            try
            {
                br_tg_comunas BRcomunas = new br_tg_comunas();
                if (comunas.id == 0)
                {
                    return BRcomunas.Insert(comunas);
                }
                else 
                {
                    BRcomunas.Update(comunas);
                    return comunas;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_comunas> Save(IList<co_tg_comunas> comunass)
        {
            try
            {
                br_tg_comunas BRcomunas = new br_tg_comunas();
                List<co_tg_comunas> ObjReturn = new List<co_tg_comunas>();
                foreach (co_tg_comunas of in comunass) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRcomunas.Insert(of));
                    }
                    else 
                    { 
                        BRcomunas.Update(of);
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
                br_tg_comunas BRcomunas = new br_tg_comunas();
                BRcomunas.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_comunas_no> GetNomina(co_tg_comunas_no Nomina)
        {
            try
            {
                br_tg_comunas BRcomunas = new br_tg_comunas();
                return BRcomunas.GetNomina(Nomina);
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
                br_tg_comunas BRcomunas = new br_tg_comunas();
                return BRcomunas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_comunas BRcomunas = new br_tg_comunas();
            return BRcomunas.GetInforme(Informe);
        } 
    }
}


