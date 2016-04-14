using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_usuariosperfiles
    {
        public co_ca_usuariosperfiles GetData(int id)
        {
            try
            {
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                return BRusuariosperfiles.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariosperfiles> GetData(co_ca_usuariosperfiles usuariosperfiles)
        {
            try
            {
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                return BRusuariosperfiles.GetData(usuariosperfiles);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuariosperfiles Save(co_ca_usuariosperfiles usuariosperfiles)
        {
            try
            {
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                if (usuariosperfiles.id == 0)
                {
                    return BRusuariosperfiles.Insert(usuariosperfiles);
                }
                else 
                {
                    BRusuariosperfiles.Update(usuariosperfiles);
                    return usuariosperfiles;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariosperfiles> Save(IList<co_ca_usuariosperfiles> usuariosperfiless)
        {
            try
            {
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                List<co_ca_usuariosperfiles> ObjReturn = new List<co_ca_usuariosperfiles>();
                foreach (co_ca_usuariosperfiles of in usuariosperfiless) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRusuariosperfiles.Insert(of));
                    }
                    else 
                    { 
                        BRusuariosperfiles.Update(of);
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
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                BRusuariosperfiles.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuariosperfiles_no> GetNomina(co_ca_usuariosperfiles_no Nomina)
        {
            try
            {
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                return BRusuariosperfiles.GetNomina(Nomina);
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
                br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
                return BRusuariosperfiles.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_usuariosperfiles BRusuariosperfiles = new br_ca_usuariosperfiles();
            return BRusuariosperfiles.GetInforme(Informe);
        } 
    }
}


