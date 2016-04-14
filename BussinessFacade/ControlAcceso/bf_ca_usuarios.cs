using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_usuarios
    {
        public co_ca_usuarios GetData(int id)
        {
            try
            {
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                return BRusuarios.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuarios> GetData(co_ca_usuarios usuarios)
        {
            try
            {
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                return BRusuarios.GetData(usuarios);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuarios Save(co_ca_usuarios usuarios)
        {
            try
            {
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                if (usuarios.id == 0)
                {
                    return BRusuarios.Insert(usuarios);
                }
                else 
                {
                    BRusuarios.Update(usuarios);
                    return usuarios;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuarios> Save(IList<co_ca_usuarios> usuarioss)
        {
            try
            {
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                List<co_ca_usuarios> ObjReturn = new List<co_ca_usuarios>();
                foreach (co_ca_usuarios of in usuarioss) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRusuarios.Insert(of));
                    }
                    else 
                    { 
                        BRusuarios.Update(of);
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
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                BRusuarios.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuarios_no> GetNomina(co_ca_usuarios_no Nomina)
        {
            try
            {
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                return BRusuarios.GetNomina(Nomina);
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
                br_ca_usuarios BRusuarios = new br_ca_usuarios();
                return BRusuarios.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_usuarios BRusuarios = new br_ca_usuarios();
            return BRusuarios.GetInforme(Informe);
        } 
    }
}


