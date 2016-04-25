﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMenuPadre.aspx.cs" Inherits="Administrador.ControlAcceso.AgregarMenuPadre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
  <link href="../Css/Default.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" ID="ResourceManager1" />
    <ext:XScript ID="XScriptTemplate" runat="server">
    <script type="text/javascript">
      function CloseIframe() {
        if (parent) {
          if (parent.win_mantenedor) {
            parent.CloseWinMantenedor();
          }
        }
      }

    </script>
    </ext:XScript>
    <ext:Hidden runat="server" ID="hid_id" FieldLabel="ID"></ext:Hidden>
    <ext:Viewport runat="server" Layout="BorderLayout">
      <Items>
        <ext:FormPanel runat="server" Region="Center" Padding="10" AutoScroll="True">
          <FieldDefaults MsgTarget="Under" />
          <Items>
            <ext:TextField runat="server" ID="txtNombreMenu" FieldLabel="Nombre Menu" AllowBlank="False"
              AnchorHorizontal="98%">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:TextField>
            <ext:ComboBox runat="server" ID="cmbMenuPadre" FieldLabel="Menú Padre" DisplayField="menu_nombre" ValueField="id_menu" AnchorHorizontal="98%">
              <Store>
                <ext:Store runat="server" ID="strCmbMenuPadre">
                  <Model>
                    <ext:Model runat="server" IDProperty="id_menu">
                      <Fields>
                        <ext:ModelField ServerMapping="id_menu" SortType="AsInt" />
                        <ext:ModelField ServerMapping="menu_nombre" SortType="AsText" />
                        <ext:ModelField ServerMapping="id_menupadre" SortType="AsInt" />
                        <ext:ModelField ServerMapping="menu_nombrepadre" SortType="AsText" />
                        <ext:ModelField ServerMapping="menu_url" SortType="AsText" />
                        <ext:ModelField ServerMapping="menu_opciones" SortType="AsText" />
                        <ext:ModelField ServerMapping="menu_ancho" SortType="AsInt" />
                        <ext:ModelField ServerMapping="menu_alto" SortType="AsInt" />
                        <ext:ModelField ServerMapping="menu_orden" SortType="AsInt" />
                        <ext:ModelField ServerMapping="menu_activo" SortType="AsText" />
                        <ext:ModelField ServerMapping="menu_nombreventana" SortType="AsText" />
                        <ext:ModelField ServerMapping="menu_urlReal" SortType="AsText" />
                        <ext:ModelField ServerMapping="menu_icono" SortType="AsText" />
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:ComboBox>
            <ext:ComboBox runat="server" ID="cmbIconos" FieldLabel="Icono" ValueField="icono" DisplayField="icono" IndicatorIcon="Help"
              IndicatorTip="Los Iconos son Imágenes que se muestra al costado del nombre del Menú" AllowBlank="False" AnchorHorizontal="98%">
              <Store>
                <ext:Store runat="server" ID="strIconos">
                  <Model>
                    <ext:Model runat="server" IDProperty="id">
                      <Fields>
                        <ext:ModelField ServerMapping="id" />
                        <ext:ModelField ServerMapping="icono"></ext:ModelField>
                        <ext:ModelField ServerMapping="iconoCls"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ListConfig>
                <ItemTpl runat="server">
                  <Html>
                    <div class="icon-combo-item icon-{iconoCls}">
                            {icono}
                        </div>
                  </Html>
                </ItemTpl>
              </ListConfig>
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
              <Listeners>
                <Change Handler="if(this.valueCollection.getCount() > 0) {this.setIconCls('icon-'+this.valueCollection.getAt(0).get('iconoCls'));}" />
              </Listeners>
            </ext:ComboBox>
            <ext:Checkbox runat="server" ID="chkVigente" FieldLabel="Vigente"></ext:Checkbox>
          </Items>
          <Buttons>
            <ext:Button runat="server" ID="btnBorrar" Text="Borrar" UI="Danger">
              <DirectEvents>
                <Click OnEvent="btnBorrar_Click" After="CloseIframe();">
                 <Confirmation Title="Confirmar" Message="Desea Borrar el registro?" ConfirmRequest="True" ></Confirmation>
                  <EventMask ShowMask="True" Msg="Borrando..." />
                </Click>
              </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnGuardar" Text="Guardar" UI="Success" FormBind="True">
              <DirectEvents>
                <Click OnEvent="btnGuardar_Click">
                  <EventMask ShowMask="True" Msg="Guardando..."></EventMask>
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
