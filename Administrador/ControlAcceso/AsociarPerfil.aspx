<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsociarPerfil.aspx.cs" Inherits="Administrador.ControlAcceso.AsociarPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
  <link href="../Css/Default.css" rel="stylesheet" />
  <script>

    var Ayuda = function () {
      Ext.Msg.alert('Mensaje', 'Realice un click sobre un perfil y manteniendo el cursor seleccionado,<br> muevalo si desea Asociar o Desasociar. <br> Presiona la Tecla CTRL si desea mover mas de un Perfil');
    }

    var getDragDropText = function () {
      var buf = [];

      buf.push("<ul>");

      Ext.each(this.view.panel.getSelectionModel().getSelection(), function (record) {
        buf.push("<li>" + record.data.perf_perfil + "</li>");
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
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Hidden runat="server" ID="hid_id_usuario"></ext:Hidden>
    <ext:Viewport runat="server" Layout="ColumnLayout">
      <Items>
        <ext:GridPanel runat="server" Height="600" MinWidth="300" Icon="ArrowRight" IconAlign="Right" Title="Perfiles para Asociar"
          ColumnWidth=".5" ID="grdPerfilesDisponibles" TitleAlign="Center" Border="True">
          <Store>
            <ext:Store runat="server" ID="strPerfilesDisponibles">
              <Model>
                <ext:Model runat="server" IDProperty="id_perfil">
                  <Fields>

                    <ext:ModelField ServerMapping="id_perfil" SortType="AsInt" />
                    <ext:ModelField ServerMapping="perf_perfil" SortType="AsText" />
                    <ext:ModelField ServerMapping="perf_esvigente" SortType="AsText" />
                    <ext:ModelField ServerMapping="perf_descripcion" SortType="AsText" />
                    <ext:ModelField ServerMapping="perf_orden" SortType="AsInt" />
                  </Fields>
                </ext:Model>
              </Model>
            </ext:Store>
          </Store>
          <ColumnModel>
            <Columns>
              <ext:RowNumbererColumn runat="server" Width="30" />
              <ext:Column runat="server" Header="Perfil" Flex="1" DataIndex="perf_perfil"></ext:Column>
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
        <ext:GridPanel runat="server" MinWidth="300" Icon="ArrowLeft" Title="Perfiles Asociados" ColumnWidth=".5"
          ID="grdPerfilesAsociados" TitleAlign="Center" Border="True" Height="600">
          <Store>
            <ext:Store runat="server" ID="strPerfilesAsociados">
              <Model>
                <ext:Model runat="server" IDProperty="idperfil">
                  <Fields>
                    <ext:ModelField ServerMapping="id_perfil" SortType="AsInt" />
                    <ext:ModelField ServerMapping="perf_perfil" SortType="AsText" />
                    <ext:ModelField ServerMapping="perf_esvigente" SortType="AsText" />
                    <ext:ModelField ServerMapping="perf_descripcion" SortType="AsText" />
                    <ext:ModelField ServerMapping="perf_orden" SortType="AsInt" />
                  </Fields>
                </ext:Model>
              </Model>
            </ext:Store>
          </Store>
          <ColumnModel>
            <Columns>
              <ext:RowNumbererColumn runat="server" Width="30" />
              <ext:Column runat="server" Header="Perfil" Flex="1" DataIndex="perf_perfil"></ext:Column>
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
    </ext:Viewport>
  </form>
</body>
</html>
