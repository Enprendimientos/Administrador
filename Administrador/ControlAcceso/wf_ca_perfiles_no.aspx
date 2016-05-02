<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_ca_perfiles_no.aspx.cs" Inherits="Administrador.ControlAcceso.wf_ca_perfiles_no" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link href="../Css/Default.css" rel="stylesheet" />
</head>
<body>
  <form id="formTemplate" runat="server">
    <ext:ResourceManager ID="manager" runat="server" DirectMethodNamespace="XMethod"
      ShowWarningOnAjaxFailure="false">
      <Listeners>
        <AjaxRequestException Handler="alert(response);" />
      </Listeners>
    </ext:ResourceManager>
    <ext:XScript ID="XScriptTemplate" runat="server">
    <script type="text/javascript">

      function ClickLimpiarFiltros() {

        App.filtertxt_perf_perfil.reset();
        App.filterbol_perf_esvigente.reset();
        App.filtertxt_perf_descripcion.reset();
        App.filterint_perf_orden.reset();

        App.st_grilla.load();
      }

      function ClickLimpiarFiltrosOpciones() {
        App.filter_op_opcion.reset();

        App.strOpciones.load();
      }
    </script>
    </ext:XScript>
    <ext:Store ID="st_grilla" runat="server" OnReadData="OnReadData_st_grilla"
      AutoLoad="true" RemoteSort="true" PageSize="20">
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
      <Proxy>
        <ext:PageProxy />
      </Proxy>
      <Parameters>
        <ext:StoreParameter Name="limit" Value="#{param_pagesize}.value" Mode="Raw" />
      </Parameters>
      <Sorters>
        <ext:DataSorter Property="id_perfil" Direction="ASC"></ext:DataSorter>
      </Sorters>
    </ext:Store>
    <ext:Store runat="server" ID="strOpciones" OnReadData="strOpciones_OnReadData" AutoLoad="False" RemoteSort="True"
      PageSize="20">
      <Model>
        <ext:Model runat="server" IDProperty="id_opcion">
          <Fields>
            <ext:ModelField ServerMapping="id_opcion.id" Name="id_opcion" />
            <ext:ModelField ServerMapping="id_opcion.descripcion" Name="opci_opcion" />
          </Fields>
        </ext:Model>
      </Model>
      <Proxy>
        <ext:PageProxy />
      </Proxy>
      <Parameters>
        <ext:StoreParameter Name="limit" Value="#{param_pagesize_opciones}.value" Mode="Raw" />
        <ext:StoreParameter Name="id_perfil" Value="#{gd_grilla}.getSelectionModel().getSelection()[0].id" Mode="Raw" />
      </Parameters>
      <Sorters>
        <ext:DataSorter Property="opci_opcion" Direction="ASC"></ext:DataSorter>
      </Sorters>
    </ext:Store>
    <ext:Hidden ID="param_pagesize" runat="server" Text="20" />
    <ext:Hidden ID="param_pagesize_opciones" runat="server" Text="20" />
    <ext:Viewport ID="viewport" runat="server" Layout="BorderLayout">
      <Items>
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
                      <ext:Parameter Name="url" Value="wf_ca_perfiles_adm.aspx" />
                      <ext:Parameter Name="command" Value="command" Mode="Raw" />
                      <ext:Parameter Name="Id" Value="record.data.id_perfil" Mode="Raw" />
                    </ExtraParams>
                  </Command>
                </DirectEvents>
              </ext:CommandColumn>
              <ext:Column runat="server" DataIndex="perf_perfil" Header="Nombre Perfil" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_perf_perfil" runat="server" />
                </Items>
              </ext:Column>
              <ext:Column runat="server" DataIndex="perf_descripcion" Header="Descripción" Flex="1">
                <Items>
                  <ext:TextField ID="filtertxt_perf_descripcion" runat="server" />
                </Items>
              </ext:Column>
              <ext:Column runat="server" DataIndex="perf_esvigente" Header="Vigente" Flex="1">
                <Items>
                  <ext:ComboBox ID="filterbol_perf_esvigente" runat="server" Mode="Local">
                    <Items>
                      <ext:ListItem Value="TODOS" Text="TODOS" />
                      <ext:ListItem Value="ACT" Text="SI" />
                      <ext:ListItem Value="DES" Text="NO" />
                    </Items>
                    <selecteditem value="TODOS" text="TODOS" />
                  </ext:ComboBox>
                </Items>
              </ext:Column>
              <ext:NumberColumn runat="server" DataIndex="perf_orden" Header="Orden" Format="0.000.000/i">
                <Items>
                  <ext:NumberField runat="server" ID="filterint_perf_orden" AllowDecimals="false" AllowNegative="false" />
                </Items>
              </ext:NumberColumn>
            </Columns>
          </ColumnModel>
          <SelectionModel>
            <ext:RowSelectionModel runat="server" ID="smGrdPerfiles">
              <Listeners>
                <Select Handler="#{strOpciones}.reload();" Buffer="200"></Select>
              </Listeners>
            </ext:RowSelectionModel>
          </SelectionModel>
          <TopBar>
            <ext:Toolbar ID="tb_grilla" runat="server">
              <Items>
                <ext:Button ID="btn_nuevo" runat="server" Icon="Add" Text="Agregar" ToolTip="Agregar un nuevo registro"
                  UI="Primary">
                  <DirectEvents>
                    <Click OnEvent="Open_win_mantenedor">
                      <ExtraParams>
                        <ext:Parameter Name="url" Value="wf_ca_perfiles_adm.aspx" />
                        <ext:Parameter Name="command" Value="Agregar" Mode="Value" />
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
        </ext:GridPanel>
        <ext:GridPanel runat="server" ID="grdOpciones" Region="East" Width="400" Title="Opciones" MinWidth="400" Border="true" EnableColumnHide="true" StoreID="strOpciones">
          <ColumnModel>
            <Columns>
              <ext:RowNumbererColumn runat="server" Width="30" />
              <ext:Column runat="server" Header="Opción" DataIndex="opci_opcion" Flex="1">
                <Items>
                  <ext:TextField runat="server" ID="filter_op_opcion"></ext:TextField>
                </Items>
              </ext:Column>
            </Columns>
          </ColumnModel>
          <TopBar>
            <ext:Toolbar runat="server">
              <Items>
                <ext:Button runat="server" ID="btnAsociar" Icon="Add" Text="Asociar/Desasociar Opción"
                  ToolTip="Asociar o Desasociar una acción al perfil seleccionado" Disabled="True" UI="Warning">
                  <DirectEvents>
                    <Click OnEvent="Open_win_mantenedorPerfilOpcion">
                      <ExtraParams>
                        <ext:Parameter Name="url" Value="AsociarOpcionesPerfil.aspx" />
                        <ext:Parameter Name="command" Value="Agregar" Mode="Value" />
                        <ext:Parameter Name="id" Value="#{gd_grilla}.getSelectionModel().getSelection()[0].id" Mode="Raw" />
                      </ExtraParams>
                    </Click>
                  </DirectEvents>
                </ext:Button>
                <ext:ToolbarSeparator runat="server" />
                <ext:Button runat="server" ID="btnFiltrar" Text="Filtrar" Icon="Find"
                  ToolTip="Filtrar por criterios de busqueda">
                  <Listeners>
                    <Click Handler="#{grdOpciones}.load();" />
                  </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnLimpiarFiltro" Icon="Cancel" Text="Limpiar Filtro"
                  ToolTip="Limpia los criterios de busqueda">
                  <Listeners>
                    <Click Handler="ClickLimpiarFiltrosOpciones();"></Click>
                  </Listeners>
                </ext:Button>
              </Items>
            </ext:Toolbar>
          </TopBar>
          <BottomBar>
            <ext:PagingToolbar runat="server" ID="pg_grillao">
              <Items>
                <ext:ComboBox runat="server" Editable="False" Width="50">
                  <Items>
                    <ext:ListItem Text="20" />
                    <ext:ListItem Text="40" />
                    <ext:ListItem Text="60" />
                    <ext:ListItem Text="80" />
                    <ext:ListItem Text="100" />
                  </Items>
                  <Listeners>
                    <Render Handler="this.setValue(#{param_pagesize_opciones}.value);" />
                    <Select Handler="#{param_pagesize_opciones}.setValue(this.value); #{strOpciones}.load(); #{grdOpciones}.pageSize= parseInt(#{param_pagesize_opciones}.value); #{grdOpciones}.updateInfo();"></Select>
                  </Listeners>
                </ext:ComboBox>
              </Items>
              <Listeners>
                <Render Handler="this.pageSize = parseInt(#{param_pagesize_opciones}.value); this.updateInfo();" />
              </Listeners>
            </ext:PagingToolbar>
          </BottomBar>
        </ext:GridPanel>
      </Items>

    </ext:Viewport>
    <ext:Window ID="win_mantenedor" runat="server" Modal="true" Hidden="true" Width="500"
      Height="400">
      <Listeners>
        <Hide Handler="#{st_grilla}.load();" />
      </Listeners>
    </ext:Window>
    <ext:Window runat="server" ID="win_mantenedorOpciones" Modal="True" Hidden="True" Width="500" Height="400">
      <Listeners>
        <Hide Handler="#{strOpciones}.reload();" />
      </Listeners>
    </ext:Window>
  </form>
</body>
</html>
