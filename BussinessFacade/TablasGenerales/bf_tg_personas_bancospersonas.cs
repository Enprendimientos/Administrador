using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_personas_bancospersonas
    {
        public co_tg_personas_bancospersonas GetData(int id)
        {
            try
            {
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                return BRbancospersonas.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_bancospersonas> GetData(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                return BRbancospersonas.GetData(bancospersonas);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_personas_bancospersonas Save(co_tg_personas_bancospersonas bancospersonas)
        {
            try
            {
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                if (bancospersonas.id == 0)
                {
                    return BRbancospersonas.Insert(bancospersonas);
                }
                else 
                {
                    BRbancospersonas.Update(bancospersonas);
                    return bancospersonas;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_personas_bancospersonas> Save(IList<co_tg_personas_bancospersonas> bancospersonass)
        {
            try
            {
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                List<co_tg_personas_bancospersonas> ObjReturn = new List<co_tg_personas_bancospersonas>();
                foreach (co_tg_personas_bancospersonas of in bancospersonass) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRbancospersonas.Insert(of));
                    }
                    else 
                    { 
                        BRbancospersonas.Update(of);
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
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                BRbancospersonas.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_personas_bancospersonas_no> GetNomina(co_tg_personas_bancospersonas_no Nomina)
        {
            try
            {
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                return BRbancospersonas.GetNomina(Nomina);
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
                br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
                return BRbancospersonas.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_personas_bancospersonas BRbancospersonas = new br_tg_personas_bancospersonas();
            return BRbancospersonas.GetInforme(Informe);
        } 
    }
}


