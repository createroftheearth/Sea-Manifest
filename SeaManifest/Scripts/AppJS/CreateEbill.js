
﻿var OUTWARDSupply = [
    { "Value": 1, "Text": "Tax Invoice", "Selected": true },
    { "Value": 2, "Text": "Bill of Supply", "Selected": false }];

var InwardSupply = [
    { "Value": 1, "Text": "Tax Invoice", "Selected": true },
    { "Value": 2, "Text": "Bill of Supply", "Selected": false }];

var OUTWARDSExport = [
    { "Value": 1, "Text": "Tax Invoice", "Selected": false },
    { "Value": 2, "Text": "Bill of Supply", "Selected": true }];

var InwardImport = [
    { "Value": 3, "Text": "Bill of Entry", "Selected": true }];

var InwardSKD = [
    { "Value": 1, "Text": "Tax Invoice", "Selected": false },
    { "Value": 2, "Text": "Bill of Supply", "Selected": false },
    { "Value": 3, "Text": "Bill of Entry", "Selected": true },
    { "Value": 4, "Text": "Delivery Challan", "Selected": false }];
var InwardJobWork = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true }];
var OutwardJobWork = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true }];

var OutwardSKD = [
    { "Value": 1, "Text": "Tax Invoice", "Selected": false },
    { "Value": 2, "Text": "Bill of Supply", "Selected": false },
    { "Value": 4, "Text": "Delivery Challan", "Selected": true }];

var OutWardrecipientUnknown = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true },
    { "Value": 6, "Text": "Others", "Selected": false }];

var OutWardForOwnUse = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true },
    { "Value": 6, "Text": "Others", "Selected": false }];

var OutwardExhibitionForFairs = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true }];

var OutwardLineSales = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true }];

var Others = [
    { "Value": 4, "Text": "Delivery Challan", "Selected": true },
    { "Value": 6, "Text": "Others", "Selected": false }];

