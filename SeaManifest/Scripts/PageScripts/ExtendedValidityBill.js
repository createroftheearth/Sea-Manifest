function initExtendedValidityTable() {
    GeneratedTable = $('#tblExtendedValidity').DataTable({
        "searching": true,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "filter": true,
        "ajax": {
            "url": "/Ebill/GetExtendedValidityBillsList",
            "type": "POST",
            "data": function (d) {
                d.status = "BillExtendedValidity"
                return d;
            },
        },
        "columns": [
            {
                "data": "EWB_ID",
                visible: false
            },
            {
                data: null, orderable: false//,
            },
            {
                "data": "DocNo",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full['EWB_ID']) + ");'>" + full['DocNo'] + "</a>";
                }
            },
            {
                "data": "DocDate", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                }
            },
            {
                "data": "EwayBillNo", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },

            {
                "data": "EwayBillDate", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                }
            },
            {
                "data": "ValidUpto", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                }
            },
            {
                "data": "TotalValue", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": "PDF"
            },
            {
                "data": "Status", "orderable": false,
                "render": function (data, type, row, full) {
                    var value = data == null ? " 0 " : data;
                    var Pdf = "<a href='#' class='editor_edit' onclick='javascript:GeneratedDownloadPDF(" + row.EWB_ID + ")'><i class='fa fa-file-pdf-o' style='font-size:15px;color:red'></i></a>";
                    return Pdf;
                }
            }


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
                    return "<span><i class='fa fa-inr'></i></span> " + value;
                },
                "targets": 7
            },
            {
                "render": function (data, type, full) {
                    var sum = full['CGSTValue'] + full['SGSTValue'] + full['IGSTValue'] + full['CessValue'];
                    return "<span><i class='fa fa-inr'></i></span> " + sum;
                },
                "targets": 8

            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    //return "<a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full['EWB_ID']) + ");'>Part-B</a>";
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenPartB(" + JSON.stringify(full.EWB_ID) + ");'>Part-B</a>";
                },
                "targets": [10]
            }
        ],
        select: {
            style: 'multi',
            selector: 'td:first-child'
        }
    });
}