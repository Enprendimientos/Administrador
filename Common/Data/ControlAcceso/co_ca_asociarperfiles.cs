using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common.Data.ControlAcceso
{
  [Serializable]
  public class co_ca_asociarperfiles : co_ca_perfiles
  {
    private int _id_usuario;

    public co_ca_asociarperfiles()
    {

    }

    [Category("Identity")]
    [Description("SqlDbType=SqlDbType.int, Size=0, Null=False")]
    public int id_usuario
    {
      get { return _id_usuario; }
      set { _id_usuario = value; }
    }
  }
}
