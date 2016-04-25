<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsociarOpcionesPerfil.aspx.cs" Inherits="Administrador.ControlAcceso.AsociarOpcionesPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <script>

    var Ayuda = function () {
      Ext.Msg.alert('Mensaje', 'Realice un click sobre una opción y manteniendo el cursor seleccionado,<br> muevalo si desea Asociar o Desasociar. <br> Presiona la Tecla CTRL si desea mover mas de una Opción');
    }

    var getDragDropText = function () {
      var buf = [];

      buf.push("<ul>");

      Ext.each(this.view.panel.getSelectionModel().getSelection(), function (record) {
        buf.push("<li>" + record.data.descripcion + "</li>");
      });

      buf.push("</ul>");

      return buf.join("");
    };

    var populateExtraParams = function (extraParams, records) {
      var i, lenght,
          data = [];

      for (i = 0, lenght = records.length; i < lenght; i++) {
        data.push(records[i].data);
      }

      extraParams.records = data;
    };
  </script>
</head>
<body>
  <ext:ResourceManager runat="server" />
  <form id="form1" runat="server">
    <ext:Hidden runat="server" FieldLabel="ID" ID="hid_id" />
    <ext:Viewport runat="server" Layout="BorderLayout">
      <Items>
        <ext:Panel runat="server" Width="500" Height="300">
          <LayoutConfig>
            <ext:HBoxLayoutConfig Align="Stretch" Padding="5" />
          </LayoutConfig>
          <Items>
            <ext:GridPanel runat="server" ID="grdOpcionesDisponibles" MultiSelect="True" Flex="1" IconAlign="Right"
              Title="Opciones para Asociar" MarginSpec="0 2 0 0" Icon="ArrowRight">
              <Store>
                <ext:Store runat="server">
                  <Model>
                    <ext:Model runat="server" IDProperty="id_opcion">
                      <Fields>
                        <ext:ModelField Name="id_opcion" />
                        <ext:ModelField Name="opci_opcion" />
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:Column runat="server" HideTitleEl="True" DataIndex="opci_opcion" Flex="1" />
                </Columns>
              </ColumnModel>
              <View>
                <ext:GridView runat="server">
                  <Plugins>
                    <ext:GridDragDrop runat="server" DragGroup="firstGridDDGroup" DropGroup="secondGridDDGroup" />
                  </Plugins>
                  <Listeners>
                    <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" Delay="1" />
                  </Listeners>
                  <DirectEvents>
                    <Drop OnEvent="Drop" Before="populateExtraParams(extraParams, data.records);">
                      <ExtraParams>
                        <ext:Parameter Name="mode" Value="desasocia" />
                      </ExtraParams>
                    </Drop>
                  </DirectEvents>
                </ext:GridView>
              </View>
            </ext:GridPanel>
            <ext:GridPanel runat="server" ID="grdOpcionesNoDisponibles" MultiSelect="True" Title="Opciones Asociadas"
              Flex="1" MarginSpec="0 0 0 3" Icon="ArrowLeft">
              <Store>
                <ext:Store runat="server">
                  <Model>
                    <ext:Model runat="server" IDProperty="id_opcion">
                      <Fields>
                        <ext:ModelField ServerMapping="id_opcion" />
                        <ext:ModelField ServerMapping="opci_opcion" />
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:Column runat="server" HideTitleEl="True" DataIndex="opci_opcion" Flex="1" />
                </Columns>
              </ColumnModel>
              <View>
                <ext:GridView ID="GridView2" runat="server">
                  <Plugins>
                    <ext:GridDragDrop ID="GridDragDrop2" runat="server" DragGroup="secondGridDDGroup" DropGroup="firstGridDDGroup" />
                  </Plugins>
                  <Listeners>
                    <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" Delay="1" />
                  </Listeners>
                  <DirectEvents>
                    <Drop OnEvent="Drop" Before="populateExtraParams(extraParams, data.records);">
                      <ExtraParams>
                        <ext:Parameter Name="mode" Value="asocia" />
                      </ExtraParams>
                    </Drop>
                  </DirectEvents>
                </ext:GridView>
              </View>
            </ext:GridPanel>
          </Items>
          <BottomBar>
            <ext:Toolbar runat="server">
              <Items>
                <ext:Button runat="server" Icon="Lightbulb" ToolTip="Ayuda" Text="Ayuda" ID="btnAyuda">
                  <Listeners>
                    <Click Fn="Ayuda" />
                  </Listeners>
                </ext:Button>
              </Items>
            </ext:Toolbar>
          </BottomBar>
        </ext:Panel>
      </Items>
    </ext:Viewport>
  </form>
</body>
</html>
