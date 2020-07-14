function initRejectedTable() {
    RejectedBill = $('#tblRejected').DataTable({
        "searching": true,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "filter": true,
        "ajax": {
            "url": "/Ebill/GetBillsByAPI",
            "type": "POST",
            "data": function (d) {
                d.apiType = "RJTBILL"
                return d;
            },
        },
        "columns": [
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
            }
        ],
        "columnDefs": [
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return "<span><i class='fa fa-inr'></i></span> " + value;
                },
                "targets": 5
            }
        ]
    });
}