//var table;
$(document).ready(function () {
    //table = $('#itemDataTable').removeAttr('width').DataTable({
    //    "bPaginate": false,
    //    "paging": false,
    //    "bFilter": false, //hide Search bar
    //    "bInfo": false,
    //    "ordering": false,
    //    "autoWidth": false,
    //    "scrollX": true,
    //    destroy: true,
    //    columnDefs: [
    //        { width: 600, targets: 1 }
    //    ],
    //});



    $("input[name='TransMode']").change(function () {
        var TMode = $("input[name='TransMode']:checked").val();
        if (TMode == "2") {
            $("#TransporterName").val('Rail');
            $("#VehicleType").attr('disabled', true);
            $("#VehicleNo").attr('disabled', true);
            $("#lblTransDocDate").text('RR No & Date');
        }
        else if (TMode == "3") {
            $("#TransporterName").val('Air');
            $("#VehicleType").attr('disabled', true);
            $("#VehicleNo").attr('disabled', true);
            $("#lblTransDocDate").text('Airway Bill No & Date');
        }
        else if (TMode == "4") {
            $("#TransporterName").val('Ship');
            $("#VehicleType").attr('disabled', true);
            $("#VehicleNo").attr('disabled', true);
            $("#lblTransDocDate").text('Bill of lading No & Date');
        }
        else {
            $("#TransporterName").val('Ship');
            $("#VehicleType").attr('disabled', false);
            $("#VehicleNo").attr('disabled', false);
            $("#lblTransDocDate").text('Transporter Doc. No. & Date');
        }
    });

    changeDocumentTypeValues();

    $("#ProductName").change(function () {
        alert($('#ActFromStateCode option:selected').index());
        if ($('#ActFromStateCode option:selected').index() == "0") {
            alert("State for FROM/TO is missing. Please select");
            $("#ProductName").val('');
            $("#ProductName").focus();
        }
        else if ($('#ActToStateCode option:selected').index() == "0") {
            alert("State for FROM/TO is missing. Please select");
            $("#ProductName").val('');
            $("#ProductName").focus();
        }
    });
    $("#HsnCode").change(function () {
        if ($('#ActFromStateCode option:selected').index() == "0") {
            alert("State for FROM/TO is missing. Please select");
            $("#HsnCode").val('');
            $("#HsnCode").focus();
        }
        else if ($('#ActToStateCode option:selected').index() == "0") {
            alert("State for FROM/TO is missing. Please select");
            $("#HsnCode").val('');
            $("#HsnCode").focus();
        }
    });
    $("#TaxableAmount").change(function () {
        if ($('#ActFromStateCode option:selected').index() == "0") {
            alert("State for FROM/TO is missing. Please select");
            $("#TaxableAmount").val('');
        }
        else if ($('#ActToStateCode option:selected').index() == "0") {
            alert("State for FROM/TO is missing. Please select");
            $("#TaxableAmount").val('');
        }
        else {
            AmountCalculation();
        }
    });
    $("#asset_IGSTRate").change(function () {
        if ($('#asset_HsnCode').val() == '') {
            alert("Please enter HSN Code.");
            $('#asset_IGSTRate option:selected').index() = 0;
        }
        else {
            AmountCalculation();
        }
    });
    $("#asset_CESSRate").change(function () {
        if ($('#asset_HsnCode').val() == '') {
            alert("Please enter HSN Code.");
            $('#asset_CESSRate option:selected').index() = 0;
        }
        else {
            AmountCalculation();
        }
    });
    $("#asset_CGSTRate").change(function () {

        if ($('#asset_HsnCode').val() == '') {
            alert("Please enter HSN Code.");
            $('#asset_SGSTRate option:selected').index() = 0;
        }
        else {
            AmountCalculation();
        }
    });
    $("#asset_SGSTRate").change(function () {
        AmountCalculation();
    });
    $("#Quantity").change(function () {
        AmountCalculation();
    });
    $("#TaxableAmount").change(function () {
        AmountCalculation();
    });
    function CalculateCGSTIgst() {
        alert(67);
        var TotaltaxAmount = 0;
        var CGSTAmount = 0;
        var SGSTAmount = 0;
        var igstAmount = 0; var CessAdoveAmount = 0; var CessNonAdoveAmount = 0; var OtherAmount = 0;
        if ($("#FromStateCode").val() == $("#FromStateCode").val()) {

            $("#itemDataTable tr").each(function () {
                var HsnCode = $(this).find("input[id^='HsnCode']").val();
                var ProductName = $(this).find("input[id^='ProductName']").val();
                var ProductDesc = $(this).find("input[id^='ProductDesc']").val();
                var Quantity = $(this).find("input[id^='Quantity']").val();
                var QtyUnit = $(this).find("input[id^='QtyUnit']").val();
                var TaxableAmount = $(this).find("input[id^='TaxableAmount']").val();
                var CGSTRate = $(this).find("select[id^='asset_CGSTRate']").val();
                var SGSTRate = $(this).find("select[id^='asset_SGSTRate']").val();
                var IGSTRate = $(this).find("select[id^='asset_IGSTRate'] :selected").text();
                var CESSRate = $(this).find("select[id^='asset_CESSRate']").val();

                if (Quantity != undefined && QtyUnit != undefined) {
                    TotaltaxAmount = parseInt(TotaltaxAmount) + (parseInt(Quantity) * parseInt(QtyUnit));
                }
                if (TotaltaxAmount != undefined) {
                    //alert(igstAmount);
                    //alert(TotaltaxAmount);
                    alert(igstAmount);
                    igstAmount = ((parseInt(TotaltaxAmount) * parseInt(IGSTRate)) / 100);
                }
                //alert(TotaltaxAmount);
                //alert(igstAmount); CGST Amount
            });
            $("#TotalTaxableAmount").val(TotaltaxAmount);
            $("#TotalIGSTAmount ").val(igstAmount);
        }
    }
    $("#FromPincode").change(function () {
        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ PinCode: $("#FromPincode").val() }),
            url: "/Ebill/FindStateByPinCode",
            success: function (data) {
                if (data.message == "0") {
                    alertify.error("This Pincode doesn't exists Plz confirm the correctness and continue");
                    $("#FromStateCode").prop("disabled", false);
                }
                else {
                    $("#FromStateCode").val(data.message);
                    $("#FromStateCode").prop("disabled", true);
                }
            },
            error: function (result) {
            }
        });
    });
    $("#ToPincode").change(function () {
        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ PinCode: $("#ToPincode").val() }),
            url: "/Ebill/FindStateByPinCode",
            success: function (data) {

                if (data.message == "0") {
                    alertify.error("This Pincode doesn't exists Plz confirm the correctness and continue");
                    $("#ToStateCode").prop("disabled", false);
                }
                else {
                    $("#ToStateCode").val(data.message);
                    $("#ToStateCode").prop("disabled", true);
                }
            },
            error: function (result) {
            }
        });
    });


    var supType = $("input[name='SupplyTypeEnum']:checked").val();
    var SubsupType = $("input[name='SubSupplyType']:checked").val();
    var TMode = $("input[name='TransMode']:checked").val();
    var VType = $("input[name='VehicleType']:checked").val();
    if (supType != '' && supType != undefined) {
        $('input[name="SupplyTypeEnum"][value=' + supType + ']').attr('checked', true);
    }
    else {
        $('input[name="SupplyTypeEnum"][value="1"]').attr('checked', true);
    }
    if (SubsupType != '' && SubsupType != undefined) {
        $('input[name="SubSupplyType"][value=' + SubsupType + ']').attr('checked', true);
        if (SubsupType == "9" || SubsupType == "17") {
            $("#OtherSubSupplyType").show();
        }
    }
    else {
        $('input[name="SubSupplyType"][value="1"]').attr('checked', true);
    }

    if (TMode != '' && TMode != undefined) {
        $('input[name="TransMode"][value=' + TMode + ']').attr('checked', true);
    }
    else {
        $('input[name="TransMode"][value="1"]').attr('checked', true);
    }
    if (VType != '' && VType != undefined) {
        $('input[name="VehicleType"][value=' + VType + ']').attr('checked', true);
    }
    else {
        $('input[name="VehicleType"][value="1"]').attr('checked', true);
    }

    //$('input[name="SubSupplyType"][value="1"]').attr('checked', true);
    $("#ToGSTIN").attr("disabled", "disabled");
    $("#ActToStateCode").attr("disabled", "disabled");
    $("#FromGSTIN").removeAttr("disabled");
    $("#ActFromStateCode").removeAttr("disabled");



    $(this).find("input[id^='HsnCode']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='Quantity']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='QtyUnit']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='TaxableAmount']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='CGSTRate']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='SGSTRate']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='IGSTRate']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(this).find("input[id^='CESSRate']").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
});
        //$('#back').on('click', function (e) {
        //    e.preventDefault();
        //    window.history.back();
        //});
