using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_constantes
    {
        public co_tg_constantes GetData(int id)
        {
            try
            {
                br_tg_constantes BRconstantes = new br_tg_constantes();
                return BRconstantes.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantes> GetData(co_tg_constantes constantes)
        {
            try
            {
                br_tg_constantes BRconstantes = new br_tg_constantes();
                return BRconstantes.GetData(constantes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_constantes Save(co_tg_constantes constantes)
        {
            try
            {
                br_tg_constantes BRconstantes = new br_tg_constantes();
                if (constantes.id == 0)
                {
                    return BRconstantes.Insert(constantes);
                }
                else 
                {
                    BRconstantes.Update(constantes);
                    return constantes;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_constantes> Save(IList<co_tg_constantes> constantess)
        {
            try
            {
                br_tg_constantes BRconstantes = new br_tg_constantes();
                List<co_tg_constantes> ObjReturn = new List<co_tg_constantes>();
                foreach (co_tg_constantes of in constantess) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRconstantes.Insert(of));
                    }
                    else 
                    { 
                        BRconstantes.Update(of);
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
                br_tg_constantes BRconstantes = new br_tg_constantes();
                BRconstantes.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_constantes_no> GetNomina(co_tg_constantes_no Nomina)
        {
            try
            {
                br_tg_constantes BRconstantes = new br_tg_constantes();
                return BRconstantes.GetNomina(Nomina);
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
                br_tg_constantes BRconstantes = new br_tg_constantes();
                return BRconstantes.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_constantes BRconstantes = new br_tg_constantes();
            return BRconstantes.GetInforme(Informe);
        } 
    }
}


