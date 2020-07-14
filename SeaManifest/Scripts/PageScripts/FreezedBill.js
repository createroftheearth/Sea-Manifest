function initFreezeTable() {
    if (FreezedTable !== undefined) {
        FreezedTable.ajax.reload();
        return;
    }
    FreezedTable = $('#tblFreeze').DataTable({
        "searching": true,
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Ebill/GetBillsList",
            "type": "POST",
            "data": function (d) {
                d.status = "FRZ"
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
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full.EWB_ID) + "); '>" + full.DocNo + '(' + full.DocType + ')';
                }
            },
            {
                "data": "DocDate", "className": "text-left", "type": "date ", "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
                }
            },
            {
                "data": "TotalValue", "orderable": true, "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": "CGSTValue", "orderable": true
            },
            {
                "data": "ErrorCode", "orderable": false
            },
            {
                "data": "Status", "orderable": false
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
                    return "<span><i class='fa fa-inr'></i></span> " + value;
                },
                "targets": 4
            },
            {
                "render": function (data, type, full) {
                    var sum = full.CGSTValue + full.SGSTValue + full.IGSTValue + full.CessValue;
                    return "<span><i class='fa fa-inr'></i></span> " + sum;
                },
                "targets": 5
            },
            {
                "render": function (data, type, row, full) {
                    var value = data == null ? " 0 " : data;
                    var result = { message: row.ErrorMessage };
                    var successData = '<div class="btn-group">' +
                        '<button data-toggle="dropdown" class="btn btn-link dropdown-toggle" aria-expanded="false"><i class="fa fa-file-pdf-o" style="font-size:15px;color:red"></i></button>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a class="dropdown-item" onclick="DownloadFreezedPDF(' + row.EWB_ID + ')" href="#">Detailed PDF</li>' +
                        '<li><a class="dropdown-item" href="/Ebill/PrintFreezeReportWithoutDetails?EWB_ID=' + row.EWB_ID + '">Non Detailed PDF</li>' +
                        '</ul></div> ';
                    var apiStatus = row.ApiStatus != null ? "<a href=# class=editor_edit onclick='javascript:OpenErrorMessage(\"" + '(' + row.ErrorCode + ') ' + row.ErrorMessage + "\")'>Failed Message</a>" : successData;
                    return apiStatus;
                },
                "targets": [6]
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenPartB(" + JSON.stringify(full.EWB_ID) + ");'>Part-B</a>";
                },
                "targets": [7]
            }
        ],
        select: {
            style: 'multi',
            selector: 'td:first-child'
        },
        drawCallback: function (settings) {
            FreezedTable.rows().deselect();
        }

    });
}

function DownloadFreezedPDF(ewbid) {
    location.href = '/Ebill/PrintFreezeReport?EWB_ID=' + ewbid;
}

$(document).on('click', "#unFreeze", function () {
    var tblData = FreezedTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.toString();
    if (arrTableSelectedRowsRendered.length > 0) {
        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ ewb_Id: data }),
            url: "/Ebill/UnfreezeDoc",
            success: function (data) {
                if (data != null && data.message != null) {
                    if (data != null && data.responseCode == 200) {
                        FreezedTable.ajax.reload();
                        alertify.success(data.message);
                    }
                    else { alertify.error(data.message); }
                }
                else {
                    FreezedTable.ajax.reload();
                    alertify.error("Please try again later.");
                }
            },
            error: function (ajaxRequest, strError) {
                var respText = ajaxRequest.responseText;
                FreezedTable.ajax.reload();
                alertify.error(strError);
            }
        });
    } else { alertify.error("No E-Bill Doc selected for UnFreezed!..Please select first.."); }
});

$(document).on('click', "#SaveBill", function () {
    var tblData = FreezedTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.join(",");
    debugger;
    if (arrTableSelectedRowsRendered.length > 0) {
        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ ebillId: data }),
            url: "/Ebill/GenerateApiBill",
            success: function (data) {
                if (data.isSuccess) {
                    FreezedTable.ajax.reload();
                    alertify.success("Ebill generated successfully.");
                }
                else {
                    FreezedTable.ajax.reload();
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

function OpenErrorMessage(message) {

    if (!alertify.errorAlert) {
        //define a new errorAlert base on alert
        alertify.dialog('errorAlert', function factory() {
            return {
                build: function () {
                    var errorHeader = '<span class="fa fa-times-circle fa-2x" '
                        + 'style="vertical-align:middle;color:#e10000;">'
                        + '</span> E-Way Bill Generate Error';
                    this.setHeader(errorHeader);
                }
            };
        }, true, 'alert');
    }
    alertify
        .errorAlert("<p style='color:red;'>1. " + message + ".</p><br/><b>Note :</b><i> Kindly remove this error message then Re-Generate the E-Way Bill.</i>");
}

function OpenPartB(ewbid) {
    $('#addUpdateModalContainer').load('/Ebill/partbupdate?ID=' + ewbid, function () {
        $('#TransMode').selectpicker('refresh');
        $('#VehicleType').selectpicker('refresh');
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $("#TransDocDate").datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        $('#ReasonCode').selectpicker('refresh');
        changeReasonCode();
        $.validator.unobtrusive.parse('#frmPartB');
        $("#addUpdateModal").modal('show');
    });
};

function checkTransporterDetails() {
    var mode = $('#TransMode option:selected').text();
    var vehicleNo = $('#VehicleNo').val();
    var transporterId = $('#TransporterId').val();
    var transDocNo = $('#TransDocNo').val();
    var TransDocDate = $('#TransDocDate').val();
    var validator = $("#frmPartB").validate();
    resetForm();
    if (mode === "Road") {
        if (vehicleNo == "" && transporterId == "") {
            validator.showErrors({
                "TransporterId": "Either Transporter Id or Vehicle No should be entered in case of Road."
            });
            validator.showErrors({
                "VehicleNo": "Either Vehicle No or Transporter Id should be entered in case of Road."
            });
            return false;
        }
    }
    else if (mode == "Rail" || mode == "Air" || mode == "Ship") {
        var IsValid = true;
        if (transDocNo == "") {
            validator.showErrors({
                "TransDocNo": "Tranporter Doc. No is a required field."
            });
            IsValid = false;
        }
        if (TransDocDate == "") {
            validator.showErrors({
                "TransDocDate": "Tranporter Doc. Date is a required field."
            });
            IsValid = false;
        }
        return IsValid;
    }
    return true;
}

$(document).on('submit', '#frmPartB', function (e) {
    e.preventDefault();
    var $this = $(this);
    if ($this.valid() && checkTransporterDetails()) {
        var formData = $(this).serialize();
        $.ajax({
            url: $this.attr('action'),
            type: "GET",
            global: false,
            data: formData,
            success: function (result) {
                if (result.isSuccess) {
                    FreezedTable.ajax.reload();
                    alertify.success(result.message);
                    $('.modal').modal('hide');
                }
                else {
                    alertify.error(result.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
                alertify.error(errorThrown.message);
            }
        });
    }
});

function resetForm() {
    var $form = $("form");

    // get validator object
    var $validator = $form.validate();

    // get errors that were created using jQuery.validate.unobtrusive
    var $errors = $form.find(".field-validation-error span");

    // trick unobtrusive to think the elements were succesfully validated
    // this removes the validation messages
    //$errors.each(function () { $validator.settings.success($(this)); })

    // clear errors from validation
    $validator.resetForm();
}