$(document).ready(function () {
    //alert("hii");
    var table = $('#itemDataTable').removeAttr('width').DataTable({
        "bPaginate": false,
        "paging": false,
        "bFilter": false, //hide Search bar
        "bInfo": false,
        "ordering": false,
        "autoWidth": false,
        "scrollX": true,
        columnDefs: [
            { width: 600, targets: 1 }
        ],
    });


    $('#itemDataTable tbody').on('click', '#button', function () {

        var row = $(this).parents('tr')[0];
        var mydata = (table.row(row).data());
        //  alert(mydata);
        var con = confirm("Are you sure you want to delete this Item?")
        if (con) {
            table.row($(this).parents('tr')).remove().draw();
        }
        else {
            // Nothing to do here
        }
    });

});
$("body").on("change", "input[name=SubSupplyType]:radio", function () {
    var supType = $("input[name='SupplyTypeEnum']:checked").val();
    var _SubsupplyType = $('input[name=SubSupplyType]:checked').val();
    if (_SubsupplyType == "9" || _SubsupplyType == "17") {
        $("#OtherSubSupplyType").show();
    }
    else {
        $("#OtherSubSupplyType").hide();
    }

    if (supType == 2) {

        $("#ToAddress1").val('');
        $("#ToStateCode").val('');
        $("#ToGSTIN").prop("disabled", false);
        $("#ActToStateCode").prop("disabled", false);
        $("#ToGSTIN").val('');
        $("#ToStateCode").prop("disabled", false);
        $("#ActToStateCode").val('');
        $("#ToTrdName").val('');

        if (_SubsupplyType == "1") {
            $("#DocType").val('INV');
            $("#DocType").prop("disabled", false);
            //$('#DocType').find('option:contains(BOE)').hide();
            //$("#DocType").find('option:contains(Bill of Entry)').hide();
        }
        else if (_SubsupplyType == "2") {
            $("#DocType").val('BIL');
            $("#DocType").prop("disabled", false);
        }
        else if (_SubsupplyType == "5") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", true);
            $("#ToTrdName").val($("#hdnOrganisation").val());
            $("#ToAddress1").val($("#hdnAddress").val());
            $("#ToStateCode").val($("#hdnNewState").val());
            $("#ToStateCode").prop("disabled", true);
            var username = $("#hdnUserName").val();
            var state = $("#hdnState").val();
            $("#ToGSTIN").val(username);
            $("#ActToStateCode").val(state);
            $("#ToGSTIN").prop("disabled", true);
            $("#ActToStateCode").prop("disabled", true);
        }
        else if (_SubsupplyType == "6" || _SubsupplyType == "7") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", true);
            $("#ToTrdName").val($("#hdnOrganisation").val());
            $("#ToAddress1").val($("#hdnAddress").val());
            $("#ToStateCode").val($("#hdnNewState").val());
            $("#ToStateCode").prop("disabled", true);

            var username = $("#hdnUserName").val();
            var state = $("#hdnState").val();
            $("#ToGSTIN").val(username);
            $("#ActToStateCode").val(state);
            $("#ToGSTIN").prop("disabled", true);
            $("#ActToStateCode").prop("disabled", true);
        }
        else if (_SubsupplyType == "3" || _SubsupplyType == "4" || _SubsupplyType == "6") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", true);
        }
        else if (_SubsupplyType == "7" || _SubsupplyType == "8") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", false);
        }
        else if (_SubsupplyType == "9") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", false);
        }
    }
    else {

        $("#FromAddress1").val('');
        $("#FromStateCode").val('');
        $("#FromGSTIN").prop("disabled", false);
        $("#ActFromStateCode").prop("disabled", false);
        $("#FromGSTIN").val('');
        $("#FromStateCode").prop("disabled", false);
        $("#ActFromStateCode").val('');
        $("#FromTrdName").val('');


        if (_SubsupplyType == "10") {
            $("#DocType").val('INV');
            $("#DocType").prop("disabled", false);
        }
        else if (_SubsupplyType == "11") {
            $("#DocType").val('BOE');
            $("#DocType").prop("disabled", true);
        }
        else if (_SubsupplyType == "12") {
            $("#DocType").val('BOE');
            $("#DocType").prop("disabled", false);
        }
        else if (_SubsupplyType == "13" || _SubsupplyType == "14") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", true);
        }
        else if (_SubsupplyType == "16" || _SubsupplyType == "15") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", true);


            $("#FromTrdName").val($("#hdnOrganisation").val());
            $("#FromAddress1").val($("#hdnAddress").val());
            $("#FromStateCode").val($("#hdnNewState").val());
            $("#FromStateCode").prop("disabled", true);

            var username = $("#hdnUserName").val();
            var state = $("#hdnState").val();
            $("#FromGSTIN").val(username);
            $("#ActFromStateCode").val(state);
            $("#FromGSTIN").prop("disabled", true);
            $("#ActFromStateCode").prop("disabled", true);

        }
        else if (_SubsupplyType == "9") {
            $("#DocType").val('CHL');
            $("#DocType").prop("disabled", false);
        }
    }

});

