$(function () {
    $('#SupplyType').selectpicker();
    $('#SubSupplyType').selectpicker();
    $('#DocType').selectpicker();
    $('#TransactionType').selectpicker();
    $('#TransMode').selectpicker();
    $('#VehicleType').selectpicker();
    var id = $('.input-validation-error:not(.IsValid)').closest('.bs-stepper-pane').attr('id');
    if (id != undefined) {
        $('.bs-stepper-pane').removeClass('active');
        $('.step').removeClass('active');
        $('.input-validation-error:not(.IsValid)').closest('.bs-stepper-pane').addClass('active');
        $('.step[data-target="#' + id + '"]').closest('.bs-stepper-pane').addClass('active');
    }
    StepperSteps();
    if ($('#SubSupplyType option:selected').text() === "Others") {
        $(".otherRow").show();
        $(".otherRow").find('input').removeClass('IsValid');
    }
    else {
        $(".otherRow").hide();
        $(".otherRow").find('input').val('');
        $(".otherRow").find('input').addClass('IsValid');
    }
    if ($('#hdnEwbId').length > 0) {
        $('#EWB_ID').val($('#hdnEwbId').val());
    }
    var minDate = new Date();
    var n = -6;
    if (minDate.getMonth() < n)
        minDate.setFullYear(minDate.getFullYear() - 1);
    minDate.setMonth((minDate.getMonth() + n) % 12);
    $("#DocDate").datepicker({
        format: 'dd/mm/yyyy',
        endDate: new Date(),
        startDate: minDate
    });
    $("#TransDocDate").datepicker({
        format: 'dd/mm/yyyy',
        endDate: new Date(),
        startDate: minDate
    });
});

function initPane() {
    var target = $('.step.active').attr('data-target');
    if (target === "#billFrom") {
        initbillFrom();
        checkFromGSTIN();
    }
    else if (target == '#billTo') {
        initbillTo();
        checkToGSTIN();
    }
    else if (target == '#itemsDetails')
        initItemDetails();
    else if (target == '#itemsDetails')
        initItemDetails();
    console.log(target);
}

function changeSupply() {
    var html = "<option value>Select</option>";
    $.ajax({
        url: "/Ebill/GetSubSupplyTypeBySupply",
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

function changeSubSupply() {
    var html = "";
    if ($('#SubSupplyType option:selected').text() === "Others") {
        $(".otherRow").show();
        $(".otherRow").find('input').removeClass('IsValid');
    }
    else {
        $(".otherRow").hide();
        $(".otherRow").find('input').val('');
        $(".otherRow").find('input').addClass('IsValid');
    }
    if ($('#SubSupplyType').val() != "" && $('#SupplyType').val() != "")
        $.ajax({
            url: "/Ebill/GetDocTypeBySubSupply",
            data: { subsupplyTypeValue: $('#SubSupplyType').val(), SupplyType: $('#SupplyType').val() },
            type: "GET",
            success: function (res) {
                res.forEach(function (val, i) {
                    html += "<option value=\"" + val.Value + "\">" + val.Text + "</option>";
                });
                $('#DocType').html(html);
                $('#DocType').selectpicker('refresh');
            }
        });
}

$(document).on('change', '#SupplyType', function () {
    changeSupply();
});

$(document).on('change', '#SubSupplyType', function () {
    changeSubSupply();
});

$(document).on('blur', '#FromGSTIN', function () {
    checkFromGSTIN();
});

$(document).on('blur', '#ToGSTIN', function () {
    checkToGSTIN();
});

$(document).on('blur', "#FromPincode", function () {
    if ($(this).val() == "999999") {
        $("#sFromStateCode").val("99")
        $("#FromStateCode").val("99");
        return;
    }
    else if ($('#FromGSTIN').val() == "URP") {
        return;
    }
    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ PinCode: $("#FromPincode").val() }),
        url: '/Ebill/FindStateByPinCode',
        success: function (data) {
            if (data.message == "0") {
                alertify.error("This Pincode doesn't exists Plz confirm the correctness and continue");
                $("#sFromStateCode").val('');
                $("#FromStateCode").val('');
            }
            else {
                $("#sFromStateCode").val(data.message)
                $("#FromStateCode").val(data.message);
            }
        },
        error: function (result) {
        }
    });
});

