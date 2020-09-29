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
                "data": "iMCRefLineNo", "width": "10%"
            },
            {
                "data": "sMCRefMasterBillNo", "width": "10%"
            },
            {
                "data": "masterBillDate", "width": "10%"
            },
            {
                "data": "iMasterConsignmentId", "mRender": function (data, abc, full) {
                    var html = "<button type=\"button\" class=\"btn btn-warning btn-xs not-hide\" onClick=\"AddUpdateMasterConsignment(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/transportequipmentmasterconsignment/index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Transport Equipment</button> " +
                        "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/supportdocmasterconsignment/index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Support Doc</button> ";
                    if ((full.sReportingEvent != "SEI" && full.sReportingEvent != "SDN")) {
                        html += "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/itinerarymasterconsignment/index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Itinerary</button> " +
                            "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/itemdetailsmasterconsignment/index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Item Details</button> " +
                            "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/housecargo/index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add House Cargo</button> ";
                    }
                    if (full.sReportingEvent !== "SEI")
                        html += "<button type=\"button\" class=\"btn btn-primary btn-xs\" onClick=\"location.href='/additionaldetailsmasterconsignment/index?iMasterConsignmentId=" + data + "'\"><i class=\"fa fa-plus\"></i> Add Additional Details</button> ";
                    return html;
                }
            },
        ],
        "drawCallback": function (settings) {
            showHideButtons();
        }
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
    changePortOfAccepted();
    changePortOfReceipt();
    changeTypeOfCargo();
    changeConsigneeCountryCode();
    changeConsignorCountryCode();
    changeNotFdCountryCode();
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

    var typeOfCargo = $('#sLocCustomTypeOfCargo').val();

    //*********Consginor********//
    if (typeOfCargo == "EX" || typeOfCargo == "CG") {
        if ($('#sTrnsprtrDocConsignorCd').val() == "" && $('#sMCRefConsolidatedIndicator').val() != "C") {
            validator.showErrors({
                "sTrnsprtrDocConsignorCd": "Consignor Code is a required field."
            });
            $("#sTrnsprtrDocConsignorCd").focus();
            returnValue = false;
        }
    }


    if (($('#sTrnsprtrDocConsignorCdType').val() == "GSN" || $('#sTrnsprtrDocConsignorCdType').val() == "GSD" || $('#sTrnsprtrDocConsignorCdType').val() == "GSG") && !$('#sTrnsprtrDocConsignorCd').isValidGSTIN()) {
        validator.showErrors({
            "sTrnsprtrDocConsignorCd": "Please Enter valid GSTIN No"
        });
        $('#sTrnsprtrDocConsignorCd').focus();
        returnValue = false;
    }
    else if (($('#sTrnsprtrDocConsignorCdType').val() == "PAN") && !$('#sTrnsprtrDocConsignorCd').isValidPAN()) {
        validator.showErrors({
            "sTrnsprtrDocConsignorCd": "Please Enter valid PAN"
        });
        $('#sTrnsprtrDocConsignorCd').focus();
        returnValue = false;
    }

    if ($('#sTrnsprtrDocConsignorCountryCd').val() == "IN") {
        if ($('#ddlConsignorSubDivCode').val() == "") {
            validator.showErrors({
                "ddlConsignorSubDivCode": "Consignor Sub Division Code is a required field."
            });
            $('#ddlConsignorSubDivCode').focus();
            returnValue = false;
        } if ($('#sTrnsprtrDocConsignorPostCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocConsignorPostCd": "Consignor Post Code is a required field."
            });
            $('#sTrnsprtrDocConsignorPostCd').focus();
            returnValue = false;
        }
    }
    if ($('#sTrnsprtrDocConsignorCountryCd').val() != "IN" && data != "SDN" && data != "SEI") {
        if ($('#sTrnsprtrDocConsigneeCountrySubDivName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocConsigneeCountrySubDivName": "Consignor Sub Division Name is a required field."
            });
            $('#sTrnsprtrDocConsigneeCountrySubDivName').focus();
            returnValue = false;
        }
    }
    //*********Consginee********//

    if (typeOfCargo == "IM" || typeOfCargo == "CG") {
        if ($('#sTrnsprtrDocConsigneeCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocConsigneeCd": "Consignee Code is a required field."
            });
            $("#sTrnsprtrDocConsigneeCd").focus();
            returnValue = false;
        }
    }
    if (($('#sTrnsprtrDocTypeOfCd').val() == "GSN" || $('#sTrnsprtrDocTypeOfCd').val() == "GSD" || $('#sTrnsprtrDocTypeOfCd').val() == "GSG") && !$('#sTrnsprtrDocConsigneeCd').isValidGSTIN()) {
        validator.showErrors({
            "sTrnsprtrDocConsigneeCd": "Please Enter valid GSTIN No"
        });
        $('#sTrnsprtrDocConsigneeCd').focus();
        returnValue = false;
    }
    else if (($('#sTrnsprtrDocTypeOfCd').val() == "PAN") && !$('#sTrnsprtrDocConsigneeCd').isValidPAN()) {
        validator.showErrors({
            "sTrnsprtrDocConsigneeCd": "Please Enter valid PAN"
        });
        $('#sTrnsprtrDocConsigneeCd').focus();
        returnValue = false;
    }
    if ($('#sTrnsprtrDocConsigneeCountryCd').val() == "IN") {
        if ($('#ddlConsigneeSubDivCode').val() == "") {
            validator.showErrors({
                "ddlConsigneeSubDivCode": "Consignee Sub Division Code is a required field."
            });
            $('#ddlConsigneeSubDivCode').focus();
            returnValue = false;
        }
        if ($('#sTrnsprtrDocConsigneePostCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocConsigneePostCd": "Consignee Post Code is a required field."
            });
            $('#sTrnsprtrDocConsigneePostCd').focus();
            returnValue = false;
        }
    }
    if ($('#sTrnsprtrDocConsigneeCountryCd').val() != "IN" && data != "SDN" && data != "SEI") {
        if ($('#sTrnsprtrDocConsigneeCountrySubDivName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocConsigneeCountrySubDivName": "Consignee Sub Division Name is a required field."
            });
            $('#sTrnsprtrDocConsigneeCountrySubDivName').focus();
            returnValue = false;
        }
    }

    //****Notified Party********//
    if ($('#sTrnsprtrDocNotFdPartyCountryCd').val() == "IN") {
        if ($('#ddlNotFdPartySubDivCode').val() == "") {
            validator.showErrors({
                "ddlNotFdPartySubDivCode": "Notified Party Sub Division Code is a required field."
            });
            $('#ddlNotFdPartySubDivCode').focus();
            returnValue = false;
        }
        if ($('#sTrnsprtrDocNotFdPartyPostCd').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocNotFdPartyPostCd": "Notified Party Post Code is a required field."
            });
            $('#sTrnsprtrDocNotFdPartyPostCd').focus();
            returnValue = false;
        }
    }
    if ($('#sTrnsprtrDocNotFdPartyCountryCd').val() != "IN" && data != "SDN" && data != "SEI") {
        if ($('#sTrnsprtrDocNotFdPartyCountrySubDivName').val() == "") {
            validator.showErrors({
                "sTrnsprtrDocNotFdPartyCountrySubDivName": "Notified Sub Division Name is a required field."
            });
            $('#sTrnsprtrDocNotFdPartyCountrySubDivName').focus();
            returnValue = false;
        }
    }
    var natureOfCargo = $('#sLocCustomNatureOfCargo').val();
    if (natureOfCargo == "LB" && $('#dTrnsprtrDocMsrGrossVolume').val() == "") {
        validator.showErrors({
            "dTrnsprtrDocMsrGrossVolume": "Gross Volume is a required field."
        });
        $('#dTrnsprtrDocMsrGrossVolume').focus();
        returnValue = false;
    }
    return returnValue;
}


