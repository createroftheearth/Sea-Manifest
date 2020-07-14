function initReceivedTable() {
    if (ReceivedBill !== undefined) {
        ReceivedBill.ajax.reload();
        return;
    }
    ReceivedBill = $('#tblRecevied').DataTable({
        "searching": true,
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Ebill/RecivedBillsList",
            "type": "POST"
        },
        "columns": [
            {
                "data": "ApiGetResId",
                visible: false
            },
            {
                data: null,
                //defaultContent: '',
                // className: 'select-checkbox',
                orderable: false//,
                //visible:false
            },
            {
                "data": "ewbNo",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full['ApiGetResId']) + ");'>" + full['ewbNo'] + "</a>";


                }
            },
            //{
            //    //"data": "ewbDate",
            //    //"className": "text-left",
            //    //"type": "date ",
            //    //"render": function (value) {
            //    //    if (value === null) return "";
            //    //    var pattern = /Date\(([^)]+)\)/;
            //    //    var results = pattern.exec(value);
            //    //    var dt = new Date(parseFloat(results[0]));
            //    //    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
            //    }
            //},
            {
                "data": "ewbDate",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['ewbDate'];
                }
            },

            {
                "data": "docNo",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['docNo'];
                }
            },

            {
                "data": "docDate",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['docDate'];
                }
            },

            {
                "data": "fromgstin",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['fromgstin'];
                }
            },

            {
                "data": "fromTradename",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['fromgstin'];
                }
            },

            {
                "data": "togstin",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['togstin'];
                }
            },

            {
                "data": "toTradename",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['toTradename'];
                }
            },

            {
                "data": "genGstin",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['genGstin'];
                }
            },


            {
                "data": "delPlace",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['delPlace'];
                }
            },


            {
                "data": "delStateCode",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['delStateCode'];
                }
            },

            //{
            //    "data": "totInvValue",
            //    "render": function (data, type, full) {
            //        if (data === null) return "";
            //        return full['totInvValue'];
            //    }
            //},


            {
                "data": "ApiStatus",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['ApiStatus'];
                }
            },




            //{
            //    "data": "TotalValue",
            //    "className": "text-right", "orderable": false,
            //    "defaultContent": '<a href="#" class="editor_edit">--</a>'
            //},
            //{
            //    "data": "ApiStatus",
            //    "className": "text-right", "orderable": false
            //},
            //{
            //    "data": "ErrorCode",
            //    "className": "text-right", "orderable": false
            //},

            //{
            //    "data": "Status",
            //    "className": "text-center", "orderable": false
            //}


        ],
        "columnDefs": [
            {
                'targets': 1,
                'checkboxes': {
                    'selectRow': true
                }
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 4
            },
            {
                "render": function (data, type, full) {
                    var sum = full['CGSTValue'] + full['SGSTValue'] + full['IGSTValue'] + full['CessValue'];
                    return sum + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 5

            },
            {
                "render": function (data, type, row, full) {
                    var value = data == null ? " 0 " : data;
                    var result = { message: row.ErrorMessage };
                    var apiStatus = row.ApiStatus != null ? "<center><a href=# class=editor_edit onclick='javascript:OpenErrorMessage(\"" + '(' + row.ErrorCode + ') ' + row.ErrorMessage + "\")'>Failed Message</a></center>" : "<center><a href='#' class='editor_edit' onclick='javascript:DownloadPDF(" + row.EWB_ID + ")'>PDF</a></center>";
                    return apiStatus;


                },
                "targets": [6]
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return "<center><a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full['EWB_ID']) + ");'>Part-B</a></center>";
                },
                "targets": [7]
            }
        ],
        select: {
            style: 'multi',
            selector: 'td:first-child'
        }
    });
}