$(document).on('blur', "#ToPincode", function () {
    if ($(this).val() == "999999") {
        $("#sToStateCode").val("99")
        $("#ToStateCode").val("99");
        return;
    }
    else if ($('#ToGSTIN').val() == "URP") {
        return;
    }
    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ PinCode: $("#ToPincode").val() }),
        url: '/Ebill/FindStateByPinCode',
        success: function (data) {
            if (data.message == "0") {
                alertify.error("This Pincode doesn't exists Plz confirm the correctness and continue");
                $("#sToStateCode").val('');
                $("#ToStateCode").val('');
            }
            else {
                $("#sToStateCode").val(data.message)
                $("#ToStateCode").val(data.message);
            }
        },
        error: function (result) {
        }
    });
});

function checkFromGSTIN() {
    var validator = $("#frmEbillCreate").validate();
    if ($("#FromGSTIN").valid()) {
        if ($("#FromGSTIN").val() !== "URP") {
            $('#ActFromStateCode').val($("#FromGSTIN").val().substring(0, 2));
            $('#sActFromStateCode').val($("#FromGSTIN").val().substring(0, 2));
            $('#sActFromStateCode').attr('disabled', 'disabled');
        }
        //else if ($('#SubSupplyType option:selected').text() !== "Import") {
        //    $('#ActFromStateCode').val('99');
        //    $('#sActFromStateCode').val('99');
        //    $('#sActFromStateCode').attr('disabled', 'disabled');
        //}
        else {
            $('#ActFromStateCode').val($("#hdnUserName").val().substring(0, 2));
            $('#sActFromStateCode').val($("#hdnUserName").val().substring(0, 2));
            $('#FromStateCode').val('99');
            $('#sFromStateCode').val('99');
            $('#sActFromStateCode').attr('disabled', 'disabled');
        }
    }
    else {
        $('#ActFromStateCode').val('');
        $('#sActFromStateCode').val('');
        $('#sActFromStateCode').removeAttr('disabled');
    }
    if ($('#SupplyType').val() === "1" && ($('#SubSupplyType option:selected').text() === "Supply" || $('#SubSupplyType option:selected').text() === "Job work Returns" || $('#SubSupplyType option:selected').text() === "Sales Return"
        || ($('#SubSupplyType option:selected').text() === "SKD/CKD/Lots" && ($('#DocType option:selected').text() == "Bill of Supply" || $('#DocType option:selected').text() == "Tax Invoice" || $('#DocType option:selected').text() == "Delivery Challan")))) {
        if ($('#FromGSTIN').val() === $('#hdnUserName').val()) {
            validator.showErrors({
                "FromGSTIN": "You cannot enter self GSTIN."
            });
            return false;
        }
    }
    else if ($("#FromGSTIN").val() === "URP")
        return true;
    fillFromGSTINDetails();
    return true;
}

function checkToGSTIN() {
    var validator = $("#frmEbillCreate").validate();
    if ($("#ToGSTIN").valid()) {
        if ($("#ToGSTIN").val() !== "URP") {
            $('#ActToStateCode').val($("#ToGSTIN").val().substring(0, 2));
            $('#sActToStateCode').val($("#ToGSTIN").val().substring(0, 2));
            $('#sActToStateCode').attr('disabled', 'disabled');
        }
        //else if ($('#SubSupplyType option:selected').text() !== "Export") {
        //    $('#ActToStateCode').val('99');
        //    $('#sActToStateCode').val('99');
        //    $('#sActToStateCode').attr('disabled', 'disabled');
        //}
        else {
            $('#ActToStateCode').val($("#hdnUserName").val().substring(0, 2));
            $('#sActToStateCode').val($("#hdnUserName").val().substring(0, 2));
            $('#ToStateCode').val('99');
            $('#sToStateCode').val('99');
            $('#sActToStateCode').attr('disabled', 'disabled');
        }
    }
    else {
        $('#ActToStateCode').val('');
        $('#sActToStateCode').val('');
        $('#sActToStateCode').removeAttr('disabled');
    }
    if ($('#SupplyType').val() === "2" && ($('#SubSupplyType option:selected').text() === "Supply" || $('#SubSupplyType option:selected').text() === "Jobwork" || $('#SubSupplyType option:selected').text() === "SKD/CKD/Lots")) {
        if ($('#ToGSTIN').val() === $('#hdnUserName').val()) {
            validator.showErrors({
                "ToGSTIN": "You cannot enter self GSTIN."
            });
            return false;
        }
    }
    else if ($("#ToGSTIN").val() === "URP")
        return true;
    fillToGSTINDetails();
    return true;
}

