var GeneratedTable;
function initGeneratedTable() {
    GeneratedTable = $('#tblReport').DataTable({
        "order": [[4, "desc"]],
        "searching": true,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/EbillReport/GetEBillsReportsByFilter",
            "type": "POST",
            "data": function (d) {
                d.supplyType = $('#SupplyType').val();
                d.subsupplyType = $('#SubSupplyType').val();
                return d;
            },
        },
        "columns": [
            {
                "data": "EwayBillDate",
                "render": function (value, abc, full) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return full.EwayBillNo + " & " + dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + formatAMPM(dt);
                }
            },
            {
                "data": "SupplyType",
            },
            {
                "data": "DocDate",
                "render": function (value, abc, full) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return full.DocNo + " & " + dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + formatAMPM(dt);
                }
            },
            {
                "data": "ToGSTIN",
            },
            {
                "data": "TransporterId",
                "render": function (value, abc, full) {
                    return value + " " + full.TransporterName;
                }
            },
            {
                "data": "FromGSTIN",
                "render": function (value, abc, full) {
                    return value + " " + full.FromTrdName + " " + full.FromAddress1 + " " + full.FromAddress2 + " " + full.FromPlace + " " + full.FromPlace + " " + full.FromStateName + " " + full.FromPincode;
                }
            },
            {
                "data": "ToGSTIN",
                "render": function (value, abc, full) {
                    return value + " " + full.ToTrdName + " " + full.ToAddress1 + " " + full.ToAddress2 + " " + full.ToPlace + " " + full.ToPlace + " " + full.ToStateName + " " + full.ToPincode;
                }
            },
            {
                "data": "Status",
            },
            {
                "data": "Status", "mRender":function(data, acb, full) {
                    return full.EWB_TRN_EWBILL_ITEM_RequestModel.reduce(function (a, b) {
                        return a + b.Quantity;
                    },0)
                }
            },
            {
                "data": "Status",
                "render": function (value, abc, full) {
                    return full.EWB_TRN_EWBILL_ITEM_RequestModel.reduce(function (a, b) {
                        debugger;
                        return a + ", " + b.HsnCode + " " + b.ProductDesc ;
                    },"")
                }

            },
            {
                "data": "TotalValue", "defaultContent": '<a href="#" class="editor_edit">--</a>', "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return "<span><i class='fa fa-inr'></i></span> " + value;
                },
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
        ]
    });
}


$(function () {
    initGeneratedTable();
    $.validator.unobtrusive.parse('#FrmEbillReport');
    $('#SupplyType').selectpicker();
    $('#SubSupplyType').selectpicker();
    changeSupply();
    var options = {
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: new Date()
        //endDate: '+0d'
    };
    var endOptions = {
        format: 'dd/mm/yyyy',
        endDate: new Date(),
        todayHighlight: true,
        autoclose: true,
    };

    $("#FromDate").datepicker(options);
    $("#ToDate").datepicker(endOptions);
    $("#FromDate").on('changeDate', function (selected) {
        if (selected.date !== null) {
            var minDate = new Date(selected.date.valueOf());
            $("#ToDate").datepicker('setStartDate', minDate);
        }
    });

    $("#ToDate").on('changeDate', function (selected) {
        if (selected.date !== null) {
            var minDate = new Date(selected.date.valueOf());
            $("#FromDate").datepicker('setEndDate', minDate);
        }
    });
});


function changeSupply() {
    var html = "<option value>Select</option>";
    $.ajax({
        url: "/EbillReport/GetSubSupplyTypeBySupply",
        data: { SupplyType: $('#SupplyType').val() },
        type: "GET",
        success: function (res) {
            res.forEach(function (val, i) {
                html += "<option value=" + val.Value + ">" + val.Text + "</option>";
            });
            $('#SubSupplyType').html(html);
            $('#SubSupplyType').selectpicker('refresh');
        }
    });
}

$(document).on('change', '#SupplyType', function () {
    changeSupply();
});


$(document).on('submit', '#FrmEbillReport', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.Status) {
                repsonse.Data();
            } else {
                alertify.error(response.Message);
            }
        },
        failure: function (response) {
            alertify.error("Some Error found.");
        },
        error: function (response) {
            alertify.error("Failed! to cancel Some Error found.");
        }
    });
});

