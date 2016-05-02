<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="Administrador.Desktop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador General</title>
<script type="text/javascript">
    function title() {
      Ext.net.Desktop.desktop.tileWindows();
    }

    function cascade() {
      Ext.net.Desktop.desktop.cascadeWindows();
    }

    function OpenWindow(_titulo, _url, _id, _icono) {
      Ext.net.DirectMethod.request('OpenNewWindow', {
        params: {
          titulo: _titulo,
          url: _url,
          id: _id,
          icono: _icono
        },
        success: function (response) {

        },
        failure: function (e) {
          Ext.Msg.alert("Error", "Se ha Producido un Error Mientras se Intentaba Abrir la Ventana");
        },
        eventMask: {
          showMask: true,
          msg: "Abriendo..."
        }
      });
    }

    function createWindow2(_titulo, _id, _url, w, h, nombreVentana) {
      Ext.net.DirectMethod.request('OpenNewWindow2', {
        params: {
          titulo: _titulo,
          url: _url,
          id: _id,
          icono: '#Application'
        },
        success: function (response) {

        },
        failure: function (e) {
          Ext.Msg.alert("Error", "Se ha Producido un Error Mientras se Intentaba Abrir la Ventana");
        },
        eventMask: {
          showMask: true,
          msg: "Abriendo..."
        }
      });
    }
  </script>
</head>
<body>
 <ext:ResourceManager ID="ResourceManager1" runat="server" IDMode="Inherit" Locale="es-ES">
    
  </ext:ResourceManager>
  <ext:Desktop runat="server" ID="dskPrincipal">
    <StartMenu MinHeight="300" Height="300" Icon="User">
      <ToolConfig>
        <ext:Toolbar ID="Toolbar1" runat="server" Width="125">
          <Items>
            <ext:Button runat="server" Icon="Key" Text="Cerrar Sesión" ID="btnCerrar">
              <DirectEvents>
                <Click OnEvent="btnCerrarSesion_Click">
                  <EventMask ShowMask="True" Msg="Cerrando Sesión" MinDelay="1000" />
                </Click>
              </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button1" runat="server" Icon="Cog" Text="Mi Perfil">
              <DirectEvents>
                <Click OnEvent="Button_WindowDesktop">
                  <EventMask ShowMask="True" Msg="Cargando..."/>
                  <ExtraParams>
                    <ext:Parameter Name="icono" Value="#UserEdit" />
                    <ext:Parameter Name="title" Value="Mi Perfil"/>
                    <ext:Parameter Name="id" Value="cf"/>
                    <ext:Parameter Name="url" Value="ConfigurarPerfil.aspx"/>
                  </ExtraParams>
                </Click>
              </DirectEvents>
            </ext:Button>
          </Items>
        </ext:Toolbar>
      </ToolConfig>
    </StartMenu>
    <TaskBar TrayWidth="130" QuickStartWidth="35">
      <CustomConfig>
        <ext:ConfigItem Name="startBtnText" Value="Inicio" Mode="Value" />  
      </CustomConfig>
      <QuickStart>
        <ext:Toolbar ID="Toolbar2" runat="server">
          <Items>
            <ext:Button ID="Button2" runat="server" Handler="title" Icon="ApplicationTileVertical" Text="Título Window">
              <QTipCfg Text="Título Windows" />
            </ext:Button>
            <ext:Button ID="Button3" runat="server" Handler="cascade" Icon="ApplicationCascade" Text="Cascada Window">
              <QTipCfg Text="Cascada Windows"></QTipCfg>
            </ext:Button>
          </Items>
        </ext:Toolbar>
      </QuickStart>
      <Tray>
        <ext:Toolbar ID="Toolbar3" runat="server">
          <Items>
            <ext:Button runat="server" ID="btnPerfil" MenuArrow="False" Cls="x-bold-text" MenuAlign="br-tr">             
            </ext:Button>
          </Items>
        </ext:Toolbar>
      </Tray>
    </TaskBar>
    <DesktopConfig ShortcutDragSelector="True" Wallpaper="Resources/Images/wallpapers/fondo0.jpg" WallpaperStretch="True">
      <ContextMenu>
        <ext:Menu ID="Menu1" runat="server">
          <Items>
            <ext:MenuItem ID="MenuItem1" runat="server" Text="Crear Acceso Directo" Icon="ApplicationViewIcons"></ext:MenuItem>
            <ext:MenuItem runat="server" Text="Cambiar de Fondo" Icon="Picture" ID="menuCambiarFondo">
              <DirectEvents>
                <Click OnEvent="menuCambiarFondo_Click" />
              </DirectEvents>
            </ext:MenuItem>
            <ext:MenuSeparator ID="MenuSeparator1" runat="server" />
            <ext:MenuItem ID="MenuItem2" runat="server" Text="Título Windows" Handler="title" Icon="ApplicationTileVertical" />
            <ext:MenuItem ID="MenuItem3" runat="server" Text="Cascada Windows" Handler="cascade" Icon="ApplicationCascade" />
          </Items>
        </ext:Menu>
      </ContextMenu>
    </DesktopConfig>
  </ext:Desktop>
</body>
</html>

