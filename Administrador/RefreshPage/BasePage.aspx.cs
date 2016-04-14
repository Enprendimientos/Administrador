using System;
using System.Web.UI;

namespace Administrador.RefreshPage
{
  public partial class BasePage : Page
  {
    protected virtual void Page_Load(object sender, EventArgs e)
    {
      Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));
      if (Session["SesionActiva"]==null)
      {
        //Response.Redirect("~/Default.aspx");
      }
    }
  }
}