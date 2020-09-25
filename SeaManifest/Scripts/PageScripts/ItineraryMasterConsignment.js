$(function () {
    initItenaryMasterConsignment();
});

var ItenaryMasterConsignment;
function initItenaryMasterConsignment() {
    ItenaryMasterConsignment = $('#tblItenaryMasterConsignment').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/ItineraryMasterConsignment/GetItineraryMasterConsignment",
            "type": "POST",
        },
        "columns": [
            {
                "data": "dPortOfCallSequenceNo",
            },
            {
                "data": "sPortOfCallCd"
            },
            {
                "data": "sPortOfCallName",
            },
            {
                "data": "sNextPortOfCallCdd",
            },
            {
                "data": "sNextPortOfCallName",
            },
            {
                "data": "sModeOfTransport",
            },
            {
                "data": "iItineraryId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs not-hide\" onClick=\"AddUpdateItineraryMasterConsignment(" + data + ")\"><i class=\"fa fa-edit\"></i></button> ";
                        
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
    // this removes the validation MasterConsignment
    //$errors.each(function () { $validator.settings.success($(this)); })

    // clear errors from validation
    $validator.resetForm();
}


function AddUpdateItineraryMasterConsignment(iItenaryMasterConsignmentId) {
    $('#addUpdateModallgContainer').load('/ItineraryMasterConsignment/AddUpdateItineraryMasterConsignment?iItenaryMasterConsignmentId=' + iItenaryMasterConsignmentId, function () {
        initAddUpdateItenaryMasterConsignment();
    });
}

function initAddUpdateItenaryMasterConsignment() {
    $.validator.unobtrusive.parse('#frmItineraryMasterConsignment');
    $('#frmItineraryMasterConsignment select').selectpicker();
    $('#addUpdatelgModal').modal('show');
}

$(document).on('submit', '#frmItineraryMasterConsignment', function (e) {
    e.preventDefault();
    if ($(this).valid())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    ItenaryMasterConsignment.ajax.reload();
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

function checkItenaryMasterConsginment() {
    var returnValue = true;
    var validator = $("#frmTransportEquipmentMessageImplementation").validate();
    var data = $('#sReportingEvent').val();
    if (data !== "SAA") {
        if ($('#dPortOfCallSequenceNo').val() == "") {
            validator.showErrors({
                "dPortOfCallSequenceNo": "Port of Call Seq No. is a required field."
            });
            $('#dPortOfCallSequenceNo').focus();
            returnValue = false;
        }
        if ($('#sModeOfTransport').val() == "") {
            validator.showErrors({
                "sModeOfTransport": "Mode of Transport is a required field."
            });
            $('#sModeOfTransport').focus();
            returnValue = false;
        }
    }
    return returnValue;
}


