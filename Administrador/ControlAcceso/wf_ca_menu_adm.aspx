<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_ca_menu_adm.aspx.cs" Inherits="Administrador.ControlAcceso.wf_ca_menu_adm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="formAdmTemplate" runat="server">
    <ext:ResourceManager ID="manager" runat="server" DirectMethodNamespace="XMBA"
      ShowWarningOnAjaxFailure="false">
      <Listeners>
        <AjaxRequestException Handler="alert(response);" />
      </Listeners>
    </ext:ResourceManager>
    <ext:XScript ID="XScriptTemplate" runat="server">
   <script type="text/javascript">

      function CloseIframe() {
        if (parent) {
          if (parent.win_mantenedor) {
            parent.win_mantenedor.hide();
          }
        }
      }

    </script>
    </ext:XScript>
    <div class="x-hidden">
      <ext:Hidden ID="hid_id" runat="server" />

    </div>
    <ext:Viewport ID="viewport" runat="server" Layout="BorderLayout">
      <Items>
        <ext:FormPanel ID="panelCenter" runat="server" Region="Center" Layout="FormLayout"
          Padding="10" AutoScroll="true" MonitorValid="true">
          <Items>

            <ext:TextField ID="txt_menu_nombre" runat="server" FieldLabel="Nombre Menú" AnchorHorizontal="98%"
              MaxLength="50" AllowBlank="false" MsgTarget="Under">
            </ext:TextField>
            <ext:TextField ID="txt_menu_url" runat="server" FieldLabel="menu_url" AnchorHorizontal="98%"
              MaxLength="1000" AllowBlank="false" MsgTarget="Under">
            </ext:TextField>
            <ext:NumberField ID="num_menu_ancho" runat="server" FieldLabel="menu_ancho" AnchorHorizontal="98%"
              MaxLength="10" AllowDecimals="false" AllowBlank="false" MsgTarget="Under">
            </ext:NumberField>
            <ext:NumberField ID="num_menu_alto" runat="server" FieldLabel="menu_alto" AnchorHorizontal="98%"
              MaxLength="10" AllowDecimals="false" AllowBlank="false" MsgTarget="Under">
            </ext:NumberField>
            <ext:NumberField ID="num_menu_orden" runat="server" FieldLabel="menu_orden" AnchorHorizontal="98%"
              MaxLength="10" AllowDecimals="false" MsgTarget="Under">
            </ext:NumberField>
            <ext:Checkbox ID="chk_menu_activo" runat="server" FieldLabel="menu_activo" AnchorHorizontal="98%">
            </ext:Checkbox>
            <ext:TextField ID="txt_menu_icono" runat="server" FieldLabel="menu_icono" AnchorHorizontal="98%"
              MaxLength="100" MsgTarget="Under">
            </ext:TextField>

          </Items>
          <TopBar>
            <ext:Toolbar ID="toolbar" runat="server">
              <Items>
                <ext:ToolbarFill />
                <ext:Button ID="btn_restaurar" runat="server" Text="Restaurar" Icon="PageRefresh">
                  <Listeners>
                    <Click Handler="#{panelCenter}.reset();" />
                  </Listeners>
                </ext:Button>
              </Items>
            </ext:Toolbar>
          </TopBar>
          <Buttons>
            <ext:Button ID="btn_borrar" runat="server" Text="Borrar" Icon="Delete">
              <DirectEvents>
                <Click OnEvent="click_btn_borrar" After="CloseIframe();">
                  <Confirmation Title="Confirmar" Message="Desea borrar el registro?" ConfirmRequest="true" />
                  <EventMask ShowMask="true" Msg="Borrando" />
                </Click>
              </DirectEvents>
            </ext:Button>
            <ext:Button ID="btn_guardar" runat="server" Text="Guardar" Icon="Accept" FormBind="True">
              <DirectEvents>
                <Click OnEvent="click_btn_guardar">
                  <EventMask ShowMask="true" Msg="Guardando" />
                </Click>
              </DirectEvents>
            </ext:Button>
          </Buttons>
        </ext:FormPanel>
      </Items>
    </ext:Viewport>
  </form>
</body>
</html>
