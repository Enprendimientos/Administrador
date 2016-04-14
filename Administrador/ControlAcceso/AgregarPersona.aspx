<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPersona.aspx.cs" Inherits="Administrador.ControlAcceso.AgregarPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
  <script type="text/javascript">
    function CloseIframe() {
      if (parent) {
        if (parent.App.winMantenedor) {
          parent.App.winMantenedor.hide();
        }
      }
    }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Hidden runat="server" ID="hid_id"/>
    <ext:Viewport runat="server" Layout="BorderLayout">
      <Items>
        <ext:FormPanel runat="server" Region="Center" Padding="10" AutoScroll="True">
          <FieldDefaults MsgTarget="Under"></FieldDefaults>
          <Items>
            <ext:FieldSet runat="server" Title="Datos Personales">
              <Items>
                <ext:TextField runat="server" ID="txtNombres" FieldLabel="Nombres" AnchorHorizontal="95%" MaxLength="70"
                  EnforceMaxLength="True" AllowBlank="False" />
                <ext:TextField runat="server" ID="txtPaterno" FieldLabel="Paterno" AnchorHorizontal="95%" MaxLength="20"
                  EnforceMaxLength="True" AllowBlank="False" />
                <ext:TextField runat="server" ID="txtMaterno" FieldLabel="Materno" AnchorHorizontal="95%" MaxLength="20"
                  EnforceMaxLength="True" />
                <ext:TextField runat="server" ID="txtEmail" FieldLabel="Email" AnchorHorizontal="95%" Vtype="email"
                  EmptyText="correo@dominio.com" Icon="Mail" MaxLength="100" EnforceMaxLength="True" AllowBlank="False" />
                <ext:TextField runat="server" ID="txtTelefono" FieldLabel="Telefono" AnchorHorizontal="95%" Icon="Telephone"
                  EmptyText="1234 5678" MaxLength="20" EnforceMaxLength="True" />
              </Items>
            </ext:FieldSet>
            <ext:FieldSet runat="server" Title="Datos Usuario">
              <Items>
                <ext:TextField runat="server" ID="txtUsuario" FieldLabel="Usuario" AnchorHorizontal="95%" Icon="User" MaxLength="16"
                  EnforceMaxLength="True" Vtype="alphanum" AllowBlank="False" />
                <ext:TextField runat="server" ID="txtClave" FieldLabel="Clave" AnchorHorizontal="95%" Icon="Key"
                  MaxLength="16" EnforceMaxLength="True" MinLength="6" InputType="Password" AllowBlank="False" />
                <ext:TextField runat="server" ID="txtRepiteClave" FieldLabel="Repite Clave" AnchorHorizontal="95%" Icon="Key"
                  MaxLength="16" EnforceMaxLength="True" MinLength="6" InputType="Password" AllowBlank="False" Vtype="password">
                  <CustomConfig>
                    <ext:ConfigItem Name="initialPassField"
                      Value="txtClave" Mode="Value" />
                  </CustomConfig>
                </ext:TextField>
                <ext:Checkbox runat="server" ID="txtVigente" FieldLabel="Vigente"></ext:Checkbox>
              </Items>
            </ext:FieldSet>
          </Items>
          <Buttons>
            <ext:Button runat="server" Icon="Delete" Text="Eliminar" ID="btnEliminar" UI="Danger" >
              <DirectEvents>
                <Click OnEvent="btnBorrar_Click">
                  <Confirmation Title="Confirmar" Message="Desea borrar el registro?" ConfirmRequest="true" />
                  <EventMask ShowMask="true" Msg="Borrando" />
                </Click>
              </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" Icon="Disk" Text="Guardar" ID="btnGuardar" UI="Success" FormBind="True">
              <DirectEvents>
                <Click OnEvent="btnGuardar_Click">
                  <EventMask ShowMask="True" Msg="Grabando..."/>
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
