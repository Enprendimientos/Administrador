<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NominaPersonas.aspx.cs" Inherits="Administrador.ControlAcceso.NominaPersonas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <link href="../Css/Default.css" rel="stylesheet" />
  <script src="../Scripts/Funciones.js"></script>
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Hidden runat="server" ID="param_pagesize" Text="20"></ext:Hidden>
    <ext:Viewport runat="server" Layout="BorderLayout">
      <Items>
        <ext:GridPanel runat="server" Icon="Table" Title="Personas" ID="grdGrilla" Layout="FitLayout" Region="Center">
          <Store>
            <ext:Store runat="server" ID="strGrilla" RemoteSort="True" AutoLoad="True" OnReadData="strGrilla_OnReadData"
              PageSize="20">
              <Model>
                <ext:Model runat="server" IDProperty="id_usuario">
                  <Fields>
                    <ext:ModelField Name="id_persona" />
                    <ext:ModelField Name="pers_apmaterno" />
                    <ext:ModelField Name="pers_appaterno" />
                    <ext:ModelField Name="pers_celular" />
                    <ext:ModelField Name="pers_email" />
                    <ext:ModelField Name="pers_fecha_creacion" />
                    <ext:ModelField Name="pers_fecha_modificacion" />
                    <ext:ModelField Name="pers_nacionalidad" />
                    <ext:ModelField Name="pers_nombrecompleto" />
                    <ext:ModelField Name="pers_nombres" />
                    <ext:ModelField Name="pers_rut" />
                    <ext:ModelField Name="pers_telefono" />
                    <ext:ModelField Name="pers_usuario_creacion" />
                    <ext:ModelField Name="pers_usuario_modificacion" />
                    <ext:ModelField Name="pers_vigente" />
                    <ext:ModelField Name="id_comuna" />
                    <ext:ModelField Name="comu_nombre" />
                    <ext:ModelField Name="id_estado_civil" />
                    <ext:ModelField Name="esci_nombre" />
                    <ext:ModelField Name="id_sexo" />
                    <ext:ModelField Name="sexo_nombre" />
                    <ext:ModelField Name="id_usuario" />
                    <ext:ModelField Name="usua_consuser" />
                    <ext:ModelField Name="usua_ultimaconexion" />
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
                <ext:DataSorter Property="pers_nombrecompleto" Direction="ASC" />
              </Sorters>
            </ext:Store>
          </Store>
          <ColumnModel>
            <Columns>
              <ext:RowNumbererColumn runat="server" Width="30" />
              <ext:CommandColumn runat="server" Header="Opciones">
                <Commands>
                  <ext:GridCommand Icon="Pencil" CommandName="Modificar">
                    <ToolTip Title="Editar Registro" Text="Modifica los Datos del Registro Seleccionado" />
                  </ext:GridCommand>
                  <ext:GridCommand Icon="Delete" CommandName="Eliminar">
                    <ToolTip Title="Eliminar Registro" Text="Elimina los Datos del Registro Seleccionado" />
                  </ext:GridCommand>
                </Commands>
                <DirectEvents>
                  <Command OnEvent="OpenWindow_OnEvent">
                    <EventMask ShowMask="True" Msg="Cargando..." />
                    <ExtraParams>
                      <ext:Parameter Name="command" Value="command" Mode="Raw" />
                      <ext:Parameter Name="id" Value="record.data.id_usuario" Mode="Raw" />
                    </ExtraParams>
                  </Command>
                </DirectEvents>
              </ext:CommandColumn>
              <ext:Column runat="server" DataIndex="id_usuario" Header="id usuario"></ext:Column>
              <ext:Column runat="server" DataIndex="id_persona" Header="id persona"></ext:Column>
              <ext:Column runat="server" Header="Nombre Completo" Flex="1" DataIndex="pers_nombrecompleto">
                <Items>
                  <ext:TextField runat="server" ID="filterTxtNombreCompleto" />
                </Items>
              </ext:Column>
              <ext:Column runat="server" Header="Usuario" Flex="1" DataIndex="usua_consuser">
                <Items>
                  <ext:TextField runat="server" ID="filterTxtUsuario" />
                </Items>
              </ext:Column>
              <ext:Column runat="server" Header="Email" DataIndex="pers_email" Flex="1">
                <Items>
                  <ext:TextField runat="server" ID="filterTxtEmail" />
                </Items>
              </ext:Column>
              <ext:DateColumn runat="server" Header="Fecha Creación" Format="dd/MM/yyyy" DataIndex="pers_fecha_creacion" Width="150">
              </ext:DateColumn>
              <ext:DateColumn runat="server" Header="Fecha Última Conexión" Format="dd/MM/yyyy" DataIndex="usua_ultimaconexion" Width="150"
                ToolTip="Fecha Última Conexión">
              </ext:DateColumn>
              <ext:BooleanColumn runat="server" Header="Estado" DataIndex="pers_vigente" TrueText="Activo" FalseText="Inactivo" Width="100"></ext:BooleanColumn>
            </Columns>
          </ColumnModel>
          <TopBar>
            <ext:Toolbar runat="server">
              <Items>
                <ext:Button runat="server" Icon="Add" Text="Agregar" ID="btnAgregar">
                  <DirectEvents>
                    <Click OnEvent="OpenWindow_OnEvent">
                      <EventMask ShowMask="True" Msg="Cargando..." />
                      <ExtraParams>
                        <ext:Parameter Name="command" Value="Agregar" />
                      </ExtraParams>
                    </Click>
                  </DirectEvents>
                </ext:Button>
                <ext:ToolbarSeparator runat="server" />
                <ext:Button runat="server" Icon="Find" Text="Filtrar" ></ext:Button>
                <ext:Button runat="server" Icon="Cancel" Text="Limpiar Filtro"></ext:Button>
              </Items>
            </ext:Toolbar>
          </TopBar>
          <BottomBar>
            <ext:PagingToolbar runat="server" ID="pg_grilla">
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
                    <Render Handler="this.setValue(#{param_pagesize}.value);" />
                    <Select Handler="#{param_pagesize}.setValue(this.value);#{strGrilla}.load();#{pg_grilla}.pageSize = parseInt(#{param_pagesize}.value);#{pg_grilla}.updateInfo();" />
                  </Listeners>
                </ext:ComboBox>
              </Items>
              <Listeners>
                <Render Handler="this.pageSize = parseInt(#{param_pagesize}.value); this.updateInfo();" />
              </Listeners>
            </ext:PagingToolbar>
          </BottomBar>
          <SelectionModel>
            <ext:RowSelectionModel runat="server">
              <Listeners>
                <Select Handler="#{strPerfiles}.reload();"></Select>
              </Listeners>
            </ext:RowSelectionModel>
          </SelectionModel>
        </ext:GridPanel>
        <ext:GridPanel runat="server" Icon="Group" Title="Perfiles" ToolTips="Contiene los perfiles asociados a un usuario" Region="East" Width="300" ID="grdPerfiles">
          <Store>
            <ext:Store runat="server" ID="strPerfiles" OnReadData="strPerfiles_OnReadData" PageSize="20" RemoteSort="True" AutoLoad="False">
              <Model>
                <ext:Model runat="server" IDProperty="id_usuarioperfil">
                  <Fields>
                    <ext:ModelField ServerMapping="id_usuarioperfil" SortType="AsInt"/>
                    <ext:ModelField ServerMapping="uspe_descripcion" SortType="AsText"/>
                    <ext:ModelField ServerMapping="id_perfil.id" Name="id_perfil" SortType="AsText"/>
                    <ext:ModelField ServerMapping="id_perfil.descripcion" Name="perf_perfil" SortType="AsText"/>
                    <ext:ModelField ServerMapping="id_usuario.id" Name="id_usuario" SortType="AsText"/>
                    <ext:ModelField ServerMapping="id_usuario.descripcion" Name="usua_consuser" SortType="AsText"/>
                  </Fields>
                </ext:Model>
              </Model>
              <Proxy>
                <ext:PageProxy />
              </Proxy>
              <Parameters>
                <ext:StoreParameter Name="limit" Value="#{param_pagesizePerfiles}.value" Mode="Raw"/>
                <ext:StoreParameter Name="id_persona" Value="#{grdGrilla}.getSelectionModel().getSelection()[0].id"/>
              </Parameters>
              <Sorters>
                <ext:DataSorter Property="perf_perfil" Direction="ASC"/>
              </Sorters>
            </ext:Store>
          </Store>
          <ColumnModel>
            <Columns>
              <ext:RowNumbererColumn runat="server"/>
              <ext:CommandColumn runat="server" ToolTip="Opciones" Width="30">
                <Commands>
                  <ext:GridCommand Icon="Delete" CommandName="Eliminar">
                    <ToolTip Title="Eliminar Registro" Text="Elimina los Datos del Registro Seleccionado" />
                  </ext:GridCommand>
                </Commands>
                <DirectEvents>
                  <Command OnEvent="OpenWinMantenedorPerfiles">
                    <EventMask ShowMask="True" Msg="Cargando..." />
                    <ExtraParams>
                      <ext:Parameter Name="command" Value="command" Mode="Raw" />
                      <ext:Parameter Name="id_usuario" Value="record.data.id_usuario" Mode="Raw" />
                    </ExtraParams>
                  </Command>
                </DirectEvents>
              </ext:CommandColumn>
              <ext:Column runat="server" Header="Perfil" DataIndex="perf_perfil" Flex="1"/>
            </Columns>
          </ColumnModel>
          <TopBar>
            <ext:Toolbar runat="server">
              <Items>
                <ext:Button runat="server" ID="btnAgregarPerfil" Icon="GroupAdd" Text="Agregar Perfil" Disabled="True">
                  <DirectEvents>
                    <Click OnEvent="OpenWinMantenedorPerfiles">
                      <EventMask ShowMask="True" Msg="Cargando..."/>
                      <ExtraParams>
                        <ext:Parameter Name="command" Value="Agregar"/>
                        <ext:Parameter Name="id_usuario" Value="#{grdGrilla}.getSelectionModel().getSelection()[0].id" Mode="Raw"/>
                      </ExtraParams>
                    </Click>
                  </DirectEvents>
                </ext:Button>
              </Items>
            </ext:Toolbar>
          </TopBar>
          <BottomBar>
            <ext:PagingToolbar runat="server"/>
          </BottomBar>
        </ext:GridPanel>
      </Items>
    </ext:Viewport>
    <ext:Hidden runat="server" ID="param_pagesizePerfiles" Text="20"/>
    <ext:Window ID="winMantenedor" runat="server" Modal="true" Hidden="true" Width="500" Height="450">
      <Listeners>
        <Hide Handler="#{strGrilla}.load();" />
      </Listeners>
    </ext:Window>
    <ext:Window runat="server" ID="winMantenedorPerfiles" Modal="True" Hidden="True" Width="900" Height="600">
      <Listeners>
        <Hide Handler="#{strPerfiles}.load();"></Hide>
      </Listeners>
    </ext:Window>
  </form>
</body>
</html>