$("input[name='SupplyTypeEnum']").change(function () {
    var _supplyType = $("input[name='SupplyTypeEnum']:checked").val();
    if ($("input[name='SupplyTypeEnum']:checked").val() == 1) {
        var username = $("#hdnUserName").val();
        var state = $("#hdnState").val();
        $("#ToGSTIN").val(username);
        $("#ActToStateCode").val(state);
        $("#FromGSTIN").val('');
        $("#ActFromStateCode").prop('selectedIndex', 0);

        $("#ToGSTIN").attr("disabled", "disabled");
        $("#ActToStateCode").attr("disabled", "disabled");
        $("#FromGSTIN").removeAttr("disabled");
        $("#ActFromStateCode").removeAttr("disabled");
    }
    else {
        var username = $("#hdnUserName").val();
        var state = $("#hdnState").val();
        $("#FromGSTIN").val(username);
        $("#ActFromStateCode").val(state);
        $("#ToGSTIN").val('');
        $("#ActToStateCode").prop('selectedIndex', 0);

        $("#FromGSTIN").attr("disabled", "disabled");
        $("#ActFromStateCode").attr("disabled", "disabled");
        $("#ToGSTIN").removeAttr("disabled");
        $("#ActToStateCode").removeAttr("disabled");

    }

    // var _SupplyType = $("input[name='SupplyTypeEnum']").val();
    //alert(_SupplyType);
    var ObjTimeSheetModel = { supplyType: _supplyType };
    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(ObjTimeSheetModel),
        url: "/Ebill/SubSupplyType",
        success: function (data) {
            if (data != null) {
                var i = 0;
                $('#supplytypeDiv').empty();
                $.each(data, function () {
                    var item = " <label class='radio-inline control-label'><input id='SubSupplyType' name='SubSupplyType' type='radio' value='" + this['SubSupplyTypeID'] + "'>" + this['SubSupplyTypeName'] + '</label>'
                    $('#supplytypeDiv').append(item);
                    i++;
                });
                $("#OtherSubSupplyType").hide();
            }
            else {
                //alertify.error("Please try again later.");
            }
        },
        error: function (result) {
            // var respText = ajaxRequest.responseText;
            //alert(result.responseText);
        }
    });
});

