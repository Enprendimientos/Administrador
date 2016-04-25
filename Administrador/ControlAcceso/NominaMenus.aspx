<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NominaMenus.aspx.cs" Inherits="Administrador.ControlAcceso.NominaMenus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager ID="manager" runat="server" DirectMethodNamespace="XMethod"
      ShowWarningOnAjaxFailure="false">
      <Listeners>
        <AjaxRequestException Handler="alert(response);Error(response);" />
      </Listeners>
    </ext:ResourceManager>
    <ext:XScript ID="XScriptTemplate" runat="server">
    <script type="text/javascript">

      function ClickLimpiarFiltros() {

        App.filtertxt_menu_nombre.reset();
        //App.filterint_id_menupadre.reset();
        App.filtertxt_menu_url.reset();
        App.filterint_menu_orden.reset();
        App.filterbol_menu_activo.reset();
        App.filtertxt_menu_nombreventana.reset();
        App.filtertxt_menu_urlReal.reset();
        App.filtertxt_menu_icono.reset();

        App.st_grilla.load();
      }

      function CloseWinMantenedor() {
        App.win_mantenedor.hide();
      }
      function Error(r) {
        console.log(r);
      }

      </script>
    </ext:XScript>
    <ext:Store ID="st_grilla" runat="server" OnReadData="OnReadData_st_grilla"
      AutoLoad="true" RemoteSort="true" PageSize="20">
      <Model>
        <ext:Model runat="server" IDProperty="id_menu">
          <Fields>
            <ext:ModelField ServerMapping="id_menu" SortType="AsInt" />
            <ext:ModelField ServerMapping="menu_nombre" SortType="AsText" />
            <ext:ModelField ServerMapping="id_menupadre" SortType="AsInt" />
            <ext:ModelField ServerMapping="menu_nombrepadre" SortType="AsText"/>
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
      <Parameters>
        <ext:StoreParameter Name="limit" Value="#{param_pagesize}.value" Mode="Raw" />
      </Parameters>
      <Sorters>
        <ext:DataSorter Property="id_menu" Direction="ASC"></ext:DataSorter>
      </Sorters>
    </ext:Store>
    <ext:Hidden ID="param_pagesize" runat="server" Text="20" />
    <ext:Viewport runat="server" Layout="BorderLayout">
      <Items>
        <ext:TreePanel runat="server" Region="West" Width="300" Icon="Folder" AutoScroll="True" ID="treeMenu" Title="Menu del Sistema">
        </ext:TreePanel>
        <ext:GridPanel ID="gd_grilla" runat="server" StoreID="st_grilla" Border="false" EnableColumnHide="true" Region="Center">
          <ColumnModel>
            <Columns>
              <ext:RowNumbererColumn runat="server" Header="N°" />
              <ext:CommandColumn runat="server" Header="Opciones" Width="100" Resizable="false">
                <Commands>
                  <ext:GridCommand Icon="Pencil" CommandName="Modificar">
                    <ToolTip Title="Editar Registro" Text="Modifica los Datos del Registro Seleccionado" />
                  </ext:GridCommand>
                  <ext:GridCommand Icon="Delete" CommandName="Eliminar">
                    <ToolTip Title="Eliminar Registro" Text="Elimina los Datos del Registro Seleccionado" />
                  </ext:GridCommand>
                </Commands>
                <DirectEvents>
                  <Command OnEvent="Open_win_mantenedor">
                    <ExtraParams>
                      <ext:Parameter Name="command" Value="command" Mode="Raw" />
                      <ext:Parameter Name="Id" Value="record.data.id_menu" Mode="Raw" />
                      <ext:Parameter Name="url" Value="record.data.menu_url" Mode="Raw"/>
                    </ExtraParams>
                  </Command>
                </DirectEvents>
              </ext:CommandColumn>
              <ext:Column runat="server" DataIndex="menu_nombre" Header="Nombre Menú" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_menu_nombre" runat="server" />
                </Items>
              </ext:Column>
              <ext:NumberColumn Visible="False" runat="server" DataIndex="id_menupadre" Header="id_menupadre" Format="0.000.000/i">
                <Items>
                  <ext:NumberField ID="filterint_id_menupadre" AllowDecimals="false" AllowNegative="false" runat="server" />
                </Items>
              </ext:NumberColumn>
              <ext:Column runat="server" DataIndex="menu_nombrepadre" Header="Menú Padre" Flex="1" Sortable="False" MenuDisabled="True"></ext:Column>
              <ext:Column runat="server" DataIndex="menu_url" Header="Url" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_menu_url" runat="server" />
                </Items>
              </ext:Column>
              <ext:NumberColumn runat="server" DataIndex="menu_orden" Header="Orden" Format="0.000.000/i" Width="70">
                <Items>
                  <ext:NumberField ID="filterint_menu_orden" AllowDecimals="false" AllowNegative="false" runat="server" />
                </Items>
              </ext:NumberColumn>
              <ext:Column runat="server" DataIndex="menu_activo" Header="Estado" Flex="1" Width="80">
                <Items>
                  <ext:ComboBox ID="filterbol_menu_activo" runat="server" Mode="Local">
                    <Items>
                      <ext:ListItem Value="TODOS" Text="TODOS" />
                      <ext:ListItem Value="ACT" Text="ACT" />
                      <ext:ListItem Value="DES" Text="DES" />
                    </Items>
                    <selecteditem value="TODOS" text="TODOS" />
                  </ext:ComboBox>
                </Items>
              </ext:Column>
              <ext:Column runat="server" DataIndex="menu_nombreventana" Header="Nombre Ventana" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_menu_nombreventana" runat="server" />
                </Items>
              </ext:Column>
              <ext:Column runat="server" DataIndex="menu_urlReal" Header="Url Real" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_menu_urlReal" runat="server" />
                </Items>
              </ext:Column>
              <ext:Column runat="server" DataIndex="menu_icono" Header="Icono" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_menu_icono" runat="server" />
                </Items>
              </ext:Column>
            </Columns>
          </ColumnModel>
          <TopBar>
            <ext:Toolbar ID="tb_grilla" runat="server">
              <Items>
                <ext:Button ID="btnAddMenuPadre" runat="server" Icon="Add" Text="Agregar Menú Padre" ToolTip="Agregar un nuevo registro" UI="Primary">
                  <DirectEvents>
                    <Click OnEvent="Open_win_mantenedor">
                      <ExtraParams>
                        <ext:Parameter Name="command" Value="AgregarMenuPadre" Mode="Value" />
                      </ExtraParams>
                    </Click>
                  </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnAddMenu" runat="server" Icon="Add" Text="Agregar Menú" ToolTip="Agregar un nuevo registro" UI="Primary">
                  <DirectEvents>
                    <Click OnEvent="Open_win_mantenedor">
                      <ExtraParams>
                        <ext:Parameter Name="command" Value="AgregarMenu" Mode="Value" />
                      </ExtraParams>
                    </Click>
                  </DirectEvents>
                </ext:Button>
                <ext:ToolbarSeparator />
                <ext:Button ID="btn_applyFiltro" runat="server" Icon="Find" Text="Filtrar" ToolTip="Filtrar por criterios de busqueda">
                  <Listeners>
                    <Click Handler="#{st_grilla}.load();" />
                  </Listeners>
                </ext:Button>
                <ext:Button ID="btn_clearFiltro" runat="server" Icon="Cancel" Text="Limpiar Filtro" ToolTip="Limpia criterios de busqueda">
                  <Listeners>
                    <Click Handler="ClickLimpiarFiltros();" />
                  </Listeners>
                </ext:Button>
              </Items>
            </ext:Toolbar>
          </TopBar>
          <BottomBar>
            <ext:PagingToolbar ID="pg_grilla" runat="server">
              <Items>
                <ext:ToolbarSeparator />
                <ext:ComboBox runat="server" Editable="false" Text="" Width="50">
                  <Items>
                    <ext:ListItem Text="20" />
                    <ext:ListItem Text="40" />
                    <ext:ListItem Text="60" />
                    <ext:ListItem Text="80" />
                    <ext:ListItem Text="100" />
                  </Items>
                  <Listeners>
                    <Render Handler="this.setValue(#{param_pagesize}.value);" />
                    <Select Handler="#{param_pagesize}.setValue(this.value);#{st_grilla}.load();#{pg_grilla}.pageSize = parseInt(#{param_pagesize}.value);#{pg_grilla}.updateInfo();" />
                  </Listeners>
                </ext:ComboBox>
              </Items>
              <Listeners>
                <Render Handler="this.pageSize = parseInt(#{param_pagesize}.value); this.updateInfo();" />
              </Listeners>
            </ext:PagingToolbar>
          </BottomBar>
          <SelectionModel>
            <ext:RowSelectionModel />
          </SelectionModel>
        </ext:GridPanel>
      </Items>
    </ext:Viewport>
    <ext:Window ID="win_mantenedor" runat="server" Modal="true" Hidden="true" Width="500"
      Height="400">
      <Listeners>
        <Hide Handler="#{st_grilla}.load(); " />
      </Listeners>
    </ext:Window>
  </form>
</body>
</html>
