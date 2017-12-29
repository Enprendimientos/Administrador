<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrador.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <link href="Css/Default.css" rel="stylesheet" />
  <link href="Images/favicon.ico" rel="shortcut icon" type="image/x-icon" />
  <title>Administrador Aplicaciones</title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Viewport runat="server">
      <LayoutConfig>
        <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
      </LayoutConfig>
      <Items>
        <ext:FormPanel runat="server" Layout="FormLayout" Icon="Laptop" Title="Inicio de Sesión">
          <FieldDefaults MsgTarget="Under" AllowBlank="False"/>
          <Items>
            <ext:TextField runat="server" FieldLabel="Nombre Usuarios" Icon="User" MaxLength="50" EnforceMaxLength="True" ID="txtUsuario">
              <DirectEvents>
                <Blur OnEvent="txtUsuario_Blur">
                  <EventMask ShowMask="True" Msg="Cargando..." MinDelay="1000"></EventMask>
                </Blur>
              </DirectEvents>
            </ext:TextField>
            <ext:TextField runat="server" FieldLabel="Clave" Icon="Key" MaxLength="16" EnforceMaxLength="true" ID="txtClave" InputType="Password"/>
            <ext:ComboBox runat="server" FieldLabel="Perfil" Icon="Group" ID="cmbPerfil" ForceSelection="True"
              Editable="False" DisplayField="pe_perfil" ValueField="id_perfil">
              <Store>
                <ext:Store runat="server" ID="strCmbPerfiles">
                  <Model>
                    <ext:Model runat="server" IDProperty="id_perfil">
                      <Fields>
                        <ext:ModelField ServerMapping="id_perfil.id" Name="id_perfil"/>
                        <ext:ModelField ServerMapping="id_perfil.descripcion" Name="pe_perfil"/>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
            </ext:ComboBox>
            <ext:HyperlinkButton runat="server" Text="¿Olvide mi Contraseña?" Icon="Help">
              <Listeners>
                <Click Handler="window.location.href='RecordarContrasena.aspx';"></Click>
              </Listeners>
            </ext:HyperlinkButton>
           </Items>
          <Buttons>
            <ext:Button runat="server" ID="btnIngresar" Icon="Accept" Text="Ingresar" FormBind="true">
              <DirectEvents>
                <Click OnEvent="btnIngresar_Click">
                  <EventMask ShowMask="True" Msg="Cargando..."></EventMask>
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
