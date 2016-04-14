using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_opciones
    {
        public co_ca_opciones GetData(int id)
        {
            try
            {
                br_ca_opciones BRopciones = new br_ca_opciones();
                return BRopciones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_opciones> GetData(co_ca_opciones opciones)
        {
            try
            {
                br_ca_opciones BRopciones = new br_ca_opciones();
                return BRopciones.GetData(opciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_opciones Save(co_ca_opciones opciones)
        {
            try
            {
                br_ca_opciones BRopciones = new br_ca_opciones();
                if (opciones.id == 0)
                {
                    return BRopciones.Insert(opciones);
                }
                else 
                {
                    BRopciones.Update(opciones);
                    return opciones;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_opciones> Save(IList<co_ca_opciones> opcioness)
        {
            try
            {
                br_ca_opciones BRopciones = new br_ca_opciones();
                List<co_ca_opciones> ObjReturn = new List<co_ca_opciones>();
                foreach (co_ca_opciones of in opcioness) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRopciones.Insert(of));
                    }
                    else 
                    { 
                        BRopciones.Update(of);
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
                br_ca_opciones BRopciones = new br_ca_opciones();
                BRopciones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_opciones_no> GetNomina(co_ca_opciones_no Nomina)
        {
            try
            {
                br_ca_opciones BRopciones = new br_ca_opciones();
                return BRopciones.GetNomina(Nomina);
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
                br_ca_opciones BRopciones = new br_ca_opciones();
                return BRopciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_opciones BRopciones = new br_ca_opciones();
            return BRopciones.GetInforme(Informe);
        } 
    }
}


