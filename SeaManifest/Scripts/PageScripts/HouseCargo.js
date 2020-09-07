$(function () {
    initHouseCargos();
});

var HouseCargoTable;

function initHouseCargos() {
    HouseCargoTable = $('#tblHouseCargo').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/HouseCargo/GetHouseCargos",
            "type": "POST",
        },
        "columns": [
            {
                "data": "dHCRefSubLineNo",
            },
            {
                "data": "sHCRefBillNo"
            },
            {
                "data": "sHCRefBillDate",
            },
            {
                "data": "iHouseCargoDescId", "mRender": function (data, abc, full) {
                    var html = "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateHouseCargo(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/TransportEquipmentHouseCargo/Index?iHouseCargoDescId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Transport Equipment</button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/ItineraryHouseCargo/Index?iHouseCargoDescId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Itinerary</button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/SupportDocHouseCargo/Index?iHouseCargoDescId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Support Doc</button>";
                    if ((full.sReportingEvent != "SEI" && full.sReportingEvent != "SDN"))
                        html += "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/ItemDetailsHouseCargo/Index?iHouseCargoDescId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Item Details</button> ";
                    if (full.sReportingEvent !== "SEI")
                        html += "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/AdditionalDetailsHouseCargo/Index?iHouseCargoDescId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Additional Details</button> ";
                    return html;
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
    // this removes the validation HouseCargos
    //$errors.each(function () { $validator.settings.success($(this)); })

    // clear errors from validation
    $validator.resetForm();
}

function AddUpdateHouseCargo(iHouseCargoDescId) {
    $('#addUpdateModallgContainer').load('/HouseCargo/AddUpdateHouseCargo?iHouseCargoDescId=' + iHouseCargoDescId, function () {
        initAddUpdateHouseCargo();


    });
}

function initAddUpdateHouseCargo() {
    $.validator.unobtrusive.parse('#frmHouseCargo');
    $('#frmHouseCargo select').selectpicker();
    $('#psHCRefHouseBillDate').datetimepicker({
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
    changePortOfAccepted();
    changePortOfReceipt();
    changeTypeOfCargo();
    changeConsigneeCountryCode();
    changeConsignorCountryCode();
    changeNotFdCountryCode();
}

$(document).on('submit', '#frmHouseCargo', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkFormHouseCargos())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    HouseCargoTable.ajax.reload();
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
        $('.hideSEI').find('input,select').val('');
        $('.hideSEI').find('select').selectpicker('refresh');

    }
    if (data == "SDN") {
        $('.hideSDN').hide();
        $('.hideSDN').find('input,select').val('');
        $('.hideSDN').find('select').selectpicker('refresh');
    }
}
//Mandatory Conditions(Mandatory in case of 'M')
function checkFormHouseCargos() {
    var validator = $("#frmHouseCargo").validate();
    var data = $('#sReportingEvent').val();
    var returnValue = true;
    if ((data == "SAM" || data == "SDM")) {
        //if ($('#sLocCstmFirstPortOfEntry').val() == "") {
        //    validator.showErrors({
        //        "sLocCstmFirstPortOfEntry": "First port of entry is a required field."
        //    });
        //    $('#sLocCstmFirstPortOfEntry').focus();
        //    returnValue = false;
        //}
        if ($('#sLocCstmDestPort').val() == "") {
            validator.showErrors({
                "sLocCstmDestPort": "Destination port is a required field."
            });
            $('#sLocCstmDestPort').focus();
            returnValue = false;
        }
        if ($('#sLocCstmNextPortOfUnlanding').val() == "") {
            validator.showErrors({
                "sLocCstmNextPortOfUnlanding": "Next port of unlanding is a required field."
            });
            $('#sLocCstmNextPortOfUnlanding').focus();
            returnValue = false;
        }
    }
    if ((data == "SAM" || data == "SDM" || data == "SAA")) {
        if ($('#sTrnsprtrDocPartyPortOfAcceptedCCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyPortOfAcceptedCCd": "Port of accepted code is a required field."
            });
            $('#sTrnsprtrDocPartyPortOfAcceptedCCd').focus();
            returnValue = false;
        }
    }
    if ((data == "SAM" || data == "SDM" || data == "SDA")) {
        if ($('#sTrnsprtrDocPartyPortOfReceiptName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyPortOfReceiptName": "Port of reciept name is a required field."
            });
            $('#sTrnsprtrDocPartyPortOfReceiptName').focus();
            returnValue = false;
        }
    }

    var typeOfCargo = $('#sLocCstmTypeOfCargo').val();

    //*********Consginor********//
    if (typeOfCargo == "EX" || typeOfCargo == "CG") {
        if ($('#sTrnsprtrDocPartyConsignorCd').val() == "" && $('#sMCRefConsolidatedIndicator').val() != "C") {
            validator.showErrors({
                "sTrnsprtrDocPartyConsignorCd": "Consignor Code is a required field."
            });
            $("#sTrnsprtrDocPartyConsignorCd").focus();
            returnValue = false;
        }
    }


    if (($('#sTrnsprtrDocPartyConsignorCdType').val() == "GSN" || $('#sTrnsprtrDocPartyConsignorCdType').val() == "GSD" || $('#sTrnsprtrDocPartyConsignorCdType').val() == "GSG") && !$('#sTrnsprtrDocPartyConsignorCd').isValidGSTIN()) {
        validator.showErrors({
            "sTrnsprtrDocPartyConsignorCd": "Please Enter valid GSTIN No"
        });
        $('#sTrnsprtrDocPartyConsignorCd').focus();
        returnValue = false;
    }
    else if (($('#sTrnsprtrDocPartyConsignorCdType').val() == "PAN") && !$('#sTrnsprtrDocPartyConsignorCd').isValidPAN()) {
        validator.showErrors({
            "sTrnsprtrDocPartyConsignorCd": "Please Enter valid PAN"
        });
        $('#sTrnsprtrDocPartyConsignorCd').focus();
        returnValue = false;
    }

    if ($('#sTrnsprtrDocPartyConsignorCountryCd').val() == "IN") {
        if ($('#ddlConsignorSubDivCode').val() == "") {
            validator.showErrors({
                "ddlConsignorSubDivCode": "Consignor Sub Division Code is a required field."
            });
            $('#ddlConsignorSubDivCode').focus();
            returnValue = false;
        } if ($('#sTrnsprtrDocPartyConsignorPostCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyConsignorPostCd": "Consignor Post Code is a required field."
            });
            $('#sTrnsprtrDocPartyConsignorPostCd').focus();
            returnValue = false;
        }
    }
    if ($('#sTrnsprtrDocPartyConsignorCountryCd').val() != "IN") {
        if ($('#sTrnsprtrDocPartyConsigneeCountrySubDivName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyConsigneeCountrySubDivName": "Consignor Sub Division Name is a required field."
            });
            $('#sTrnsprtrDocPartyConsigneeCountrySubDivName').focus();
            returnValue = false;
        }
    }
    //*********Consginee********//

    if (typeOfCargo == "IM" || typeOfCargo == "CG") {
        if ($('#sTrnsprtrDocPartyConsigneeCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyConsigneeCd": "Consignee Code is a required field."
            });
            $("#sTrnsprtrDocPartyConsigneeCd").focus();
            returnValue = false;
        }
    }
    if (($('#sTrnsprtrDocPartyTypeOfCd').val() == "GSN" || $('#sTrnsprtrDocPartyTypeOfCd').val() == "GSD" || $('#sTrnsprtrDocPartyTypeOfCd').val() == "GSG") && !$('#sTrnsprtrDocPartyConsigneeCd').isValidGSTIN()) {
        validator.showErrors({
            "sTrnsprtrDocPartyConsigneeCd": "Please Enter valid GSTIN No"
        });
        $('#sTrnsprtrDocPartyConsigneeCd').focus();
        returnValue = false;
    }
    else if (($('#sTrnsprtrDocPartyTypeOfCd').val() == "PAN") && !$('#sTrnsprtrDocPartyConsigneeCd').isValidPAN()) {
        validator.showErrors({
            "sTrnsprtrDocPartyConsigneeCd": "Please Enter valid PAN"
        });
        $('#sTrnsprtrDocPartyConsigneeCd').focus();
        returnValue = false;
    }
    if ($('#sTrnsprtrDocPartyConsigneeCountryCd').val() == "IN") {
        if ($('#ddlConsigneeSubDivCode').val() == "") {
            validator.showErrors({
                "ddlConsigneeSubDivCode": "Consignee Sub Division Code is a required field."
            });
            $('#ddlConsigneeSubDivCode').focus();
            returnValue = false;
        }
        if ($('#sTrnsprtrDocPartyConsigneePostCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyConsigneePostCd": "Consignee Post Code is a required field."
            });
            $('#sTrnsprtrDocPartyConsigneePostCd').focus();
            returnValue = false;
        }
    }
    if ($('#sTrnsprtrDocPartyConsigneeCountryCd').val() != "IN") {
        if ($('#sTrnsprtrDocPartyConsigneeCountrySubDivName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyConsigneeCountrySubDivName": "Consignee Sub Division Name is a required field."
            });
            $('#sTrnsprtrDocPartyConsigneeCountrySubDivName').focus();
            returnValue = false;
        }
    }

    //****Notified Party********//
    if ($('#sTrnsprtrDocPartyNotFdPartyCountryCd').val() == "IN") {
        if ($('#ddlNotFdPartySubDivCode').val() == "") {
            validator.showErrors({
                "ddlNotFdPartySubDivCode": "Notified Party Sub Division Code is a required field."
            });
            $('#ddlNotFdPartySubDivCode').focus();
            returnValue = false;
        }
        if ($('#sTrnsprtrDocPartyNotFdPartyPostCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyNotFdPartyPostCd": "Notified Party Post Code is a required field."
            });
            $('#sTrnsprtrDocPartyNotFdPartyPostCd').focus();
            returnValue = false;
        }
    }
    if ($('#sTrnsprtrDocPartyNotFdPartyCountryCd').val() != "IN") {
        if ($('#sTrnsprtrDocPartyNotFdPartyCountrySubDivName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocPartyNotFdPartyCountrySubDivName": "Notified Sub Division Name is a required field."
            });
            $('#sTrnsprtrDocPartyNotFdPartyCountrySubDivName').focus();
            returnValue = false;
        }
    }
    return returnValue;
}


