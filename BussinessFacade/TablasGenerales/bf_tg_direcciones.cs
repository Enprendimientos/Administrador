using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.TablasGenerales;
using Common.Data.TablasGenerales;
using Common.Nomina.Negocio;
using Fwp.common;

namespace BussinessFacade.TablasGenerales
{
    public class bf_tg_direcciones
    {
        public co_tg_direcciones GetData(int id)
        {
            try
            {
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                return BRdirecciones.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_direcciones> GetData(co_tg_direcciones direcciones)
        {
            try
            {
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                return BRdirecciones.GetData(direcciones);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_tg_direcciones Save(co_tg_direcciones direcciones)
        {
            try
            {
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                if (direcciones.id == 0)
                {
                    return BRdirecciones.Insert(direcciones);
                }
                else 
                {
                    BRdirecciones.Update(direcciones);
                    return direcciones;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_tg_direcciones> Save(IList<co_tg_direcciones> direccioness)
        {
            try
            {
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                List<co_tg_direcciones> ObjReturn = new List<co_tg_direcciones>();
                foreach (co_tg_direcciones of in direccioness) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRdirecciones.Insert(of));
                    }
                    else 
                    { 
                        BRdirecciones.Update(of);
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
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                BRdirecciones.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_tg_direcciones_no> GetNomina(co_tg_direcciones_no Nomina)
        {
            try
            {
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                return BRdirecciones.GetNomina(Nomina);
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
                br_tg_direcciones BRdirecciones = new br_tg_direcciones();
                return BRdirecciones.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_tg_direcciones BRdirecciones = new br_tg_direcciones();
            return BRdirecciones.GetInforme(Informe);
        } 
    }
}