$(document).on('click', '#addRow', function () {
    var target = $('.step.active').attr('data-target');
    var data = $('#frmEbillCreate').serialize() + "&bIsAddNew=true";
    $.ajax({
        url: '/Ebill/ItemDetailsModifications',
        type: 'post',
        data: data,
        success: function (response) {
            $(target).html(response);
            var form = $('#frmEbillCreate')
                .removeData("validator") /* added by the raw jquery.validate plugin */
                .removeData("unobtrusiveValidation");  /* added by the jquery unobtrusive plugin*/
            $.validator.unobtrusive.parse(form);
            initItemDetails();
            calculateItemTax();
        }
    });
});

$(document).on('click', '.btnDelete', function () {
    var $this = $(this);
    if ($('.tbody').find('tr').length == 1) {
        alertify.error('You cannot delete last row');
        return;
    }
    alertify.confirm('Delete row', 'Are you sure you want to delete?', function () {
        $this.next('input[name*="bIsDeleted"]').val('true');
        var target = $('.step.active').attr('data-target');
        var data = $('#frmEbillCreate').serialize();
        $.ajax({
            url: '/Ebill/ItemDetailsModifications',
            type: 'post',
            data: data,
            success: function (response) {
                $(target).html(response);
                var form = $('#frmEbillCreate')
                    .removeData("validator") /* added by the raw jquery.validate plugin */
                    .removeData("unobtrusiveValidation");  /* added by the jquery unobtrusive plugin*/
                $.validator.unobtrusive.parse(form);
                initItemDetails();
                calculateItemTax();
            }
        });
    }, function () {
    });

});

function initbillFrom() {
    if ($('#SupplyType').val() === "1" && ($('#SubSupplyType option:selected').text() === "Exhibition or Fairs" || $('#SubSupplyType option:selected').text() === "For Own Use")) {
        $('#FromTrdName').val($('#hdnOrganisation').val());
        $('#FromGSTIN').val($('#hdnUserName').val());
        $('#FromGSTIN').attr('readonly', 'readonly');
        $('#FromAddress1').val($('#hdnAddress').val());
        $('#FromAddress2').val($('#hdnAddress2').val());
        $('#FromPlace').val($('#hdnPlace').val());
        $('#FromPincode').val($('#hdnPinCode').val());
        $('#ActFromStateCode').val($('#hdnState').val())
        $('#sActFromStateCode').attr('disabled', 'disabled');
        $('#sActFromStateCode').val($('#hdnState').val())
        $('#FromStateCode').val($('#hdnState').val());
        $('#sFromStateCode').val($('#hdnState').val());
    }
    else if ($('#SupplyType').val() === "1" && ($('#SubSupplyType option:selected').text() === "Import" ||
        ($('#SubSupplyType option:selected').text() === "SKD/CKD/Lots" && $('#DocType option:selected').text() === "Bill of Entry"))) {
        $('#FromGSTIN').val("URP");
        $('#FromGSTIN').attr('readonly', 'readonly');
        $('#ActFromStateCode').val('99');
        $('#sActFromStateCode').val('99');
        $('#sActFromStateCode').attr('disabled', 'disabled');
    }
    else if ($('#SupplyType').val() === "2") {
        $('#FromGSTIN').val($('#hdnUserName').val());
        $('#FromGSTIN').attr('readonly', 'readonly');
        $('#ActFromStateCode').val($('#hdnState').val())
        $('#sActFromStateCode').attr('disabled', 'disabled');
        $('#sActFromStateCode').val($('#hdnState').val())
    }
    else {
        $('#FromGSTIN').removeAttr('readonly');
        $('#sActFromStateCode').removeAttr('disabled');
        //$('#FromAddress1').val('');
        //$('#FromAddress2').val('');
        //$('#FromPlace').val('');
        //$('#FromPincode').val('');
        //$('#ActFromStateCode').val('')
        //$('#sActFromStateCode').val('')
        //$('#FromStateCode').val('');
        //$('#sFromStateCode').val('');
        //$('#FromTrdName').val('');
        //$('#FromGSTIN').val('');
    }
}

