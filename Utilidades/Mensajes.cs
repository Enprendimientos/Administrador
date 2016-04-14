using Ext.Net;

namespace Utilidades
{
  public class Mensajes : MessageBox
  {
    /// <summary>
    /// Metodo que envía una Alerta por pantalla hacia el Usuario
    /// </summary>
    /// <param name="titulo">Título del Mensaje para el Usuario</param>
    /// <param name="mensaje">Mensaje que verá el Usuario por Pantalla</param>
    /// <param name="icon">Puede ser INFO, ERROR, NONE(nada), WARNING, QUESTION</param>
    public static void Show(string titulo, string mensaje, Icon icon = Icon.NONE)
    {
      X.MessageBox.Show(new MessageBoxConfig
      {
        Title = titulo,
        Message = mensaje,
        Icon = icon,
        Buttons = Button.OK
      });
    }
    /// <summary>
    /// Metodo Preferencial para registrar Mensajes de Error por Pantalla, Título por Defecto sera "Error" 
    /// y el Icono será del Tipo Icon.ERROR
    /// </summary>
    /// <param name="mensaje"></param>
    public static void Error(string mensaje)
    {
      X.MessageBox.Show(new MessageBoxConfig
      {
        Title = "Error",
        Message = mensaje,
        Icon = Icon.ERROR,
        Buttons = Button.OK
      });
    }
    /// <summary>
    /// Metodo Confirm que se utiliza para realizar preguntas para el Usuario.
    /// </summary>
    /// <param name="titulo">Titulo del Mensaje</param>
    /// <param name="mensaje">Mensaje para el Usuario</param>
    /// <param name="handlerBtnAceptar">Nombre del DirectMethod que se Ejecutara al Presionar SI</param>
    /// <param name="handlerBtnCancelar">Nombre del DirectMethos que se Ejecutara al Presionar NO</param>
    /// <param name="btnAceptar">Nombre del Boton, "Si" por defecto</param>
    /// <param name="btnCancelar">Nombre del Boton, "No" por defecto</param>
    public static void Confirm(string titulo, string mensaje, string handlerBtnAceptar, string handlerBtnCancelar, string btnAceptar = "Si", string btnCancelar = "No")
    {
      X.MessageBox.Confirm(
        titulo,
        mensaje,
        new MessageBoxButtonsConfig
        {
          Yes = new MessageBoxButtonConfig
          {
            Handler = handlerBtnAceptar,
            Text = btnAceptar
          },
          No = new MessageBoxButtonConfig
          {
            Handler = handlerBtnCancelar,
            Text = btnCancelar
          }
        }).Show();

    }
    /// <summary>
    /// Metodo que envía una Alerta por pantalla hacia el Usuario
    /// </summary>
    /// <param name="titulo">Título del Mensaje para el Usuario</param>
    /// <param name="mensaje">Mensaje que verá el Usuario por Pantalla</param>
    /// <param name="handler">Funcion que se ejecutara despues de haber mostrado el mensaje</param>
    /// <param name="icon">Puede ser INFO, ERROR, NONE(nada), WARNING, QUESTION</param>
    public static void Show(string titulo, string mensaje, string handler, Icon icon = Icon.NONE)
    {
      X.MessageBox.Show(new MessageBoxConfig
      {
        Title = titulo,
        Message = mensaje,
        Icon = icon,
        Buttons = Button.OK,
        Handler = handler
      });
    }

  }
}