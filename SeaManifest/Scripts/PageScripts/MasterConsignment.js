$(function () {
    initMasterConsignments();
});

var MasterConsignmentTable;

function initMasterConsignments() {
    MasterConsignmentTable = $('#tblMasterConsignment').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/MasterConsignment/GetMasterConsignments",
            "type": "POST",
        },
        "columns": [
            {
                "data": "iMCRefLineNo",
            },
            {
                "data": "sMCRefMasterBillNo"
            },
            {
                "data": "masterBillDate",
            },
            {
                "data": "iMasterConsignmentId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateMasterConsignment(" + data + ")\"><i class=\"fa fa-edit\"></i></button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/HouseCargo/Index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i></button> ";
                }
            },
        ]
    });
}

function resetForm() {
    var $form = $("form");

    // get validator object
    var $validator = $form.validate();

    // get errors that were created using jQuery.validate.unobtrusive
    var $errors = $form.find(".field-validation-error span");

    // trick unobtrusive to think the elements were succesfully validated
    // this removes the validation MasterConsignments
    //$errors.each(function () { $validator.settings.success($(this)); })

    // clear errors from validation
    $validator.resetForm();
}

function DownloadJson(iMasterConsignmentId) {
    location.href = "/MasterConsignment/GetMasterConsignmentJson?iMasterConsignmentId=" + iMasterConsignmentId;
}

function AddUpdateMasterConsignment(iMasterConsignmentId) {
    $('#addUpdateModallgContainer').load('/MasterConsignment/AddUpdateMasterConsignment?iMasterConsignmentId=' + iMasterConsignmentId, function () {
        initAddUpdateMasterConsignment();
    });
}

function initAddUpdateMasterConsignment() {
    $.validator.unobtrusive.parse('#frmMasterConsignment');
    $('#frmMasterConsignment select').selectpicker();
    $('#psMCRefMasterBillDate').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('#psPrevRefCSNDate').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('#psSuplmntryDecCSNDate').datetimepicker({
        format: 'DD/MM/YYYY hh:mm A'
    });
    $('#addUpdatelgModal').modal('show');
    showHideViaMessageType();
}

$(document).on('submit', '#frmMasterConsignment', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkFormMasterConsignments())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    MasterConsignmentTable.ajax.reload();
                    $('.modal').modal('hide');
                } else {
                    alertify.error(response.Message);
                }
            },
            failure: function (response) {
                alertify.error("Some Error found.");
            },
            error: function (response) {
                alertify.error("Failed! Some Error found.");
            }
        });
});


//Hide Show Conditions (Hide in case of 'X' and show in case of 'O') 
function showHideViaMessageType() {
    var data = $('#sReportingEvent').val();
    if (data == "SEI") {
        $('.hideSEI').hide();
    }
    if (data == "SDN") {
        $('.hideSDN').hide();
    }

}
//Mandatory Conditions(Mandatory in case of 'M')
function checkFormMasterConsignments() {
    var validator = $("#frmMasterConsignment").validate();
    var data = $('#sReportingEvent').val();
    var returnValue = true;
    if ((data == "SAM" || data == "SDM")) {
        if ($('#sLocCustomFirstPortOfEntry').val() == "") {
            validator.showErrors({
                "sLocCustomFirstPortOfEntry": "First port of entry is a required field."
            });
            $('#sLocCustomFirstPortOfEntry').focus();
            returnValue = false;
        }
        if ($('#sLocCustomDestPort').val() == "") {
            validator.showErrors({
                "sLocCustomDestPort": "Destination port is a required field."
            });
            $('#sLocCustomDestPort').focus();
            returnValue = false;
        }
        if ($('#sLocCustomNextPortOfUnlanding').val() == "") {
            validator.showErrors({
                "sLocCustomNextPortOfUnlanding": "Next port of unlanding is a required field."
            });
            $('#sLocCustomNextPortOfUnlanding').focus();
            returnValue = false;
        }
    }
    if ((data == "SAM" || data == "SDM" || data == "SAA")) {
        if ($('#sTrnsprtrDocPortOfAcceptedCCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPortOfAcceptedCCd": "Port of accepted code is a required field."
            });
            $('#sTrnsprtrDocPortOfAcceptedCCd').focus();
            returnValue = false;
        }
    }
    if ((data == "SAM" || data == "SDM" || data == "SDA")) {
        if ($('#sTrnsprtrDocPortOfReceiptName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPortOfReceiptName": "Port of reciept name is a required field."
            });
            $('#sTrnsprtrDocPortOfReceiptName').focus();
            returnValue = false;
        }
    }
    return returnValue;
}

