function jsonSortInfo(store,fieldOrden) {
  if (store.sortInfo) {
    var SortInfo = {
      direction: store.sortInfo.direction,
      field: store.sortInfo.field
    };
  } else {
    var SortInfo = {
      direction: "asc",
      field: fieldOrden
    };
  }
  return Ext.encode(SortInfo);
}

function jsonColumnInfo(ColumnModel) {
  var Columns = new Array();
  Ext.each(ColumnModel.columns, function (Pcolumn, Pindex) {
    var Info = {
      index: Pindex,
      indexname: Pcolumn.dataIndex,
      header: Pcolumn.header,
      hidden: Pcolumn.hidden ? Pcolumn.hidden : false
    }

    Columns.push(Info);
  });
  return Ext.encode(Columns);
}