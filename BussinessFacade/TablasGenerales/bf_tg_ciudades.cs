using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_ciudades
    {
        public co_tg_ciudades GetData(int id)
        {
            try
            {
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                return BRciudades.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_ciudades> GetData(co_tg_ciudades ciudades)
        {
            try
            {
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                return BRciudades.GetData(ciudades);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_ciudades Save(co_tg_ciudades ciudades)
        {
            try
            {
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                if (ciudades.id == 0)
                {
                    return BRciudades.Insert(ciudades);
                }
                else 
                {
                    BRciudades.Update(ciudades);
                    return ciudades;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_ciudades> Save(IList<co_tg_ciudades> ciudadess)
        {
            try
            {
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                List<co_tg_ciudades> ObjReturn = new List<co_tg_ciudades>();
                foreach (co_tg_ciudades of in ciudadess) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRciudades.Insert(of));
                    }
                    else 
                    { 
                        BRciudades.Update(of);
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
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                BRciudades.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_ciudades_no> GetNomina(co_tg_ciudades_no Nomina)
        {
            try
            {
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                return BRciudades.GetNomina(Nomina);
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
                br_tg_ciudades BRciudades = new br_tg_ciudades();
                return BRciudades.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_ciudades BRciudades = new br_tg_ciudades();
            return BRciudades.GetInforme(Informe);
        } 
    }
}


