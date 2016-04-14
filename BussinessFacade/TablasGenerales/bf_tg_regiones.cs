using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_regiones
    {
        public co_tg_regiones GetData(int id)
        {
            try
            {
                br_tg_regiones BRregiones = new br_tg_regiones();
                return BRregiones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_regiones> GetData(co_tg_regiones regiones)
        {
            try
            {
                br_tg_regiones BRregiones = new br_tg_regiones();
                return BRregiones.GetData(regiones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_regiones Save(co_tg_regiones regiones)
        {
            try
            {
                br_tg_regiones BRregiones = new br_tg_regiones();
                if (regiones.id == 0)
                {
                    return BRregiones.Insert(regiones);
                }
                else 
                {
                    BRregiones.Update(regiones);
                    return regiones;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_regiones> Save(IList<co_tg_regiones> regioness)
        {
            try
            {
                br_tg_regiones BRregiones = new br_tg_regiones();
                List<co_tg_regiones> ObjReturn = new List<co_tg_regiones>();
                foreach (co_tg_regiones of in regioness) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRregiones.Insert(of));
                    }
                    else 
                    { 
                        BRregiones.Update(of);
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
                br_tg_regiones BRregiones = new br_tg_regiones();
                BRregiones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_regiones_no> GetNomina(co_tg_regiones_no Nomina)
        {
            try
            {
                br_tg_regiones BRregiones = new br_tg_regiones();
                return BRregiones.GetNomina(Nomina);
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
                br_tg_regiones BRregiones = new br_tg_regiones();
                return BRregiones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_regiones BRregiones = new br_tg_regiones();
            return BRregiones.GetInforme(Informe);
        } 
    }
}


