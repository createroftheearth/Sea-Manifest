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
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateMessage(" + data + ")\"><i class=\"fa fa-edit\"></i></button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/MasterConsignment/Index?iMessageImplementationId=" + data + "'\"><i class=\"fa fa-plus\"></i></button> " +
                        "<button type=\"button\" class=\"btn btn-success btn-xs\" onClick=\"DownloadJson(" + data + ")\"><i class=\"fa fa-download\"></i></button> ";
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

function DownloadJson(iMessageImplementationId) {
    location.href = "/MessageImplementation/GetMessageJson?iMessageImplementationId=" + iMessageImplementationId;
}

function AddUpdateMessage(iMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/MessageImplementation/AddUpdateMessage?iMessageImplementationId=' + iMessageImplementationId, function () {
        initAddUpdateMessage();
    });
}

function initAddUpdateMessage() {
    $.validator.unobtrusive.parse('#frmMessage');
    $('#frmMessage select').selectpicker();
    $('#headerFieldDatePicker').datetimepicker();
    $('#psDecRefManifestDateRotnDt').datetimepicker({
        format: 'L'
    });
    $('#psDecRefJobDt').datetimepicker({
        format: 'L'
    });
    $('#psDecRefPreviousManifestDptrDate').datetimepicker({
        format: 'L'
    });
    $('#psVoyageDtlsExpectedDtandTimeOfArrival').datetimepicker();
    $('#psVoyageDtlsExpectedDtandTimeOfDeparture').datetimepicker();
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
    if (data == "SAA" || data == "SDA") {
        $('#sDecRefMsgType option').each(function (i, ele) {
            if ($(ele).val() == "F")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sDecRefMsgType').selectpicker('refresh');
    }
    else {
        $('#sDecRefMsgType option').each(function (i, ele) {
            if ($(ele).val() != "F")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sDecRefMsgType').selectpicker('refresh');
    }

    if (data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") {
        $('#sVesselDtlsVesselCode').val('');
        $('#sVesselDtlsVesselCode').parent('div').hide();
        $('#sVesselDtlsNationalityOfShip').val('');
        $('#sVesselDtlsNationalityOfShip').parent('div').hide();
        $('#sVesselDtlsPortOfRegistry').val('');
        $('#sVesselDtlsPortOfRegistry').parent('div').hide();
        $('#sVesselDtlsRegistryDate').val('');
        $('#sVesselDtlsRegistryDate').parent('div').hide();
        $('#sVesselDtlsRegistryNo').val('');
        $('#sVesselDtlsRegistryNo').parent('div').hide();
        $('#dVesselDtlsGrossTonnage').val('');
        $('#dVesselDtlsGrossTonnage').parent('div').hide();
        $('#dVesselDtlsNetTonnage').val('');
        $('#dVesselDtlsNetTonnage').parent('div').hide();
    }
    else {
        $('#sVesselDtlsVesselCode').parent('div').show();
        $('#sVesselDtlsNationalityOfShip').parent('div').show();
        $('#sVesselDtlsPortOfRegistry').parent('div').show();
        $('#sVesselDtlsRegistryDate').parent('div').show();
        $('#sVesselDtlsRegistryNo').parent('div').show();
        $('#dVesselDtlsGrossTonnage').parent('div').show();
        $('#dVesselDtlsNetTonnage').parent('div').show();
    }


    if (data == "SDN") {
        $('#sDateTime').val('');
        $('#sDateTime').parent('div').parent('div').hide();
        $('#dSequenceOrControlNumber').val('');
        $('#dSequenceOrControlNumber').parent('div').parent('div').hide();
        $('#dDecRefjobNo').val('');
        $('#dDecRefjobNo').parent('div').hide();
        $('#sDecRefJobDt').val('');
        $('#sDecRefJobDt').parent('div').hide();
        $('#sAuthPrsnMasterName').val('');
        $('#sAuthPrsnMasterName').parent('div').hide();
        $('#iArvlDtlsLightHouseDues').val('');
        $('#iArvlDtlsLightHouseDues').parent('div').hide();
    }
    else {
        $('#dSequenceOrControlNumber').parent('div').show();
        $('#sDateTime').parent('div').parent('div').show();
        $('#dDecRefjobNo').parent('div').show();
        $('#sDecRefJobDt').parent('div').show();
        $('#sAuthPrsnMasterName').parent('div').show();
        $('#iArvlDtlsLightHouseDues').parent('div').show();
    }

    if (data == "SDM" || data == "SEI" || data == "SDN") {
        $('#sAuthPrsnShipLineCode').val('');
        $('#sAuthPrsnShipLineCode').parent('div').hide();
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').val('');
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').parent('div').parent('div').hide();
    }
    else {
        $('#sAuthPrsnShipLineCode').parent('div').show();
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').parent('div').parent('div').show();

    }

    if (data == "SAM" || data == "SEI" || data == "SDN") {
        $('#sAuthPrsnShippingLineBondNo').val('');
        $('#sAuthPrsnShippingLineBondNo').parent('div').hide();
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').val('');
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').parent('div').hide();
    }
    else {
        $('#sAuthPrsnShippingLineBondNo').parent('div').show();
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').parent('div').show();
    }


    if (data == "SEI" || data == "SDN") {
        $('#sVesselDtlsPurposeOfCall').val('');
        $('#sVesselDtlsPurposeOfCall').parent('div').hide();
        $('#sVoyageDtlsVoyageNo').val('');
        $('#sVoyageDtlsVoyageNo').parent('div').hide();
        $('#sVoyageDtlsCargoDesCdd').val('');
        $('#sVoyageDtlsCargoDesCdd').parent('div').hide();
        $('#sVoyageDtlsBriefCargoDesc').val('');
        $('#sVoyageDtlsBriefCargoDesc').parent('div').hide();
        $('#iVoyageDtlsNumberOfPsngrManifested').val('');
        $('#iVoyageDtlsNumberOfPsngrManifested').parent('div').hide();
        $('#iVoyageDtlsNumberOfCrewManifested').val('');
        $('#iVoyageDtlsNumberOfCrewManifested').parent('div').hide();
    }
    else {
        $('#sVesselDtlsPurposeOfCall').parent('div').show();
        $('#sVoyageDtlsVoyageNo').parent('div').show();
        $('#sVoyageDtlsCargoDesCdd').parent('div').show();
        $('#sVoyageDtlsBriefCargoDesc').parent('div').show();
        $('#iVoyageDtlsNumberOfPsngrManifested').parent('div').show();
        $('#iVoyageDtlsNumberOfCrewManifested').parent('div').show();
    }

    if (data == "SAM" || data == "SDM") {
        $('.ArrDptrDetails').hide();
    }
    else
        $('.ArrDptrDetails').show();

    if (data == "SAA" || data == "SDA") {
        $('#iArvlDtlsTotalNoOfCntrsLanded').val('');
        $('#iArvlDtlsTotalNoOfCntrsLanded').parent('div').hide();
        $('#iArvlDtlsTotalOfCntrsLoaded').val('');
        $('#iArvlDtlsTotalOfCntrsLoaded').parent('div').hide();
    }
    else {
        $('#iArvlDtlsTotalNoOfCntrsLanded').parent('div').show();
        $('#iArvlDtlsTotalNoOfCntrsLoaded').parent('div').show();
    }
}
//Mandatory Conditions(Mandatory in case of 'M')
function checkFormMessages() {
    var returnValue = true;
    var validator = $("#frmMessage").validate();
    var vesselType = $('#sDecRefVesselTypeMovement').val();
    var data = $('#sReportingEvent').val();
    if (data == "SAM" && $('#sAuthPrsnShipLineCode').val() == "") {
        validator.showErrors({
            "sAuthPrsnShipLineCode": "Shipping Line Code is a required field."
        });
        $('#sAuthPrsnShipLineCode').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sAuthPrsnAuthSeaCarrierCode').val() == "") {
        validator.showErrors({
            "sAuthPrsnAuthSeaCarrierCode": "Authorised Sea Carrier Code is a required field."
        });
        $('#sAuthPrsnAuthSeaCarrierCode').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sAuthPrsnMasterName').val() == "") {
        validator.showErrors({
            "sAuthPrsnMasterName": "Master Name is a required field."
        });
        $('#sAuthPrsnMasterName').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sAuthPrsnTerminalCustodianCode').val() == "") {
        validator.showErrors({
            "sAuthPrsnTerminalCustodianCode": "Terminal Operator Code is a required field."
        });
        $('#sAuthPrsnTerminalCustodianCode').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVesselDtlsModeOfTransport').val() == "") {
        validator.showErrors({
            "sVesselDtlsModeOfTransport": "Mode Of Transport is a required field."
        });
        $('#sVesselDtlsModeOfTransport').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVesselDtlsTypeOfTransportMeans').val() == "") {
        validator.showErrors({
            "sVesselDtlsTypeOfTransportMeans": "Type Of Transport Means is a required field."
        });
        $('#sVesselDtlsTypeOfTransportMeans').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVesselDtlsTransportMeansId').val() == "") {
        validator.showErrors({
            "sVesselDtlsTransportMeansId": "Transport Means Identity is a required field."
        });
        $('#sVesselDtlsTransportMeansId').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVesselDtlsPurposeOfCall').val() == "") {
        validator.showErrors({
            "sVesselDtlsPurposeOfCall": "Purpose Of Call is a required field."
        });
        $('#sVesselDtlsPurposeOfCall').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVoyageDtlsVoyageNo').val() == "") {
        validator.showErrors({
            "sVoyageDtlsVoyageNo": "Voyage No is a required field."
        });
        $('#sVoyageDtlsVoyageNo').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVoyageDtlsConveinceRefNo').val() == "") {
        validator.showErrors({
            "sVoyageDtlsConveinceRefNo": "Conveyance Reference Number is a required field."
        });
        $('#sVoyageDtlsConveinceRefNo').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVoyageDtlsTotalNumberofTrnsptEqtMnfstd').val() == "") {
        validator.showErrors({
            "sVoyageDtlsTotalNumberofTrnsptEqtMnfstd": "Total No. Of Transport Equipment Manifested is a required field."
        });
        $('#sVoyageDtlsTotalNumberofTrnsptEqtMnfstd').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVoyageDtlsCargoDesCdd').val() == "") {
        validator.showErrors({
            "sVoyageDtlsCargoDesCdd": "Cargo Description is a required field."
        });
        $('#sVoyageDtlsCargoDesCdd').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#sVoyageDtlsBriefCargoDesc').val() == "") {
        validator.showErrors({
            "sVoyageDtlsBriefCargoDesc": "Brief Cargo Description is a required field."
        });
        $('#sVoyageDtlsBriefCargoDesc').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM" || data == "SEI" || data == "SDN") && $('#sVoyageDtlsTotalNumberOfLines').val() == "") {
        validator.showErrors({
            "sVoyageDtlsTotalNumberOfLines": "Total No. Of Transport Contracts Manifested is a required field."
        });
        $('#sVoyageDtlsTotalNumberOfLines').focus();
        returnValue = false;
    }
    if ((data == "SAM") && $('#sVoyageDtlsExpectedDtandTimeOfArrival').val() == "") {
        validator.showErrors({
            "sVoyageDtlsExpectedDtandTimeOfArrival": "Expected Date & Time of Arrival is a required field."
        });
        $('#sVoyageDtlsExpectedDtandTimeOfArrival').focus();
        returnValue = false;
    }
    if ((data == "SDM") && $('#sVoyageDtlsExpectedDtandTimeOfDeparture').val() == "") {
        validator.showErrors({
            "sVoyageDtlsExpectedDtandTimeOfDeparture": "Expected Date & Time of Departure is a required field."
        });
        $('#sVoyageDtlsExpectedDtandTimeOfDeparture').val();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#iVoyageDtlsNumberOfPsngrManifested').val() == "") {
        validator.showErrors({
            "iVoyageDtlsNumberOfPsngrManifested": "Number Of Passenger Manifested is a required field."
        });
        $('#iVoyageDtlsNumberOfPsngrManifested').focus();
        returnValue = false;
    }
    if ((data == "SAM" || data == "SDM") && $('#iVoyageDtlsNumberOfCrewManifested').val() == "") {
        validator.showErrors({
            "iVoyageDtlsNumberOfCrewManifested": "Number Of Crew Manifested  is a required field."
        });
        $('#iVoyageDtlsNumberOfCrewManifested').focus();
        returnValue = false;
    }
    if ((data == "SEI" || data == "SDN") && $('#iArvlDtlsNumberOfPassengers').val() == "") {
        validator.showErrors({
            "iArvlDtlsNumberOfPassengers": "Number Of Passengers  is a required field."
        });
        $('#iArvlDtlsNumberOfPassengers').focus();
        returnValue = false;
    }
    if ((data == "SEI" || data == "SDN") && $('#iArvlDtlsNumberOfCrew').val() == "") {
        validator.showErrors({
            "iArvlDtlsNumberOfCrew": "Number Of Crew  is a required field."
        });
        $('#iArvlDtlsNumberOfCrew').focus();
        returnValue = false;
    }
    if (data == "SEI" && $('#iArvlDtlsLightHouseDues').val() == "") {
        validator.showErrors({
            "iArvlDtlsLightHouseDues": "Light House Dues  is a required field."
        });
        $('#iArvlDtlsLightHouseDues').focus();
        returnValue = false;
    }
    if (data == "SDN" && $('#iArvlDtlsTotalNoOfCntrsLanded').val() == "") {
        validator.showErrors({
            "iArvlDtlsTotalNoOfCntrsLanded": "Total no of containers landed is a required field."
        });
        $('#iArvlDtlsTotalNoOfCntrsLanded').focus();
        returnValue = false;
    }
    if (data == "SDN" && $('#iArvlDtlsTotalOfCntrsLoaded').val() == "") {
        validator.showErrors({
            "iArvlDtlsTotalOfCntrsLoaded": "Total no of containers loaded is a required field."
        });
        $('#iArvlDtlsTotalOfCntrsLoaded').focus();
        returnValue = false;
    }
    if ((data == "SDN" || data == "SEI") && $('#iArvlDtlsTotalNoOfPersonOnBoard').val() == "") {
        validator.showErrors({
            "iArvlDtlsTotalNoOfPersonOnBoard": "Total no of person on board is a required field."
        });
        $('#iArvlDtlsTotalNoOfPersonOnBoard').focus();
        returnValue = false;
    }
    if ((data == "SDN" || data == "SEI") && $('#iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr').val() == "") {
        validator.showErrors({
            "iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr": "Total No of transport equipment reported on Arrival/Departure is a required field."
        });
        $('#iArvlDtlsTotalNoOfTrnsprtEqReprtdOnArrDptr').focus();
        returnValue = false;
    }
    if ((data == "SDN" || data == "SEI") && $('#iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr').val() == "") {
        validator.showErrors({
            "iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr": "Total No of transport contract reported on Arrival/Departure is a required field."
        });
        $('#iArvlDtlsTotalNoOfTrnsprtCntrctReprtdOnArrDptr').focus();
        returnValue = false;
    }



    if (vesselType == "II") {
        if ($('#dDecRefDptrPreviousManifestNo').val() == "") {
            $('#dDecRefDptrPreviousManifestNo').focus();
            validator.showErrors({ "dDecRefDptrPreviousManifestNo": "Departure Previous Manifest is a required field." });
            returnValue = false;
        }
        if ($('#sDecRefPreviousManifestDptrDate').val() == "") {
            $('#sDecRefPreviousManifestDptrDate').focus();
            validator.showErrors({ "sDecRefPreviousManifestDptrDate": "Departure Previous Manifest is a required field." });
            returnValue = false;
        }
    }
    if (vesselType == "RI") {
        if ($('#sAuthPrsnShippingLineBondNo').val() == "") {
            $('#sAuthPrsnShippingLineBondNo').focus();
            validator.showErrors({ "sAuthPrsnShippingLineBondNo": "Shipping Line Bond Number is a required field." });
            returnValue = false;
        }
    }
    return returnValue;
}

