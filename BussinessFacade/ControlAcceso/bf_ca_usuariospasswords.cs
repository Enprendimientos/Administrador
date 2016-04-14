using System;
using System.Collections.Generic;
using System.Data;
using BussinessRules.ControlAcceso;
using Common.Data.ControlAcceso;
using Common.Nomina.ControlAcceso;
using Fwp.common;

namespace BussinessFacade.ControlAcceso
{
    public class bf_ca_usuariospasswords
    {
        public co_ca_usuariospasswords GetData(int id)
        {
            try
            {
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                return BRusuariospasswords.GetData(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariospasswords> GetData(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                return BRusuariospasswords.GetData(usuariospasswords);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public co_ca_usuariospasswords Save(co_ca_usuariospasswords usuariospasswords)
        {
            try
            {
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                if (usuariospasswords.id == 0)
                {
                    return BRusuariospasswords.Insert(usuariospasswords);
                }
                else 
                {
                    BRusuariospasswords.Update(usuariospasswords);
                    return usuariospasswords;
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<co_ca_usuariospasswords> Save(IList<co_ca_usuariospasswords> usuariospasswordss)
        {
            try
            {
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                List<co_ca_usuariospasswords> ObjReturn = new List<co_ca_usuariospasswords>();
                foreach (co_ca_usuariospasswords of in usuariospasswordss) 
                {
                    if (of.id == 0)
                    {
                       ObjReturn.Add(BRusuariospasswords.Insert(of));
                    }
                    else 
                    { 
                        BRusuariospasswords.Update(of);
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
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                BRusuariospasswords.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Nomina<co_ca_usuariospasswords_no> GetNomina(co_ca_usuariospasswords_no Nomina)
        {
            try
            {
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                return BRusuariospasswords.GetNomina(Nomina);
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
                br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
                return BRusuariospasswords.GetInforme(SQLText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<T> GetInforme<T>(T Informe)
        {
            br_ca_usuariospasswords BRusuariospasswords = new br_ca_usuariospasswords();
            return BRusuariospasswords.GetInforme(Informe);
        } 
    }
}


