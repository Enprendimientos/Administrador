using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Administrador.RefreshPage;
using BussinessFacade.ControlAcceso;
using Common.Data.ControlAcceso;
using Ext.Net;
using Utilidades;

namespace Administrador.ControlAcceso
{
  public partial class AsociarOpcionesPerfil : BasePage
  {
    protected override void Page_Load(object sender, EventArgs e)
    {
      base.Page_Load(sender, e);
      if (!IsPostBack && !X.IsAjaxRequest)
      {
        string tipo = Request.QueryString["op"];
        string id = Request.QueryString["id"];

        switch (tipo)
        {
          case "in":
            Ingreso(id);
            break;
          case "op":
            break;
          case "el":
            break;
        }
      }
    }

    public void Ingreso(string id)
    {
      hid_id.Text = id;
      CompletarValores(id);
    }

    public void CompletarValores(string id)
    {
      int idPerfil = id.ValidaEntero("id_perfil");
      IList<co_ca_opciones> listNoDisponibles = new List<co_ca_opciones>();
      IList<co_ca_opciones> listOpciones = new bf_ca_opciones().GetData(new co_ca_opciones());
      IList<co_ca_opciones> listDisponibles = new List<co_ca_opciones>();

      IList<co_ca_perfilesopciones> listOpcionesNoDisponibles = new bf_ca_perfilesopciones().GetData(new co_ca_perfilesopciones { id_perfil = { id = idPerfil } });

      foreach (co_ca_opciones opcion in listOpciones)
      {
        bool sw = true;
        var opcion1 = opcion;
        foreach (co_ca_perfilesopciones disponible in listOpcionesNoDisponibles.Where(c => c.id_opcion.id == opcion1.id_opcion).Select(opciones => new co_ca_perfilesopciones()))
        {
          sw = false;
        }
        if (sw)
        {
          listDisponibles.Add(opcion1);
        }

      }

      foreach (co_ca_perfilesopciones opcion in listOpcionesNoDisponibles)
      {
        listNoDisponibles.Add(new co_ca_opciones { id_opcion = opcion.id_opcion.id, opci_opcion = opcion.id_opcion.descripcion });
      }

      grdOpcionesDisponibles.GetStore().DataSource = listDisponibles.OrderBy(c => c.opci_opcion);
      grdOpcionesDisponibles.GetStore().DataBind();

      grdOpcionesNoDisponibles.GetStore().DataSource = listNoDisponibles.OrderBy(c => c.opci_opcion);
      grdOpcionesNoDisponibles.GetStore().DataBind();
    }

    protected void Drop(object sender, DirectEventArgs e)
    {
      string jsonArray = e.ExtraParams["records"];
      string mode = e.ExtraParams["mode"];
      IList<object> records = JSON.Deserialize<List<object>>(jsonArray);
      foreach (dynamic record in records)
      {
        string idOpcion = (string)record.id_opcion;
        int id_opcion = idOpcion.ValidaEntero("id_opcion");
        if (mode == "asocia")
        {
          Asocia(id_opcion);
          Notification.Show(new NotificationConfig
          {
            Title = "Notificación",
            Html = record.op_opcion + " Asociado",
            Closable = true,
            Icon = Icon.Information
          });
        }
        else
        {
          Desasocia(id_opcion);
          Notification.Show(new NotificationConfig
          {
            Title = "Notificación",
            Html = record.op_opcion + " Desasociado",
            Closable = true,
            Icon = Icon.Information
          });
        }
      }
    }

    private void Asocia(int id_opcion)
    {
      try
      {
        int id_perfil = hid_id.Text.ValidaEntero(hid_id.FieldLabel);
        co_ca_perfilesopciones perfilesopciones = new co_ca_perfilesopciones();
        perfilesopciones.id_opcion.id = id_opcion;
        perfilesopciones.id_perfil.id = id_perfil;

        new bf_ca_perfilesopciones().Save(perfilesopciones);
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }

    private void Desasocia(int id_opcion)
    {
      try
      {
        int id_perfil = hid_id.Text.ValidaEntero(hid_id.FieldLabel);
        co_ca_perfilesopciones perfilesopciones = new co_ca_perfilesopciones();
        perfilesopciones.id_opcion.id = id_opcion;
        perfilesopciones.id_perfil.id = id_perfil;

        var list = new bf_ca_perfilesopciones().GetData(perfilesopciones);
        if (list.Any() && list.Count == 1)
        {
          new bf_ca_perfilesopciones().Delete(list.FirstOrDefault().id_perfilopcion);
        }
      }
      catch (Exception ex)
      {
        Mensajes.Error(ex.Message);
      }
    }
  }
}