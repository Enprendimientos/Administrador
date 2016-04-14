using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_perfilesopciones
    {
        public co_ca_perfilesopciones GetData(int id)
        {
            try
            {
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                return BRperfilesopciones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfilesopciones> GetData(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                return BRperfilesopciones.GetData(perfilesopciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_perfilesopciones Save(co_ca_perfilesopciones perfilesopciones)
        {
            try
            {
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                if (perfilesopciones.id == 0)
                {
                    return BRperfilesopciones.Insert(perfilesopciones);
                }
                else 
                {
                    BRperfilesopciones.Update(perfilesopciones);
                    return perfilesopciones;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfilesopciones> Save(IList<co_ca_perfilesopciones> perfilesopcioness)
        {
            try
            {
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                List<co_ca_perfilesopciones> ObjReturn = new List<co_ca_perfilesopciones>();
                foreach (co_ca_perfilesopciones of in perfilesopcioness) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRperfilesopciones.Insert(of));
                    }
                    else 
                    { 
                        BRperfilesopciones.Update(of);
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
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                BRperfilesopciones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_perfilesopciones_no> GetNomina(co_ca_perfilesopciones_no Nomina)
        {
            try
            {
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                return BRperfilesopciones.GetNomina(Nomina);
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
                br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
                return BRperfilesopciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_perfilesopciones BRperfilesopciones = new br_ca_perfilesopciones();
            return BRperfilesopciones.GetInforme(Informe);
        } 
    }
}