$(document).on('change', '#sLocCstmTypeOfCargo', function () {
    changeTypeOfCargo();
});

function changeTypeOfCargo() {
    var typeOfCargo = $('#sLocCstmTypeOfCargo').val();
    if (typeOfCargo == "EX") {
        $('#sTrnsprtrDocPartyConsignorCdType option').each(function (i, ele) {
            if ($(ele).val() == "GSN" || $(ele).val() == "GSD" || $(ele).val() == "GSG" || $(ele).val() == "PAN")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocPartyConsignorCdType').selectpicker('refresh');
        $('#sTrnsprtrDocPartyTypeOfCd option').each(function (i, ele) {
            if ($(ele).val() == "GSN" || $(ele).val() == "GSD" || $(ele).val() == "GSG")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocPartyTypeOfCd').selectpicker('refresh');
    }
    if (typeOfCargo == "CG") {
        $('#sTrnsprtrDocPartyConsignorCdType option').each(function (i, ele) {
            if ($(ele).val() == "IEC")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocPartyConsignorCdType').selectpicker('refresh');
        $('#sTrnsprtrDocPartyTypeOfCd option').each(function (i, ele) {
            if ($(ele).val() == "IEC")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocPartyTypeOfCd').selectpicker('refresh');
    }


}


$(document).on('change', '#sTrnsprtrDocPartyPortOfAcceptedCCd', function () {
    changePortOfAccepted();
});

function changePortOfAccepted() {
    if ($('#sTrnsprtrDocPartyPortOfAcceptedCCd').val() != "") {
        $('#sTrnsprtrDocPartyPortOfAcceptedName').val($('#sTrnsprtrDocPartyPortOfAcceptedCCd option:selected').text());
    }
}

$(document).on('change', '#sTrnsprtrDocPartyPortOfReceiptCcd', function () {
    changePortOfReceipt();
});

function changePortOfReceipt() {
    if ($('#sTrnsprtrDocPartyPortOfReceiptCcd').val() != "") {
        $('#sTrnsprtrDocPartyPortOfReceiptName').val($('#sTrnsprtrDocPartyPortOfReceiptCcd option:selected').text());
    }
}

$(document).on('change', '#sTrnsprtrDocPartyConsignorCountryCd', function () {
    changeConsignorCountryCode();
});


function changeConsignorCountryCode() {
    if ($('#sTrnsprtrDocPartyConsignorCountryCd').val() == "IN") {
        $('#sTrnsprtrDocPartyConsignorCountrySubDivCd').hide();
        $('#ddlConsignorSubDivCode').selectpicker('refresh');
        $('#ddlConsignorSubDivCode').parent('div').show();
    }
    else {
        $('#sTrnsprtrDocPartyConsignorCountrySubDivCd').show();
        $('#ddlConsignorSubDivCode').parent('div').hide();
    }
}

$(document).on('change', '#ddlConsignorSubDivCode', function () {
    if ($('#ddlConsignorSubDivCode').val() != "") {
        $('#sTrnsprtrDocPartyConsignorCountrySubDivCd').val($(this).val());
    }
});

$(document).on('change', '#sTrnsprtrDocPartyConsigneeCountryCd', function () {
    changeConsigneeCountryCode();
});

function changeConsigneeCountryCode() {
    if ($('#sTrnsprtrDocPartyConsigneeCountryCd').val() == "IN") {
        $('#sTrnsprtrDocPartyConsigneeCountrySubDiv').hide();
        $('#ddlConsigneeSubDivCode').selectpicker('refresh');
        $('#ddlConsigneeSubDivCode').parent('div').show();
    }
    else {
        $('#sTrnsprtrDocPartyConsigneeCountrySubDiv').show();
        $('#ddlConsigneeSubDivCode').parent('div').hide();
    }
}

$(document).on('change', '#ddlConsigneeSubDivCode', function () {
    if ($('#ddlConsigneeSubDivCode').val() != "") {
        $('#sTrnsprtrDocPartyConsigneeCountrySubDiv').val($(this).val());
    }
});

$(document).on('change', '#sTrnsprtrDocPartyNotFdPartyCountryCd', function () {
    changeNotFdCountryCode();
});

function changeNotFdCountryCode() {
    if ($('#sTrnsprtrDocPartyNotFdPartyCountryCd').val() == "IN") {
        $('#sTrnsprtrDocPartyNotFdPartyCountrySubDiv').hide();
        $('#ddlNotFdPartySubDivCode').selectpicker('refresh');
        $('#ddlNotFdPartySubDivCode').parent('div').show();
    }
    else {
        $('#sTrnsprtrDocPartyNotFdPartyCountrySubDiv').show();
        $('#ddlNotFdPartySubDivCode').parent('div').hide();
    }
}

$(document).on('change', '#ddlNotFdPartySubDivCode', function () {
    if ($('#ddlNotFdPartySubDivCode').val() != "") {
        $('#sTrnsprtrDocPartyNotFdPartyCountrySubDiv').val($(this).val());
    }
});