$(document).on('change', '#sLocCustomTypeOfCargo', function () {
    changeTypeOfCargo();
});

function changeTypeOfCargo() {
    var typeOfCargo = $('#sLocCustomTypeOfCargo').val();
    if (typeOfCargo == "EX") {
        $('#sTrnsprtrDocConsignorCdType option').each(function (i, ele) {
            if ($(ele).val() == "GSN" || $(ele).val() == "GSD" || $(ele).val() == "GSG" || $(ele).val() == "PAN")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocConsignorCdType').selectpicker('refresh');
        $('#sTrnsprtrDocTypeOfCd option').each(function (i, ele) {
            if ($(ele).val() == "GSN" || $(ele).val() == "GSD" || $(ele).val() == "GSG")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocTypeOfCd').selectpicker('refresh');
    }
    if (typeOfCargo == "CG") {
        $('#sTrnsprtrDocConsignorCdType option').each(function (i, ele) {
            if ($(ele).val() == "IEC")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocConsignorCdType').selectpicker('refresh');
        $('#sTrnsprtrDocTypeOfCd option').each(function (i, ele) {
            if ($(ele).val() == "IEC")
                $(ele).attr('disabled', 'disabled');
            else
                $(ele).removeAttr('disabled');
            $(ele).removeAttr('selected');
        });
        $('#sTrnsprtrDocTypeOfCd').selectpicker('refresh');
    }


}


$(document).on('change', '#sTrnsprtrDocPortOfAcceptedCCd', function () {
    changePortOfAccepted();
});

function changePortOfAccepted() {
    if ($('#sTrnsprtrDocPortOfAcceptedCCd').val() != "") {
        $('#sTrnsprtrDocPortOfAcceptedName').val($('#sTrnsprtrDocPortOfAcceptedCCd option:selected').text());
    }
}

$(document).on('change', '#sTrnsprtrDocPortOfReceiptCcd', function () {
    changePortOfReceipt();
});

function changePortOfReceipt() {
    if ($('#sTrnsprtrDocPortOfReceiptCcd').val() != "") {
        $('#sTrnsprtrDocPortOfReceiptName').val($('#sTrnsprtrDocPortOfReceiptCcd option:selected').text());
    }
}

$(document).on('change', '#sTrnsprtrDocConsignorCountryCd', function () {
    changeConsignorCountryCode();
});


function changeConsignorCountryCode() {
    if ($('#sTrnsprtrDocConsignorCountryCd').val() == "IN") {
        $('#sTrnsprtrDocConsignorCountrySubDivCd').hide();
        $('#ddlConsignorSubDivCode').selectpicker('refresh');
        $('#ddlConsignorSubDivCode').parent('div').show();
    }
    else {
        $('#sTrnsprtrDocConsignorCountrySubDivCd').show();
        $('#ddlConsignorSubDivCode').parent('div').hide();
    }
}

$(document).on('change', '#ddlConsignorSubDivCode', function () {
    if ($('#ddlConsignorSubDivCode').val() != "") {
        $('#sTrnsprtrDocConsignorCountrySubDivCd').val($(this).val());
    }
});

$(document).on('change', '#sTrnsprtrDocConsigneeCountryCd', function () {
    changeConsigneeCountryCode();
});

function changeConsigneeCountryCode() {
    if ($('#sTrnsprtrDocConsigneeCountryCd').val() == "IN") {
        $('#sTrnsprtrDocConsigneeCountrySubDiv').hide();
        $('#ddlConsigneeSubDivCode').selectpicker('refresh');
        $('#ddlConsigneeSubDivCode').parent('div').show();
    }
    else {
        $('#sTrnsprtrDocConsigneeCountrySubDiv').show();
        $('#ddlConsigneeSubDivCode').parent('div').hide();
    }
}

$(document).on('change', '#ddlConsigneeSubDivCode', function () {
    if ($('#ddlConsigneeSubDivCode').val() != "") {
        $('#sTrnsprtrDocConsigneeCountrySubDiv').val($(this).val());
    }
});

$(document).on('change', '#sTrnsprtrDocNotFdPartyCountryCd', function () {
    changeNotFdCountryCode();
});

function changeNotFdCountryCode() {
    if ($('#sTrnsprtrDocNotFdPartyCountryCd').val() == "IN") {
        $('#sTrnsprtrDocNotFdPartyCountrySubDiv').hide();
        $('#ddlNotFdPartySubDivCode').selectpicker('refresh');
        $('#ddlNotFdPartySubDivCode').parent('div').show();
    }
    else {
        $('#sTrnsprtrDocNotFdPartyCountrySubDiv').show();
        $('#ddlNotFdPartySubDivCode').parent('div').hide();
    }
}

$(document).on('change', '#ddlNotFdPartySubDivCode', function () {
    if ($('#ddlNotFdPartySubDivCode').val() != "") {
        $('#sTrnsprtrDocNotFdPartyCountrySubDiv').val($(this).val());
    }
});