$('#addRow').on('click', function () {
    addItems();
});

$('#SaveBill').on('click', function () {

    var _SubSupplyType = $('input[name=SubSupplyType]:checked').val();
    var isChecked = $('#SupplyTypeEnum').is(':checked');
    var _SupplyTypeEnum =parseInt($("input[name='SupplyTypeEnum']:checked").val());
    if (_SupplyTypeEnum <= 0) {
        alertify.error("Select Transaction Type.");
        $("#SupplyType").focus();
        return false;
    }

    var _DocNo = $("#DocNo").val();
    var _DocType = $("#DocType").val();
    if (_DocNo === '' || _DocNo === null) {
        alertify.error("Please enter Doc. No.");
        $("#DocNo").focus();
        return false;
    }

    var _SupplyType = $('input[name=SupplyTypeEnum]:checked').val();
    var _DocDate = $("#DocDate").val();
    if (_DocDate === '' || _DocDate === null) {
        alertify.error("Please enter Doc. date");
        $("#DocDate").focus();
        return false;
    }


    var _FromTrdName = $("#FromTrdName").val();
    var _FromGSTIN = $("#FromGSTIN").val();
    if (_FromGSTIN === '' || _FromGSTIN === null) {
        alertify.error("Please enter GSTIN");
        $("#FromGSTIN").focus();
        return false;
    }
    var _ActFromStateCode = $("#fromStateId").val();
    // alert(_ActFromStateCode);
    if (_ActFromStateCode == '') {
        alertify.error("Please enter state name");
        $("#fromStateId").focus();
        return false;
    }
    //alert(_ActFromStateCode);
    var _FromAddress1 = $("#FromAddress1").val();
    var _FromAddress2 = $("#FromAddress2").val();
    var _FromPlace = $("#FromPlace").val();
    var _FromPincode = $("#FromPincode").val();
    if (_FromPincode === '' || _FromPincode === null) {
        alertify.error("Please enter Pincode");
        $("#FromPincode").focus();
        return false;
    }
    var _FromStateCode = $("#FromStateCode").val();
    if (_FromStateCode === '' || _FromStateCode === null) {
        alertify.error("Please select State");
        $("#FromStateCode").focus();
        return false;
    }

    var _ToTrdName = $("#ToTrdName").val();
    var _ToGSTIN = $("#ToGSTIN").val();
    if (_ToGSTIN === '' || _ToGSTIN === null) {
        alertify.error("Please enter GSTIN");
        $("#ToGSTIN").focus();
        return false;
    }
    var _ActToStateCode = $("#ActToStateCode").val();
    if (_ActToStateCode === '' || _ActToStateCode === null) {
        alertify.error("Please select State");
        $("#ActToStateCode").focus();
        return false;
    }
    var _ToAddress1 = $("#ToAddress1").val();
    var _ToAddress2 = $("#ToAddress2").val();
    var _ToPlace = $("#ToPlace").val();
    var _ToPincode = $("#ToPincode").val();
    if (_ToPincode === '' || _ToPincode === null) {
        alertify.error("Please enter Pincode");
        $("#ToPincode").focus();
        return false;
    }
    var _ToStateCode = $("#ToStateCode").val();
    var _TransporterName = $("#TransporterName").val();
    var _TransporterId = $("#TransporterId").val();
    var _TransDistance = $("#TransDistance").val();
    if (_TransDistance === '' || _TransDistance === null) {
        alertify.error("Please enter distance");
        $("#TransDistance").focus();
        return false;
    }

    //var _TransModeEnum = $('input[name=TransMode]:checked').val();// $("#TransMode").val();
    //var _VehicleType = $('input[name=VehicleType]:checked').val();
    //var _TransDocNo = $("#TransDocNo").val();
    //var _TransDocDate = $("#TransDocDate").val();
    //var _VehicleNo = $("#VehicleNo").val();
    //var _ewbid = $("#EWB_ID").val();

    ////var dt = $('#itemDataTable').DataTable();
    //var _other = $("#OtherSubSupplyType").val();

    //var quotations = [];
    ////$("#itemDataTable tr").each(function () {
    ////    var items = {};
    ////    //get their values and push into storage
    ////    var HsnCode = $(this).find("input[id^='HsnCode']").val();
    ////    var ProductName = $(this).find("input[id^='ProductName']").val();
    ////    var ProductDesc = $(this).find("input[id^='ProductDesc']").val();
    ////    var Quantity = $(this).find("input[id^='Quantity']").val();
    ////    var QtyUnit = $(this).find("input[id^='QtyUnit']").val();
    ////    var TaxableAmount = $(this).find("input[id^='TaxableAmount']").val();
    ////    var CGSTRate = $(this).find("select[id^='asset_CGSTRate']").val();
    ////    var SGSTRate = $(this).find("select[id^='asset_SGSTRate']").val();
    ////    var IGSTRate = $(this).find("select[id^='asset_IGSTRate']").val();
    ////    var CESSRate = $(this).find("select[id^='asset_CESSRate']").val();
    ////    if (ProductName != null) {
    ////        items.HsnCode = HsnCode;
    ////        items.ProductName = ProductName;
    ////        items.ProductDesc = ProductDesc;
    ////        items.Quantity = Quantity;
    ////        items.QtyUnit = QtyUnit;
    ////        items.TaxableAmount = TaxableAmount;
    ////        items.CGSTRate = CGSTRate;
    ////        items.SGSTRate = SGSTRate;
    ////        items.IGSTRate = IGSTRate;
    ////        items.CESSRate = CESSRate;
    ////        quotations.push(items);
    ////        //alert(pName);
    ////        //alert($(this).find("input[id^='ProductDesc']").val());
    ////    }

    ////});

    ////alert(_ewbid);
    //if (_ewbid != null && _ewbid != '' && _ewbid > 0) {
    //    var ObjTimeSheetModel = {
    //        SupplyType: _SupplyType, DocDate: _DocDate, SubSupplyType: _SubSupplyType, DocNo: _DocNo, DocType: _DocType,
    //        FromTrdName: _FromTrdName, FromGSTIN: _FromGSTIN, ActFromStateCode: _ActFromStateCode, FromAddress1: _FromAddress1,
    //        FromAddress2: _FromAddress2, FromPlace: _FromPlace, FromPincode: _FromPincode, FromStateCode: _FromStateCode,
    //        ToTrdName: _ToTrdName, ToGSTIN: _ToGSTIN, ActToStateCode: _ActToStateCode,
    //        ToAddress1: _ToAddress1, ToAddress2: _ToAddress2, ToPlace: _ToPlace, ToPincode: _ToPincode, ToStateCode: _ToStateCode,
    //        TransporterName: _TransporterName, TransporterId: _TransporterId, TransDistance: _TransDistance,
    //        TransMode: _TransModeEnum, VehicleType: _VehicleType, TransDocNo: _TransDocNo, TransDocDate: _TransDocDate, VehicleNo: _VehicleNo,
    //        EWB_TRN_EWBILL_ITEM: quotations, EWB_ID: _ewbid, OtherSubSupplyType: _other
    //    }

    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: $('#form_User').serialize(),// JSON.stringify({ DocDate: userName }),
        url: "http://localhost:50048/Ebill/Create",
        success: function (data) {
            if (data != null) {
                if (data.ResponseCode === 200) {
                    alertify.success("E-Way bill updated successfully.");
                    //window.location.href = '@Url.Action("Index", "EBill")';
                }
                else {
                    alertify.error(data.ResponseCode);
                }
            }
            else {
                alertify.error("Please try again later.");
            }
        },
        error: function (result) {
        }
    })
    //}
    //else {
    //    var ObjTimeSheetModel = {
    //        SupplyType: _SupplyType, DocDate: _DocDate, SubSupplyType: _SubSupplyType, DocNo: _DocNo, DocType: _DocType,
    //        FromTrdName: _FromTrdName, FromGSTIN: _FromGSTIN, ActFromStateCode: _ActFromStateCode, FromAddress1: _FromAddress1,
    //        FromAddress2: _FromAddress2, FromPlace: _FromPlace, FromPincode: _FromPincode, FromStateCode: _FromStateCode,
    //        ToTrdName: _ToTrdName, ToGSTIN: _ToGSTIN, ActToStateCode: _ActToStateCode,
    //        ToAddress1: _ToAddress1, ToAddress2: _ToAddress2, ToPlace: _ToPlace, ToPincode: _ToPincode, ToStateCode: _ToStateCode,
    //        TransporterName: _TransporterName, TransporterId: _TransporterId, TransDistance: _TransDistance,
    //        TransMode: _TransModeEnum, VehicleType: _VehicleType, TransDocNo: _TransDocNo, TransDocDate: _TransDocDate, VehicleNo: _VehicleNo,
    //        EWB_TRN_EWBILL_ITEM: quotations, OtherSubSupplyType: _other
    //    }

    //    $.ajax({
    //        dataType: 'json',
    //        type: 'Post',
    //        contentType: 'application/json; charset=utf-8',
    //        data: JSON.stringify(ObjTimeSheetModel),// JSON.stringify({ DocDate: userName }),
    //        url: "/Ebill/Create",
    //        success: function (data) {
    //            if (data != null) {
    //                if (data.ResponseCode === 200) {
    //                    alertify.success("E-Way bill created successfully.");
    //                    //window.location.href = '@Url.Action("Index", "EBill")';
    //                }
    //                else {
    //                    alertify.error(data.ResponseCode);
    //                }
    //            }
    //            else {
    //                alertify.error("Please try again later.");
    //            }
    //        },
    //        error: function (result) {
    //        }
    //    })
    //}

    //var ObjTimeSheetModelNew = {
    //    SupplyType: _SupplyType, DocDate: _DocDate, SubSupplyType: _SubSupplyType, DocNo: _DocNo, DocType: _DocType,
    //    FromTrdName: _FromTrdName, FromGSTIN: _FromGSTIN, ActFromStateCode: _ActFromStateCode, FromAddress1: _FromAddress1,
    //    FromAddress2: _FromAddress2, FromPlace: _FromPlace, FromPincode: _FromPincode, FromStateCode: _FromStateCode,
    //    ToTrdName: _ToTrdName, ToGSTIN: _ToGSTIN, ActToStateCode: _ActToStateCode,
    //    ToAddress1: _ToAddress1, ToAddress2: _ToAddress2, ToPlace: _ToPlace, ToPincode: _ToPincode, ToStateCode: _ToStateCode,
    //    TransporterName: _TransporterName, TransporterId: _TransporterId, TransDistance: _TransDistance,
    //    TransMode: _TransModeEnum, VehicleType: _VehicleType, TransDocNo: _TransDocNo, TransDocDate: _TransDocDate, VehicleNo: _VehicleNo
    //};


    //@*$.ajax({
    //       dataType: 'json',
    //       type: 'Post',
    //       contentType: 'application/json; charset=utf-8',
    //       data: JSON.stringify(ObjTimeSheetModelNew),// JSON.stringify({ DocDate: userName }),
    //       url: "/Ebill/ValidateEwayBill",
    //       success: function (data) {
    //           debugger;
    //           if (data != null) {
    //               if (data.ResponseCode === 200) {
    //                   alertify.success("E-Way bill successfully created..");
    //                   //window.location.href = '@Url.Action("Index", "EBill")';
    //               }
    //               else {
    //                   alertify.error(data.message);
    //               }
    //           }
    //           else {
    //               alertify.error("Please try again later.");
    //           }
    //       },
    //       error: function (result) {
    //           // var respText = ajaxRequest.responseText;
    //           //alert(result.responseText);
    //       }
    //       //error: function (ajaxRequest, strError) {
    //       //    var respText = ajaxRequest.responseText;
    //       //    //alert(strError);
    //       //}
    //   });*@


});

