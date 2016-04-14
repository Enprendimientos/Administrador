<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMenu.aspx.cs" Inherits="Administrador.ControlAcceso.AgregarMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <link href="../Css/Default.css" rel="stylesheet" />
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" ID="ResourceManager1" />
    <ext:Viewport runat="server" Layout="BorderLayout">
      <Items>
        <ext:FormPanel runat="server" Region="Center" Padding="10" AutoScroll="True">
          <FieldDefaults MsgTarget="Under"/>
          <Items>
            <ext:TextField runat="server" ID="txtNombreMenu" FieldLabel="Nombre Menu" AllowBlank="False"
              AnchorHorizontal="98%">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:TextField>
            <ext:ComboBox runat="server" ID="cmbMenuPadre" FieldLabel="Menú Padre" DisplayField="menu_nombre" ValueField="id_menu" AllowBlank="False" AnchorHorizontal="98%">
              <Store>
                <ext:Store runat="server" ID="strCmbMenuPadre" OnReadData="strCmbMenuPadre_OnReadData">
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
                  <Proxy>
                    <ext:PageProxy />
                  </Proxy>
                </ext:Store>
              </Store>
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:ComboBox>
            <ext:TextField runat="server" ID="txtUrl" FieldLabel="URL" AllowBlank="False" AnchorHorizontal="98%">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:TextField>
            <ext:TextField runat="server" ID="txtUrlReal" FieldLabel="URL Real" AllowBlank="False" AnchorHorizontal="98%">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:TextField>
            <ext:ComboBox runat="server" ID="cmbIconos" FieldLabel="Icono" ValueField="icono" DisplayField="icono" IndicatorIcon="Help"
              IndicatorTip="Los Iconos son Imágenes que se muestra al costado del nombre del Menú" AllowBlank="False" AnchorHorizontal="98%">
              <Store>
                <ext:Store runat="server" ID="strIconos" OnReadData="strIconos_OnReadData" AutoLoad="True">
                  <Model>
                    <ext:Model runat="server" IDProperty="id">
                      <Fields>
                        <ext:ModelField ServerMapping="id" />
                        <ext:ModelField ServerMapping="icono"></ext:ModelField>
                        <ext:ModelField ServerMapping="iconoCls"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                  <Proxy>
                    <ext:PageProxy />
                  </Proxy>
                </ext:Store>
              </Store>
              <ListConfig Width="200">
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
            <ext:NumberField runat="server" ID="txtAncho" FieldLabel="Ancho" DecimalPrecision="0" AllowDecimals="False" AnchorHorizontal="98%" MaxLength="4" EnforceMaxLength="True" AllowBlank="False" MinValue="300" MaxValue="3000">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:NumberField>
            <ext:NumberField runat="server" ID="txtAlto" FieldLabel="Alto" DecimalPrecision="0" AllowDecimals="False" AnchorHorizontal="98%" MaxLength="4" EnforceMaxLength="True" AllowBlank="False" MinValue="300" MaxValue="1024">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:NumberField>
            <ext:NumberField runat="server" ID="txtOrden" FieldLabel="Orden" DecimalPrecision="0" AllowDecimals="False" AnchorHorizontal="98%" MaxLength="2" EnforceMaxLength="True" AllowBlank="False" MinValue="0" MaxValue="20">
              <AfterLabelTextTpl runat="server">
                <Html>
                  <span class="campoRequired" data-qtip="Required"> *</span>
                </Html>
              </AfterLabelTextTpl>
            </ext:NumberField>
            <ext:Checkbox runat="server" ID="chkVigente" FieldLabel="Vigente"></ext:Checkbox>
          </Items>
          <Buttons>
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
