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

//Hide Show Conditions (Hide in case of 'X' and show in case of 'O') 
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
    if (data == "SDN") {
        $('#sAuthPrsnMasterName').val('');
        $('#sAuthPrsnMasterName').parent('div').hide();
    }
    else {
        $('#sAuthPrsnMasterName').parent('div').show();
    }
    if (data == "SAM" || data == "SEI" || data == "SDN") {
        $('#sAuthPrsnShippingLineBondNo').val('');
        $('#sAuthPrsnShippingLineBondNo').parent('div').hide();
    }
    else {
        $('#sAuthPrsnShippingLineBondNo').parent('div').show();
    }

    if (data == "SEI" || data == "SDN") {
        $('#sVesselDtlsPurposeOfCall').val('');
        $('#sVesselDtlsPurposeOfCall').parent('div').hide();
    }
    else {
        $('#sVesselDtlsPurposeOfCall').parent('div').show();
    }
    if (data == "SEI" || data == "SDN") {
        $('#sVoyageDtlsCargoDesCdd').val('');
        $('#sVoyageDtlsCargoDesCdd').parent('div').hide();
    }
    else {
        $('#sVoyageDtlsCargoDesCdd').parent('div').show();
    }
    if (data == "SEI" || data == "SDN") {
        $('#sVoyageDtlsBriefCargoDesc').val('');
        $('#sVoyageDtlsBriefCargoDesc').parent('div').hide();
    }
    else {
        $('#sVoyageDtlsBriefCargoDesc').parent('div').show();
    }
    if (data == "SDM" ||data == "SEI" || data == "SDN") {
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').val('');
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').parent('div').hide();
    }
    else {
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').parent('div').show();
    }
    if (data == "SDM" || data == "SAM") {
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').val('');
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').parent('div').hide();
    }
    else {
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').parent('div').show();
    }
    if (data == "SEI" || data == "SDN") {
        $('#iVoyageDtlsNumberOfPsngrManifested').val('');
        $('#iVoyageDtlsNumberOfPsngrManifested').parent('div').hide();
    }
    else {
        $('#iVoyageDtlsNumberOfPsngrManifested').parent('div').show();
    }
    if (data == "SEI" || data == "SDN") {
        $('#iVoyageDtlsNumberOfCrewManifested').val('');
        $('#iVoyageDtlsNumberOfCrewManifested').parent('div').hide();
    }
    else {
        $('#iVoyageDtlsNumberOfCrewManifested').parent('div').show();
    }

}
//Mandatory Conditions(Mandatory in case of 'M')
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

    if ((data == "SAM" || data == "SDM") && $('#sAuthPrsnMasterName').val() == "") {
        validator.showErrors({
            "sAuthPrsnMasterName": "Master Name is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sAuthPrsnTerminalCustodianCode').val() == "") {
        validator.showErrors({
            "sAuthPrsnTerminalCustodianCode": "Terminal Operator Code is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVesselDtlsModeOfTransport').val() == "") {
        validator.showErrors({
            "sVesselDtlsModeOfTransport": "Mode Of Transport is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVesselDtlsTypeOfTransportMeans').val() == "") {
        validator.showErrors({
            "sVesselDtlsTypeOfTransportMeans": "Type Of Transport Means is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVesselDtlsTransportMeansId').val() == "") {
        validator.showErrors({
            "sVesselDtlsTransportMeansId": "Transport Means Identity is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVesselDtlsPurposeOfCall').val() == "") {
        validator.showErrors({
            "sVesselDtlsPurposeOfCall": "Purpose Of Call is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVoyageDtlsVoyageNo').val() == "") {
        validator.showErrors({
            "sVoyageDtlsVoyageNo": "Voyage No is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVoyageDtlsConveinceRefNo').val() == "") {
        validator.showErrors({
            "sVoyageDtlsConveinceRefNo": "Conveyance Reference Number is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVoyageDtlsTotalNumberofTrnsptEqtMnfstd').val() == "") {
        validator.showErrors({
            "sVoyageDtlsTotalNumberofTrnsptEqtMnfstd": "Total No. Of Transport Equipment Manifested is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVoyageDtlsCargoDesCdd').val() == "") {
        validator.showErrors({
            "sVoyageDtlsCargoDesCdd": "Cargo Description is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVoyageDtlsBriefCargoDesc').val() == "") {
        validator.showErrors({
            "sVoyageDtlsBriefCargoDesc": "Brief Cargo Description is a required field."
        });
        return false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVoyageDtlsTotalNumberOfLines').val() == "") {
        validator.showErrors({
            "sVoyageDtlsTotalNumberOfLines": "Total No. Of Transport Contracts Manifested is a required field."
        });
        return false;
    }
    if ((data == "SAM") && $('#sVoyageDtlsExpectedDtandTimeOfArrival').val() == "") {
        validator.showErrors({
            "sVoyageDtlsExpectedDtandTimeOfArrival": "Expected Date & Time of Arrival is a required field."
        });
        return false;
    }
    if ((data == "SDM") && $('#sVoyageDtlsExpectedDtandTimeOfDeparture').val() == "") {
        validator.showErrors({
            "sVoyageDtlsExpectedDtandTimeOfDeparture": "Expected Date & Time of Departure is a required field."
        });
        return false;
    }
    if ((data == "SDM" || data == "SDM") && $('#iVoyageDtlsNumberOfPsngrManifested').val() == "") {
        validator.showErrors({
            "iVoyageDtlsNumberOfPsngrManifested": "Number Of Passenger Manifested is a required field."
        });
        return false;
    }
    if ((data == "SDM" || data == "SDM") && $('#iVoyageDtlsNumberOfCrewManifested').val() == "") {
        validator.showErrors({
            "iVoyageDtlsNumberOfCrewManifested": "Number Of Crew Manifested  is a required field."
        });
        return false;
    }
    return true;
}