function initbillTo() {
    if ($('#SupplyType').val() === "2" && ($('#SubSupplyType option:selected').text() === "Exhibition or Fairs" || $('#SubSupplyType option:selected').text() === "For Own Use"
        || $('#SubSupplyType option:selected').text() === "Recipient Not Known" || $('#SubSupplyType option:selected').text() === "Line Sales")) {
        $('#ToTrdName').val($('#hdnOrganisation').val());
        $('#ToGSTIN').val($('#hdnUserName').val());
        $('#ToGSTIN').attr('readonly', 'readonly');
        $('#ToAddress1').val($('#hdnAddress').val());
        $('#ToAddress2').val($('#hdnAddress2').val());
        $('#ToPlace').val($('#hdnPlace').val());
        $('#ToPincode').val($('#hdnPinCode').val());
        $('#ActToStateCode').val($('#hdnState').val())
        $('#sActToStateCode').attr('disabled', 'disabled');
        $('#sActToStateCode').val($('#hdnState').val())
        $('#ToStateCode').val($('#hdnState').val());
        $('#sToStateCode').val($('#hdnState').val());
    }
    else if ($('#SupplyType').val() === "2" && $('#SubSupplyType option:selected').text() === "Export") {
        $('#ToGSTIN').val("URP");
        $('#ToGSTIN').attr('readonly', 'readonly');
        $('#ActToStateCode').val('99')
        $('#sActToStateCode').val('99')
        $('#sActToStateCode').attr('disabled', 'disabled');
    }

    else if ($('#SupplyType').val() === "1") {
        $('#ToGSTIN').val($('#hdnUserName').val());
        $('#ToGSTIN').attr('readonly', 'readonly');
        $('#ActToStateCode').val($('#hdnState').val())
        $('#sActToStateCode').attr('disabled', 'disabled');
        $('#sActToStateCode').val($('#hdnState').val())
    }
    else {
        $('#ToGSTIN').removeAttr('readonly');
        $('#sActToStateCode').removeAttr('disabled');
        //$('#ToTrdName').val('');
        //$('#ToGSTIN').val('');
        //$('#ToAddress1').val('');
        //$('#ToAddress2').val('');
        //$('#ToPlace').val('');
        //$('#ToPincode').val('');
        //$('#ActToStateCode').val('')
        //$('#sActToStateCode').val('')
        //$('#ToStateCode').val('');
        //$('#sToStateCode').val('');
    }
}

function initItemDetails() {
    ManageItemDetails();
    $('select[name*="UnitType"]').selectpicker('refresh');
    $('select[name*="CGSTRate"]').selectpicker('refresh');
    $('select[name*="IGSTRate"]').selectpicker('refresh');
    $('select[name*="CESSRate"]').selectpicker('refresh');
    $('select[name*="CessNonAdvolRate"]').selectpicker('refresh');
}

