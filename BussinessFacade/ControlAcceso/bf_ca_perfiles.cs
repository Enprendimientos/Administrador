using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_perfiles
    {
        public co_ca_perfiles GetData(int id)
        {
            try
            {
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                return BRperfiles.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfiles> GetData(co_ca_perfiles perfiles)
        {
            try
            {
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                return BRperfiles.GetData(perfiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_perfiles Save(co_ca_perfiles perfiles)
        {
            try
            {
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                if (perfiles.id == 0)
                {
                    return BRperfiles.Insert(perfiles);
                }
                else 
                {
                    BRperfiles.Update(perfiles);
                    return perfiles;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_perfiles> Save(IList<co_ca_perfiles> perfiless)
        {
            try
            {
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                List<co_ca_perfiles> ObjReturn = new List<co_ca_perfiles>();
                foreach (co_ca_perfiles of in perfiless) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRperfiles.Insert(of));
                    }
                    else 
                    { 
                        BRperfiles.Update(of);
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
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                BRperfiles.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_perfiles_no> GetNomina(co_ca_perfiles_no Nomina)
        {
            try
            {
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                return BRperfiles.GetNomina(Nomina);
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
                br_ca_perfiles BRperfiles = new br_ca_perfiles();
                return BRperfiles.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_perfiles BRperfiles = new br_ca_perfiles();
            return BRperfiles.GetInforme(Informe);
        } 
    }
}


