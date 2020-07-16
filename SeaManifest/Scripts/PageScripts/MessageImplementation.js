$(function () {
    initMessages();
});

var MessageTable;
function initMessages() {
    MessageTable = $('#tblMessage').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/MessageImplementation/GetMessages",
            "type": "POST",
        },
        "columns": [
            {
                "data": "sHeaderFieldSenderId",
            },
            {
                "data": "sHeaderFieldReceiverId"
            },
            {
                "data": "sHeaderFieldVersionNo",
            },
            {
                "data": "sHeaderFieldMessageId",
            },
            {
                "data": "FieldSequenceOrControlNumber"
            },
            {
                "data": "Date"
            },
            {
                "data": "Time"
            },
            {
                "data": "sHeaderFieldReportingEvent"
            },
            {
                "data": "iMessageImplementationId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateMessage(" + data + ")\"><i class=\"fa fa-edit\"></i></button> ";
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
    // this removes the validation messages
    //$errors.each(function () { $validator.settings.success($(this)); })

    // clear errors from validation
    $validator.resetForm();
}


function AddUpdateMessage(iMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/MessageImplementation/AddUpdateMessage?iMessageImplementationId=' + iMessageImplementationId, function () {
        initAddUpdateMessage();
    });
}

function initAddUpdateMessage() {
    $.validator.unobtrusive.parse('#frmMessage');
    $('#sReportingEvent').selectpicker();
    $('#addUpdatelgModal').modal('show');
    changeReportingEvent();
}

$(document).on('submit', '#frmMessage', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkFormMessages())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    MessagesTable.ajax.reload();
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


$(document).on('change', '#sReportingEvent', function () {
    changeReportingEvent();
});

function changeReportingEvent() {
    var data = $('#sReportingEvent').val();
    if (data == "SDN") {
        $('#sDate').val('');
        $('#sDate').parent('div').hide();
        $('#sSequenceOrControlNumber').val('');
        $('#sSequenceOrControlNumber').parent('div').hide();
        $('#sTime').val('');
        $('#sTime').parent('div').hide();
    }
    else {
        $('#sSequenceOrControlNumber').parent('div').show();
        $('#sDate').parent('div').show();
        $('#sTime').parent('div').show();
    }

    if (data == "SDM" || data == "SEI" || data == "SDN") {
        $('#sAuthPrsnShipLineCode').val('');
        $('#sAuthPrsnShipLineCode').parent('div').hide();
    }
    else {
        $('#sAuthPrsnShipLineCode').parent('div').show();
    }
}

function checkFormMessages() {
    var validator = $("#frmMessage").validate();
    var data = $('#sReportingEvent').val();
    if (data == "SAM" && $('#sAuthPrsnShipLineCode').val() == "") {
        validator.showErrors({
            "sAuthPrsnShipLineCode": "Shipping Line Code is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sAuthPrsnAuthSeaCarrierCode').val() == "") {
        validator.showErrors({
            "sAuthPrsnAuthSeaCarrierCode": "Authorised Sea Carrier Code is a required field."
        });
        return false;
    }
    return true;
}

