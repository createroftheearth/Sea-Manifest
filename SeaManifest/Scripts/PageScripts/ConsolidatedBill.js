function initConsolidatedTable() {
    ConsolidatedBill = $('#tblConsolidated').DataTable({
        //"order": [[6, "desc"]],
        "searching": true,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "filter": true,
        "bLengthChange": false,
        "ajax": {
            "url": "/Ebill/EWayConsolidatedAllList",
            "type": "POST",
            "data": function (d) {
                d.apiType = "CONSBILL"
                return d;
            },
        },
        "columns": [
            {
                "data": "ConsolidatedID", visible: false
            },
            {
                data: null, orderable: false,
            },
            {
                "data": "cEwbNo",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenConsolPopUp(" + JSON.stringify(full['ConsolidatedID']) + ");'>" + full['cEwbNo'] + "</a>";
                }
            },

            {
                "data": "cEWBDate", "className": "text-left", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + formatAMPM(dt);
                }
            },
            {
                "data": "FromPlace",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['FromPlace'];
                }
            },
            {
                "data": "TransDocNo",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return full['TransDocNo'];
                }
            },
            {
                "data": "TransDocDate", "className": "text-left", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + formatAMPM(dt);
                }
            },
            {
                "data": "Reconsol",
                "render": function (data, type, row, full) {
                    if (row.Status) {
                        var value = data == null ? " 0 " : data;
                        var reco = "<a href='#' class='editor_edit' onclick='javascript:OpenReConsol(" + row.ConsolidatedID + "," + row.cEwbNo + ");'>Reconsolidate</a>";
                        return reco;
                    }
                    else
                        return "";
                }
            },
            {
                "data": "ParentcEWBs",
                "render": function (data, type, row) {
                    return prepareParentConsoleHtml(data);
                },
            },
            {
                "data": "ErrorCode", "className": "text-left", "orderable": false
            },
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
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 4
            },

            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 5
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": 6
            },
            {
                "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return value + " <span><i class='fa fa-inr'></i></span>";
                },
                "targets": [7],
                "id": "ConRE"
            },
            {
                "render": function (data, type, row, full) {
                    var value = data == null ? " 0 " : data;
                    var result = { message: row.ErrorMessage };
                    var Errorcodee = row.ErrorCode != null ? "<a href=# class=editor_edit onclick='javascript:OpenErrorMessage(\"" + '(' + row.ErrorCode + ') ' + row.ErrorMessage + "\")'>Failed Message</a>" : "<a href='#' class='editor_edit' onclick='javascript:DownloadPDF(" + row.ConsolidatedID + ")'><i class='fa fa-file-pdf-o' style='font-size:15px;color:red'></i></a>";
                    return Errorcodee

                },
                "targets": [9]
            },
        ],
        "rowCallback": function (row, data, index) {
            if (!data.Status) {
                row.style.backgroundColor = "#ffd6d6";
            }
        },
        select: {
            style: 'multi',
            selector: 'td:first-child'
        },
        drawCallback: function (settings) {
            var HTML = '<button class="btn btn-primary btn-xs" onClick="GetConsolEwayBill()">Get Consolidated Eway Bill</button>';
            $('#tblConsolidated_wrapper > .row > div:first').html(HTML);
            ConsolidatedBill.rows().deselect();
        }
    });
};


function prepareParentConsoleHtml(parentConsoles) {
    var html = "";
    parentConsoles.forEach(function (val, i, full) {
        html += ' <div class="btn-group">'
            + '<button data-toggle="dropdown" class="btn btn-link dropdown-toggle" aria-expanded="false">' + val.cEwbNo + '</button>'
            + '<ul class="dropdown-menu">'
            + '<li><a class="dropdown-item" onclick="OpenConsolPopUp(' + val.ConsoleId + ');" href="#"><i class="fa fa-view"></i> View</a></li>'
            + '<li><a class="dropdown-item" onclick="DownloadPDF(' + val.ConsoleId + ')" href="#"><i class="fa fa-file-pdf"></i>Download PDF</a></li>'
            + '</ul>'
            + '</div>'
    });
    return html;
}

function OpenReConsol(consid, cewbno) {
    $('#addUpdateModallgContainer').load('/Ebill/ReconsolidateBill?consid=' + consid + "&cewbno=" + cewbno, function () {
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $('#RCTransDocDate').datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        $("#RCReason").selectpicker();
        $("#RCMode").selectpicker();
        $("#RCFromState").selectpicker();
        $.validator.unobtrusive.parse('#frmReconsolidateBill');
        $('#addUpdatelgModal').modal('show');
    });
}

function DownloadPDF(Cewbid) {
    location.href = '/Ebill/PrintConsolidatedReport?ConsolidatedID=' + Cewbid;
}

$(document).on('submit', '#frmReconsolidateBill', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkTransporterDetails()) {
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.isSuccess) {
                    alertify.success("Ebill reconsolidated successfully..");
                } else {
                    alertify.error(response.message);
                }
                $('.modal').modal('hide');
            },
            failure: function (response) {
                alertify.error("Some Error found.");
            },
            error: function (response) {
                alertify.error("Failed! to cancel Some Error found.");
            }
        });
    }
});

$(document).on('change', '#IreasonCode', function () {
    if ($('#IreasonCode option:selected').text() !== "Others") {
        $('#rowOtherInitiate').hide();
        $('#IreasonRem').val('');
    }
    else {
        $('#rowOtherInitiate').show();
    }
});

function checkTransporterDetails() {
    var mode = $('#RCMode option:selected').text();
    var CtransDocNo = $('#RCTransDocNo').val();
    var CtransDocDate = $('#RCTransDocDate').val();
    var RCVehNo = $('#RCVehNo').val();
    var validator = $("#frmReconsolidateBill").validate();
    resetForm();
    if (mode == "Road" && RCVehNo == "") {
        validator.showErrors({
            "RCVehNo": "Vehicle No is a required field."
        });
        return false;
    }
    else if (mode == "Rail" || mode == "Air" || mode == "Ship") {
        var IsValid = true;
        if (CtransDocNo == "") {
            validator.showErrors({
                "RCTransDocNo": "Tranporter Doc. No is a required field."
            });
            IsValid = false;
        }
        if (CtransDocDate == "") {
            validator.showErrors({
                "RCTransDocDate": "Tranporter Doc. Date is a required field."
            });
            IsValid = false;
        }
        return IsValid;
    }
    return true;
}

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


function OpenConsolPopUp(ewbid) {
    $('#addUpdateModallgContainer').load('/EBILL/ConsoleDetails?ID=' + ewbid, function () {
        $('.m-t-none b').html('Consolidated Bill');
        $('#tblConsoleDetails').dataTable({
            responsive: true
        });
        $("#addUpdatelgModal").modal('show');
    });
}


function GetConsolEwayBill() {
    $("#addUpdateModallgContainer").load("/Ebill/GetConsolidatedBillAction", function () {
        $.validator.unobtrusive.parse('#frmGetConsolidatedDetails');
        $("#addUpdatelgModal").modal('show');
    })
    return false;
}


$(document).on('submit', '#frmGetConsolidatedDetails', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                alertify.success("Consolidated Bill Fetched successfully");
                ConsolidatedBill.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.message);
            }
        },
        failure: function (response) {
            alertify.error("Some Error found.");
        },
        error: function (response) {
            alertify.error("Failed! to Upadte Consolidated Bill, Some Error found.");
        }
    });
});
