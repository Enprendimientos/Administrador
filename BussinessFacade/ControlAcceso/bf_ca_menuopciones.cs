using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_menuopciones
    {
        public co_ca_menuopciones GetData(int id)
        {
            try
            {
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                return BRmenuopciones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menuopciones> GetData(co_ca_menuopciones menuopciones)
        {
            try
            {
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                return BRmenuopciones.GetData(menuopciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_menuopciones Save(co_ca_menuopciones menuopciones)
        {
            try
            {
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                if (menuopciones.id == 0)
                {
                    return BRmenuopciones.Insert(menuopciones);
                }
                else 
                {
                    BRmenuopciones.Update(menuopciones);
                    return menuopciones;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_menuopciones> Save(IList<co_ca_menuopciones> menuopcioness)
        {
            try
            {
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                List<co_ca_menuopciones> ObjReturn = new List<co_ca_menuopciones>();
                foreach (co_ca_menuopciones of in menuopcioness) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRmenuopciones.Insert(of));
                    }
                    else 
                    { 
                        BRmenuopciones.Update(of);
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
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                BRmenuopciones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_menuopciones_no> GetNomina(co_ca_menuopciones_no Nomina)
        {
            try
            {
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                return BRmenuopciones.GetNomina(Nomina);
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
                br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
                return BRmenuopciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_menuopciones BRmenuopciones = new br_ca_menuopciones();
            return BRmenuopciones.GetInforme(Informe);
        } 
    }
}