function checkTransporterDetails() {
    var mode = $('#TransMode option:selected').text();
    var vehicleNo = $('#VehicleNo').val();
    var transporterId = $('#TransporterId').val();
    var transDocNo = $('#TransDocNo').val();
    var TransDocDate = $('#TransDocDate').val();
    var validator = $("#frmEbillCreate").validate();
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

function ManageItemDetails() {
    if ($('#FromStateCode').val() != $('#ToStateCode').val()) {
        $('select[name*="CGSTRate"] option').removeAttr('selected');
        $('select[name*="CGSTRate"] option:first').attr('selected', 'selected');
        $('select[name*="CGSTRate"]').attr('disabled', 'disabled');
        $('select[name*="IGSTRate"]').removeAttr('disabled');
        $('select[name*="CGSTRate"]').selectpicker('refresh');
        $('select[name*="IGSTRate"]').selectpicker('refresh');
    }
    else {
        $('select[name*="IGSTRate"] option').removeAttr('selected');
        $('select[name*="IGSTRate"] option:first').attr('selected', 'selected');
        $('select[name*="IGSTRate"]').attr('disabled', 'disabled');
        $('select[name*="CGSTRate"]').removeAttr('disabled');
        $('select[name*="CGSTRate"]').selectpicker('refresh');
        $('select[name*="IGSTRate"]').selectpicker('refresh');
    }
    document.getElementById("TotalTaxableAmount").value = "";
    document.getElementById("TotalCGSTAmount").value = "";
    document.getElementById("TotalSGSTAmount").value = "";
    document.getElementById("TotalIGSTAmount").value = "";
    document.getElementById("TotalCessAmountNew").value = "";
    document.getElementById("TotalNonCessAmount").value = "";
    document.getElementById("TotalOtherAmount").value = "";
    document.getElementById("TotalTaxableAmount").value = "";
    document.getElementById("TotalInvAmount").value = "";
    calculateItemTax();
}

function calculateItemTax() {
    if ($("#ActFromStateCode").val() !== $("#ActToStateCode").val()) {
        $("#TotalCGSTAmount").val('');
        $("#TotalSGSTAmount").val('');
        $("#TotalTaxableAmount").val('');
        $("#TotalIGSTAmount").val('');
        $("#itemDataTable tbody tr").each(function (i, ele) {
            var TaxableAmount = $(ele).find("input[id*='TaxableAmount']").val();
            var CessNonAdvolRate = $(ele).find("select[id*='CessNonAdvolRate'] :selected").text();
            var IGSTRate = $(ele).find("select[id*='IGSTRate'] :selected").text();
            var CESSRate = $(ele).find("select[id*='CESSRate'] :selected").text();
            if (TaxableAmount != undefined && TaxableAmount != '' && !isNaN(TaxableAmount)) {
                if ($("#TotalTaxableAmount").val() != '') {
                    var tax = parseInt($("#TotalTaxableAmount").val()) + parseInt(TaxableAmount)
                    $("#TotalTaxableAmount").val(tax);

                    var cessAmt = (parseInt(TaxableAmount) * parseFloat(CESSRate)) / 100;
                    var TotSasAmount = parseFloat($("#TotalCessAmountNew").val()) + parseFloat(cessAmt);
                    $("#TotalCessAmountNew").val(TotSasAmount);

                    var sgstAmt = parseFloat($("#TotalNonCessAmount").val()) + parseFloat(CessNonAdvolRate);
                    $("#TotalNonCessAmount").val(sgstAmt);

                    var igstAmt = (parseInt(TaxableAmount) * parseFloat(IGSTRate)) / 100;
                    var TotigstAmt = parseFloat($("#TotalIGSTAmount").val()) + parseFloat(igstAmt);
                    $("#TotalIGSTAmount").val(TotigstAmt);

                    var TotalAmt = parseFloat(tax) + parseFloat(TotigstAmt) + parseFloat(TotSasAmount) + parseFloat(sgstAmt);
                    $("#TotalInvAmount").val(TotalAmt.toFixed(2));
                }
                else {
                    var tax1 = parseInt(TaxableAmount);
                    $("#TotalTaxableAmount").val(tax1);

                    var igstAmt1 = (parseFloat(tax1) * parseFloat(IGSTRate)) / 100;
                    $("#TotalIGSTAmount").val(igstAmt1);

                    var cessAmt1 = (parseFloat(tax1) * parseFloat(CESSRate)) / 100;
                    $("#TotalCessAmountNew").val(cessAmt1);

                    $("#TotalNonCessAmount").val(CessNonAdvolRate);

                    var TotalAmt1 = parseFloat(tax1) + parseFloat(igstAmt1) + parseFloat(cessAmt1) + parseFloat(CessNonAdvolRate);
                    $("#TotalInvAmount").val(TotalAmt1.toFixed(2));
                }
            }
        });
    }
    else {
        $("#TotalIGSTAmount").val('');
        $("#TotalTaxableAmount").val('');
        $("#TotalCGSTAmount").val('');
        $("#itemDataTable tbody tr").each(function (i, ele) {
            var TaxableAmount = $(ele).find("input[id*='TaxableAmount']").val();
            var CGSTRate = $(ele).find("select[id*='CGSTRate']").val();
            var CessNonAdvolRate = $(ele).find("select[id*='CessNonAdvolRate'] :selected").text();
            var CESSRate = $(ele).find("select[id*='CESSRate'] :selected").text();
            if (TaxableAmount != undefined && TaxableAmount != '' && !isNaN(TaxableAmount)) {
                if ($("#TotalTaxableAmount").val() != '') {

                    var tax = parseInt($("#TotalTaxableAmount").val()) + parseInt(TaxableAmount)
                    $("#TotalTaxableAmount").val(tax);


                    var cessAmt = (parseInt(TaxableAmount) * parseFloat(CESSRate)) / 100;
                    var TotSasAmount = parseFloat($("#TotalCessAmountNew").val()) + parseFloat(cessAmt);
                    $("#TotalCessAmountNew").val(TotSasAmount);

                    var sgstAmt = parseFloat($("#TotalNonCessAmount").val()) + parseFloat(CessNonAdvolRate);
                    $("#TotalNonCessAmount").val(sgstAmt);

                    var CGSTAmt = (parseInt(TaxableAmount) * parseFloat(CGSTRate / 2)) / 100;
                    var TotCGSTtAmt = parseFloat($("#TotalCGSTAmount").val()) + parseFloat(CGSTAmt);
                    $("#TotalCGSTAmount").val(TotCGSTtAmt);
                    $("#TotalSGSTAmount").val(TotCGSTtAmt);

                    var TotalAmt = parseFloat(tax) + parseFloat(TotCGSTtAmt) + parseFloat(TotCGSTtAmt) + parseFloat(TotSasAmount) + parseFloat(sgstAmt);
                    $("#TotalInvAmount").val(TotalAmt.toFixed(2));
                }
                else {
                    var tax1 = parseInt(TaxableAmount);
                    $("#TotalTaxableAmount").val(tax1);

                    var cgstAmt1 = (parseFloat(tax1) * parseFloat(CGSTRate / 2)) / 100;
                    $("#TotalCGSTAmount").val(cgstAmt1);
                    $("#TotalSGSTAmount").val(cgstAmt1);

                    var cessAmt1 = (parseFloat(tax1) * parseFloat(CESSRate)) / 100;
                    $("#TotalCessAmountNew").val(cessAmt1);

                    $("#TotalNonCessAmount").val(CessNonAdvolRate);

                    var TotalAmt1 = parseFloat(tax1) + parseFloat(cgstAmt1) + parseFloat(cgstAmt1) + parseFloat(cessAmt1) + parseFloat(CessNonAdvolRate);
                    $("#TotalInvAmount").val(TotalAmt1.toFixed(2));
                }
            }
        });
    }
}

$(document).on('blur', "input[id*='Quantity'],input[id*='TaxableAmount']", function () {
    calculateItemTax();
});

$(document).on('change', "select[id*='CessNonAdvolRate'],select[id*='IGSTRate'],select[id*='CESSRate'],select[id*='CGSTRate']", function () {
    calculateItemTax();
});

function IsFinalSubmit() {
    if (checkTransporterDetails()) {
        if ($('#frmEbillCreate').valid()) {
            alertify.confirm('Are you Sure?', 'You won\'t be able to revert this?', function () {
                $('#IsFinal').val(true);
                $('#frmEbillCreate').submit();
            }, function () {
                $('#IsFinal').val(false);
            });
        }
    }
    else {
        return false;
    }
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

function fillToGSTINDetails() {
    $.ajax({
        url: "/Ebill/GetGSTINDetails",
        type: "GET",
        data: { GstinNo: $("#ToGSTIN").val() },
        success: function (data) {
            if (data.isSuccess) {
                var gstinDetails = JSON.parse(data.message);
                var stateCode = gstinDetails.stateCode.length == 1 ? "0" + gstinDetails.stateCode : gstinDetails.stateCode;
                $('#ActToStateCode').val(stateCode);
                $('#sActToStateCode').val(stateCode);
                $('#ToStateCode').val(stateCode);
                $('#sToStateCode').val(stateCode);
                $('#ToTrdName').val(gstinDetails.tradeName);
                $('#ToAddress1').val(gstinDetails.address1);
                $('#ToAddress2').val(gstinDetails.address2);
                $('#ToPincode').val(gstinDetails.pinCode);
            }
        }
    });

}

function fillFromGSTINDetails() {
    $.ajax({
        url: "/Ebill/GetGSTINDetails",
        type: "GET",
        data: { GstinNo: $("#FromGSTIN").val() },
        success: function (data) {
            if (data.isSuccess) {
                var gstinDetails = JSON.parse(data.message);
                var stateCode = gstinDetails.stateCode.length == 1 ? "0" + gstinDetails.stateCode : gstinDetails.stateCode;
                $('#ActFromStateCode').val(stateCode);
                $('#sActFromStateCode').val(stateCode);
                $('#FromStateCode').val(stateCode);
                $('#sFromStateCode').val(stateCode);
                $('#FromTrdName').val(gstinDetails.tradeName);
                $('#FromAddress1').val(gstinDetails.address1);
                $('#FromAddress2').val(gstinDetails.address2);
                $('#FromPincode').val(gstinDetails.pinCode);
            }
        }
    });

}

$(document).on('blur', 'input[name*="HsnCode"]', function () {
    var $this = $(this);
    if ($this.valid()) {
        $.ajax({
            url: "/Ebill/GetHsinDetails",
            type: "GET",
            data: { HSNCode: $this.val() },
            success: function (data) {
                if (data.isSuccess) {
                    var hsnDetails = JSON.parse(data.message);
                    $this.parent('td').prev('td').find('input[name*="ProductDesc"]').val(hsnDetails.hsnDesc);
                }
                else {
                    $this.val('');
                    alertify.error(data.message);
                }
            },
        });
    }
});


