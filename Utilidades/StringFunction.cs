namespace Utilidades
{
  public static class StringFunction
  {
    public static string GetFrameURL(this string url)
    {
      return "<iframe src='" + url + "' frameborder='0' width='100%' height='100%' marginheight='0' marginwidth='0'></iframe>";
    }
  }
}
