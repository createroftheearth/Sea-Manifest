function initCreateTable() {
    if (CreateTable !== undefined) {
        CreateTable.ajax.reload();
        return;
    }
    CreateTable = $('#CustomerModel').DataTable({
        "searching": true,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "filter": true,
        "ajax": {
            "url": "/Ebill/GetBillsList",
            "type": "POST",
            "data": function (d) {
                d.status = "NFR"
                return d;
            },
        },
        "columns": [
            {
                "data": "EWB_ID", visible: false
            },
            {
                data: null, orderable: false
            },
            {
                "data": "DocNo", "render": function (data, type, full) {
                    if (data === null) return "";
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full.EWB_ID) + ");'>" + full.DocNo + "</a>";
                }
            },
            {
                "data": "DocDate", "type": "date ", "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
                }
            },
            {
                "data": "FromGSTIN", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },

            {
                "data": "ToGSTIN", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": "TransporterName", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": "TotalValue", "className": "text-center", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": "Status", "className": "text-center"
            },
            {
                "data": "Action", "className": "text-center"
            }
        ],
        "columnDefs": [
            {
                'targets': 1, 'checkboxes': {
                    'selectRow': true
                }
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 2
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 3
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return "<span><i class='fa fa-inr'></i></span> " + value;
                },
                "targets": 7
            },
            {
                "render": function (data, type, row) {
                    var value = row.Status;
                    return "<center><a data-toggle='modal' data-target='#modal-default-" + row.EWB_ID + "'>" + (value == 1 ? "<i class='fa fa-check-circle text-green' title='Active'></i>" : value == 2 ? "<i class='fa fa-times-circle text-red' title='De-active'></i>" : value == 3 ? "<i class='fa fa-trash text-orange' title='Deleted'></i>" : value == 5 ? "<i class='fa fa-check-circle text-green' title='Active'></i>" : value == null ? "<i class='fa fa-ban text-red' title='Null'></i>" : "<i class='fa fa-stop-circle text-black' title='Freezed'></i>") + "</a></center>";
                },
                "targets": 8
            },
            {
                "render": function (data, type, full) {
                    var ewb_Id = full.EWB_ID;
                    return "<a href='CreateEbill/" + ewb_Id + "'><i class='fa fa-edit'></i></a>"
                },
                "targets": 9
            }
        ],
        "select": {
            style: 'multi',
            selector: 'tr td:first-child'
        },
        drawCallback: function (settings) {
            CreateTable.rows().deselect();
        }
    });
}

$(document).on('click', "#FreezeDoc", function () {
    var tblData = CreateTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.join(",");
    if (arrTableSelectedRowsRendered.length > 0) {
        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ ewb_Id: data }),
            url: "FreezedDoc",
            success: function (data) {
                if (data !== null && data.message !== null) {
                    if (data !== null && data.responseCode === 200) {
                        CreateTable.ajax.reload();
                        alertify.success(data.message);
                    }
                    else { alertify.error(data.message); }
                }
                else {
                    CreateTable.ajax.reload();
                    $('tr').removeClass('selected');
                    alertify.error("Please try again later.");
                }
            },
            error: function (ajaxRequest, strError) {
                var respText = ajaxRequest.responseText;
                alertify.error(strError);
                
            }
        });
    } else { alertify.error("No E-Bill Doc selected for Freezed!..Please select first.."); }
});

$(document).on('click', "#DeleteBill", function () {
    var tblData = CreateTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.toString();
    if (arrTableSelectedRowsRendered.length > 0) {
        alertify.confirm('Are you Sure?', 'You won\'t be able to revert this?', function () {
            $.ajax({
                dataType: 'json',
                type: 'Post',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ ewb_Id: data }),
                url: "DeleteBill",
                success: function (data) {
                    if (data.isSuccess) {
                        if (data != null && data.responseCode == 203) {
                            CreateTable.ajax.reload();
                            $('tr').removeClass('selected');
                            alertify.success("Selected E-bill deleted successfully.");
                        }
                        else {
                            CreateTable.ajax.reload();
                            $('tr').removeClass('selected');
                            alertify.error(data.message);
                        }
                    }
                    else {
                        CreateTable.ajax.reload();
                        $('tr').removeClass('selected');
                        alertify.error("Please try again later.");
                    }
                },
                error: function (ajaxRequest, strError) {
                    var respText = ajaxRequest.responseText;
                    alertify.error(strError);
                }
            });
        }, function () {
        });
    }
    else { alertify.error("No E-Bill Doc selected!..Please select first.."); }
});