$(document).on('change', '#SubSupplyType', function () {
    changeDocumentTypeValues();
});

function changeDocumentTypeValues() {
    var data;
    var SubSupplyType = $('#SubSupplyType:checked').parent('label').text().trim();
    var TranType = $('#SupplyTypeEnum:checked').parent('label').text().trim();
    if (TranType == "Inward") {
        if (SubSupplyType == "Supply")
            data = InwardSupply;
        else if (SubSupplyType == "Import")
            data = InwardImport;
        else if (SubSupplyType == "SKD/CKD/Lots")
            data = InwardSKD;
        else if (SubSupplyType == "Job work Returns")
            data = InwardJobWork;
        else if (SubSupplyType == "Sales Return")
            data = InwardJobWork;
        else if (SubSupplyType == "Exhibition or Fairs")
            data = InwardJobWork;
        else if (SubSupplyType == "For Own Use")
            data = InwardJobWork;
        else {
            data = Others;
            $('#DocType').removeAttr("disabled");
        }
    }
    else if (TranType = "Outward") {
        if (SubSupplyType == "Supply")
            data = OUTWARDSupply;
        else if (SubSupplyType == "Export")
            data = OUTWARDSExport;
        else if (SubSupplyType == "Jobwork")
            data = OutwardJobWork;
        else if (SubSupplyType == "SKD/CKD/Lots") {
            $('#DocType').removeAttr("disabled");
            data = OutwardSKD;
        }
        else if (SubSupplyType == "Recipient Not Known") {
            $('#DocType').removeAttr("disabled");
            data = OutWardrecipientUnknown;
        }
        else if (SubSupplyType == "Exhibition or Fairs")
            data = OutwardJobWork;
        else if (SubSupplyType == "For Own Use")
            data = OutWardForOwnUse;
        else if (SubSupplyType == "LineSales") {
            $('#DocType').attr("disabled", "disabled");
            data = OutwardLineSales;
        }
        else {
            $('#DocType').removeAttr("disabled");
            data = Others;
        }
    }
    else {
        data = Others;
        $('#DocType').removeAttr("disabled");
    }
    var html = '';
    $.each(data, function (e, val) {
        html += '<option value=' + val.Value + ' ' + (val.Selected ? 'selected' : '') + '>' + val.Text + '</option>';
    });
    $('#DocType').html(html);
}


function addItems() {
    $.ajax({
        url: "/EBILL/_RequestItems",
        data: $('#form_User').serialize() + "&bIsAddNew=true",
        method: "POST",
        success: function (res) {
            //table.destroy();
            $('#requestBody').html(res);
            //table = $('#itemDataTable').removeAttr('width').DataTable({
            //    "bPaginate": false,
            //    "paging": false,
            //    "bFilter": false, //hide Search bar
            //    "bInfo": false,
            //    "ordering": false,
            //    "autoWidth": false,
            //    "scrollX": true,
            //    destroy: true,
            //    columnDefs: [
            //        { width: 600, targets: 1 }
            //    ],
            //});
        }
    });
}

function deleteItems() {
    $('#itemDataTable > tbody tr').find('input,select').each(function (i, element) {
        var name = $(element).attr("name");
        var previousName = name.split('[')[0];
        var lastName = name.split(']')[1];
        var index = $(element).closest('td').closest('tr').index();
        name = previousName + '[' + index + ']' + lastName;
        $(element).attr("name", name);
    });
}

$(document).on('click', '.btnDeleteItem', function () {
    $(this).closest('td').closest('tr').remove();
    deleteItems();
});