using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_bancospaises
    {
        public co_tg_bancospaises GetData(int id)
        {
            try
            {
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                return BRbancospaises.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancospaises> GetData(co_tg_bancospaises bancospaises)
        {
            try
            {
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                return BRbancospaises.GetData(bancospaises);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_bancospaises Save(co_tg_bancospaises bancospaises)
        {
            try
            {
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                if (bancospaises.id == 0)
                {
                    return BRbancospaises.Insert(bancospaises);
                }
                else 
                {
                    BRbancospaises.Update(bancospaises);
                    return bancospaises;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_bancospaises> Save(IList<co_tg_bancospaises> bancospaisess)
        {
            try
            {
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                List<co_tg_bancospaises> ObjReturn = new List<co_tg_bancospaises>();
                foreach (co_tg_bancospaises of in bancospaisess) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRbancospaises.Insert(of));
                    }
                    else 
                    { 
                        BRbancospaises.Update(of);
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
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                BRbancospaises.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_bancospaises_no> GetNomina(co_tg_bancospaises_no Nomina)
        {
            try
            {
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                return BRbancospaises.GetNomina(Nomina);
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
                br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
                return BRbancospaises.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_bancospaises BRbancospaises = new br_tg_bancospaises();
            return BRbancospaises.GetInforme(Informe);
        } 
    }
}


