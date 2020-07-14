function initGeneratedTable() {
    $('.GetView').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    });
    if (html == undefined || html == null) {
        html = $('.filterRow').html();
        $('.filterRow').empty();
    }
    GeneratedTable = $('#tblGenerated').DataTable({
        "order": [[4, "desc"]],
        "searching": true,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/Ebill/GetGeneratedBillsByFilter",
            "type": "POST",
            "data": function (d) {
                d.apiType = $('#ddlApiList2').val();
                d.supplyType = $('#ddlSupplyList').val();
                return d;
            },
        },
        "columns": [
            {
                "data": "EWB_ID",
                visible: false
            },
            {
                data: null, orderable: false//,
            },
            {
                "data": "DocNo",
                "render": function (data, type, full) {
                    if (data === null) return "";
                    return "<a href='#' class='editor_edit' onclick='javascript:OpenUPopUp(" + JSON.stringify(full['EWB_ID']) + ");'>" + full['DocNo'] + "</a>";
                }
            },
            {
                "data": "EwayBillNo", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": "EwayBillDate", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + formatAMPM(dt);
                }
            },
            {
                "data": "ValidUpto", "type": "date ",
                "render": function (value) {
                    if (value === null) return "";
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                }
            },
            {
                "data": "TotalValue", "defaultContent": '<a href="#" class="editor_edit">--</a>', "render": function (data, type, full) {
                    var value = data == null ? " 0 " : data;
                    return "<span><i class='fa fa-inr'></i></span> " + value;
                },
            },
            {
                "data": "UserGSTIN", "defaultContent": '<a href="#" class="editor_edit">--</a>'
            },
            {
                "data": null, "orderable": false, "render": function (data, type, row, full) {
                    var value = data == null ? " 0 " : data;
                    var successData = '<div class="btn-group">' +
                        '<button data-toggle="dropdown" class="btn btn-link dropdown-toggle" aria-expanded="false"><i class="fa fa-file-pdf-o" style="font-size:15px;color:red"></i></button>' +
                        '<ul class="dropdown-menu">' +
                        '<li><a class="dropdown-item" onclick="DownloadFreezedPDF(' + row.EWB_ID + ')" href="#">Detailed PDF</li>' +
                        '<li><a class="dropdown-item" href="/Ebill/PrintFreezeReportWithoutDetails?EWB_ID=' + row.EWB_ID + '">Non Detailed PDF</li>' +
                        '</ul></div> ';
                    return successData;
                }
            },
            {
                "data": null, "orderable": false, "render": function (data, type, full) {
                    var html = '';
                    if (full.isRejected) {
                        html += '<button type="button" class="btn btn-danger btn-xs reject" data-id="' + full.EWB_ID + '">Reject</button>'
                    }
                    if (full.isCancelled) {
                        html += ' <button type="button" class="btn btn-secondary btn-xs cancel" data-id="' + full.EWB_ID + '">Cancel</button>'
                    }
                    if (full.isPartB) {
                        html += " <button type=\"button\" class=\"btn btn-primary btn-xs\" onclick='javascript:GenerateOpenPartB(" + JSON.stringify(full.EWB_ID) + ");'>Update Part-B</button>";
                    }
                    if (full.isExtendedValidity) {
                        html += " <button type=\"button\" class=\"btn btn-success btn-xs extendValidity\" data-id=\"" + full.EWB_ID + "\">Extend Validity</button>";
                    }
                    if (full.isUpdateTransporter) {
                        html += " <button type=\"button\" class=\"btn btn-dark btn-xs updateTransporter\" data-id=\"" + full.EWB_ID + "\">Update Transporter</button>";
                    }
                    if (full.canBeInititated) {
                        html += " <button type=\"button\" class=\"btn btn-warning btn-xs initiateMultiVehicle\" data-id=\"" + full.EWB_ID + "\">Initiate Multi-Vehicle</button>";
                    }
                    if (full.isInitiated) {
                        html += " <button type=\"button\" class=\"btn btn-default btn-xs addMultiVehicle\" data-id=\"" + full.EWB_ID + "\">Add/Update Multi-Vehicle</button>";
                    }
                    return html;
                },
            }


        ],
        "columnDefs": [
            {
                'targets': 1,
                'checkboxes': {
                    'selectRow': true
                }
            },
        ],
        select: {
            style: 'multi',
            selector: 'td:first-child'
        },
        drawCallback: function (settings) {
            $('#tblGenerated_wrapper > .row > div:first').html(html);
            if (supplyType != undefined && supplyType != "")
                $('#ddlSupplyList').val(supplyType);
            if (apiType != undefined && apiType != "")
                $('#ddlApiList2').val(apiType);
            GeneratedTable.rows().deselect();
        }
    });
}

function UpdateTransporterAPI(ewbid) {
    $("#addUpdateModallgContainer").load("/Ebill/UpdatedTransBill", function () {
        $("#addUpdateModallgContainer").find('select').selectpicker();
        $.validator.unobtrusive.parse('#FrmUpdateTrans');
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $('#TransDocDate').datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        $("#addUpdatelgModal").modal('show');
    });
};

function GenerateOpenPartB(ewbid) {
    $('#addUpdateModalContainer').load('/Ebill/GeneratePartBUpdate?ID=' + ewbid, function () {
        $('#TransMode').selectpicker('refresh');
        $('#VehicleType').selectpicker('refresh');
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $("#TransDocDate").datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        $('#ReasonCode').selectpicker('refresh');
        changeReasonCode();
        $.validator.unobtrusive.parse('#frmGeneratedPartB');
        $("#addUpdateModal").modal('show');
    });
};

$(document).on('click', '.reject', function (e) {
    e.preventDefault();
    var ewb_id = $(this).attr('data-id');
    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ ebillId: ewb_id }),
        url: "/Ebill/RejectBill",
        success: function (response) {
            if (response.isSuccess) {
                alertify.success("Ebill Rejected..");
                GeneratedTable.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.message);
            }
        },
        error: function (ajaxRequest, strError) {
            var respText = ajaxRequest.responseText;
            alertify.error(strError);
        }
    });
});

$(document).on('click', '.cancel', function (e) {
    e.preventDefault();
    var ewb_id = $(this).attr('data-id');
    $("#addUpdateModalContainer").load("/Ebill/CancelBill?EWB_Id=" + ewb_id, function () {
        $("#addUpdateModalContainer").find('select').selectpicker();
        $.validator.unobtrusive.parse('#frmCancelBill');
        $("#addUpdateModal").modal('show');
    })
});

$(document).on('click', '.extendValidity', function (e) {
    e.preventDefault();
    var ewb_id = $(this).attr('data-id');
    $("#addUpdateModallgContainer").load("/Ebill/ExtendvalidityBill?Ewb_id=" + ewb_id, function () {
        $("#addUpdateModallgContainer").find('select').selectpicker();
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $('#TransDocDate').datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        checkExtendedValidity();
        $.validator.unobtrusive.parse('#FrmExtendValidityBill');
        $("#addUpdatelgModal").modal('show');
    })
});

$(document).on('click', '.updateTransporter', function (e) {
    var ewb_id = $(this).attr('data-id');
    $("#addUpdateModallgContainer").load("/Ebill/UpdatedTransBill", function () {
        $("#ebillid").val(ewb_id);
        $.validator.unobtrusive.parse('#FrmUpdateTrans');
        $("#addUpdatelgModal").modal('show');
    })
});

$(document).on('click', '.initiateMultiVehicle', function (e) {
    var ewb_id = $(this).attr('data-id');
    $("#addUpdateModallgContainer").load("/Ebill/InitiateMultiVehicleBill?id=" + ewb_id, function () {
        $.validator.unobtrusive.parse('#FrmInitiateMultiVehicle');
        $("#addUpdatelgModal").modal('show');
    })
});


$(document).on('click', '.addMultiVehicle', function (e) {
    var ewb_id = $(this).attr('data-id');
    $("#addUpdateModallgContainer").load("/Ebill/AddMultiVehicleBill?id=" + ewb_id, function () {
        $('#GroupId').selectpicker();
        $.validator.unobtrusive.parse('#FrmAddMultiVehicle');
        $("#addUpdatelgModal").modal('show');
    })
});


$(document).on('change', '#ddlSupplyList', function (e) {
    supplyType = $(this).val();
    GeneratedTable.ajax.reload();
});

$(document).on('change', '#ddlApiList2', function (e) {
    apiType = $(this).val();
    GeneratedTable.ajax.reload();
});

//Post API's --Start--
$(document).on('submit', '#frmCancelBill', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                alertify.success("Ebill Cancelled.");
                GeneratedTable.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.message);
            }
        },
        failure: function (response) {
            alertify.error("Some Error found.");
        },
        error: function (response) {
            alertify.error("Failed! to cancel Some Error found.");
        }
    });
});

$(document).on('change', '#CancelReason', function () {
    if ($('#CancelReason option:selected').text() !== "Others") {
        $('#rowOther').hide();
        $('#Other').val('');
    }
    else {
        $('#rowOther').show();
    }
});

$(document).on('submit', '#FrmConsolidateBill', function (e) {
    e.preventDefault();
    var tblData = GeneratedTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.toString();
    data = $('#FrmConsolidateBill').find('#ebillid').val(data);
    if (checkConsolidateTransporterDetails() && $('#FrmConsolidateBill').valid()) {
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.isSuccess) {
                    alertify.success("Consolidated Bill Generated Successfully..");
                    GeneratedTable.ajax.reload();
                    $('.modal').modal('hide');
                } else {
                    alertify.error(response.message);
                }
            },
            failure: function (response) {
                alertify.error("Some Error found.");
            },
            error: function (response) {
                alertify.error("Failed! to Generate Consolidate Bill Some Error found.");
            }
        });
    }
});

$(document).on('submit', '#FrmExtendValidityBill', function (e) {
    e.preventDefault();
    if (checkExtendValidityTransporterDetails() && $('#FrmExtendValidityBill').valid() && checkExtendedValidity()) {
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.isSuccess) {
                    alertify.success("Validity Extended Sucessfully..");
                    GeneratedTable.ajax.reload();
                    $('.modal').modal('hide');
                } else {
                    alertify.error(response.message);
                }
            },
            failure: function (response) {
                alertify.error("Some Error found.");
            },
            error: function (response) {
                alertify.error("Failed! to Extend Validity Some Error found.");
            }
        });
    }
});

$(document).on('submit', '#FrmUpdateTrans', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                alertify.success("Transporter Updated Sucessfully..");
                GeneratedTable.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.message);
            }
        },
        failure: function (response) {
            alertify.error("Some Error found.");
        },
        error: function (response) {
            alertify.error("Failed! to Upadte Transporter Some Error found.");
        }
    });
});

$(document).on('submit', '#FrmInitiateMultiVehicle', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                alertify.success("Multi Vehicle Initiated Sucessfully..");
                GeneratedTable.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.message);
            }
        },
        failure: function (response) {
            alertify.error("Some Error found.");
        },
        error: function (response) {
            alertify.error("Failed! to Initiate Multi Vehicle Some Error found.");
        }
    });
});

$(document).on('submit', '#FrmAddMultiVehicle', function (e) {
    e.preventDefault();
    if ($(this).valid() && ValidateQuantity() && ValidateMultiVehicle()) {
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.isSuccess) {
                    alertify.success("Multi Vehicle Added Sucessfully..");
                    GeneratedTable.ajax.reload();
                    $('.modal').modal('hide');
                } else {
                    alertify.error(response.message);
                }
            },
            failure: function (response) {
                alertify.error("Some Error found.");
            },
            error: function (response) {
                alertify.error("Failed! to Add Multi Vehicle Some Error found.");
            }
        });
    }
});

$(document).on('submit', '#FrmChangeMultiVehicle', function (e) {
    e.preventDefault();
    var tblData = GeneratedTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.toString();
    data = $('#FrmChangeMultiVehicle').find('#ebillid').val(data);
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                alertify.success("Multi Vehicle Changed Sucessfully..");
                GeneratedTable.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.message);
            }
        },
        failure: function (response) {
            alertify.error("Some Error found.");
        },
        error: function (response) {
            alertify.error("Failed! to Change Multi Vehicle Some Error found.");
        }
    });
});
//Post API's --End--

$(document).on('click', '#ApiAction', function () {
    //var tblData = table.rows('.selected').data();
    var tblData = GeneratedTable.rows('.selected').data();
    var arrTableSelectedRowsRendered = [];
    tblData.each(function (value, index) {
        arrTableSelectedRowsRendered.push(value.EWB_ID);
    });
    var data = arrTableSelectedRowsRendered.toString();

    var apiAction = $("#ddlApiList").val();
    if (apiAction === '0' || apiAction === null || apiAction === "") {
        alertify.error("Please select Action to execute a request.");
        $("#ddlApiList").focus();
        return false;
    }
    if (arrTableSelectedRowsRendered.length > 0) {
        if (apiAction == "CONSBILL") {
            $("#addUpdateModallgContainer").load("/Ebill/ConsolidateBill", function () {
                $("#addUpdateModallgContainer").find('select').selectpicker();
                $.validator.unobtrusive.parse('#FrmConsolidateBill');
                var minDate = new Date();
                var n = -6;
                if (minDate.getMonth() < n)
                    minDate.setFullYear(minDate.getFullYear() - 1);
                minDate.setMonth((minDate.getMonth() + n) % 12);
                $('#CtransDocDate').datepicker({
                    format: 'dd/mm/yyyy',
                    endDate: new Date(),
                    startDate: minDate
                });
                $("#addUpdatelgModal").modal('show');
            })
            return false;
        }
        else {

            $.ajax({
                dataType: 'json',
                type: 'Post',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ action: apiAction, ebillId: data }),
                url: "ApiAction",
                success: function (data) {
                    if (data != null && data.message != null) {
                        if (data != null && data.responseCode == 200) {
                            $('#CustomerModel').DataTable().ajax.reload();
                            alertify.success(data.message);
                        }
                        else { alertify.error(data.message); }
                    }
                    else {
                        $('#CustomerModel').DataTable().ajax.reload();
                        alertify.error("Please try again later.");
                    }
                },
                error: function (ajaxRequest, strError) {
                    var respText = ajaxRequest.responseText;
                    alertify.error(strError);
                }
            });
        }
    } else { alertify.error("No E-Bill Doc selected!..Please select first.."); }
});

function UpdateMultiVeh(EWB_VehicleId)
{
    $('.modal').modal('hide');
    $("#addUpdateModallgContainer").load("/Ebill/ChangeMultiVehicleBill?EWB_VehicleId=" + EWB_VehicleId, function () {
        $("#addUpdateModallgContainer").find('select').selectpicker();
        $.validator.unobtrusive.parse('#FrmChangeMultiVehicle');
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $('#ATransDocDate').datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        $("#addUpdatelgModal").modal('show');
    })
}

function checkConsolidateTransporterDetails() {
    var mode = $('#CMode option:selected').text();
    var CVehNo = $('#CVehNo').val();
    var CtransDocNo = $('#CtransDocNo').val();
    var CtransDocDate = $('#CtransDocDate').val();
    var validator = $("#FrmConsolidateBill").validate();
    resetForm();
    if (mode == "Road" && CVehNo == "") {
        validator.showErrors({
            "CVehNo": "Vehicle No is a required field."
        });
        return false;
    }
    else if (mode == "Rail" || mode == "Air" || mode == "Ship") {
        var IsValid = true;
        if (CtransDocNo == "") {
            validator.showErrors({
                "CtransDocNo": "Tranporter Doc. No is a required field."
            });
            IsValid = false;
        }
        if (CtransDocDate == "") {
            validator.showErrors({
                "CtransDocDate": "Tranporter Doc. Date is a required field."
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

$(document).on('change', '#RCReason', function () {
    if ($('#RCReason option:selected').text() !== "Others") {
        $('#rowOtherCode').hide();
        $('#RCReasonRem').val('');
    }
    else {
        $('#rowOtherCode').show();
    }
});

function checkExtendValidityTransporterDetails() {
    var mode = $('#ExtendTransMode option:selected').text();
    var CVehNo = $('#VehNo').val();
    var CtransDocNo = $('#TransDocNo').val();
    var CtransDocDate = $('#TransDocDate').val();
    var validator = $("#FrmExtendValidityBill").validate();
    resetForm();
    if (mode == "Road" && CVehNo == "") {
        validator.showErrors({
            "VehNo": "Vehicle No is a required field."
        });
        return false;
    }
    else if (mode == "Rail" || mode == "Air" || mode == "Ship") {
        var IsValid = true;
        if (CtransDocNo == "") {
            validator.showErrors({
                "TransDocNo": "Tranporter Doc. No is a required field."
            });
            IsValid = false;
        }
        if (CtransDocDate == "") {
            validator.showErrors({
                "TransDocDate": "Tranporter Doc. Date is a required field."
            });
            IsValid = false;
        }
        return IsValid;
    }
    return true;
}

function GeneratedDownloadPDF(EWBID) {
    location.href = '/Ebill/PrintFreezeReport?EWB_ID=' + EWBID;
}

$(document).on('change', '#ReasonCode', function () {
    changeReasonCode();
});

function changeReasonCode() {
    if ($('#ReasonCode option:selected').text() === "Others") {
        $(".otherRow").show();
    }
    else {
        $(".otherRow").hide();
        $(".otherRow").find('input').val('');
    }
}

$(document).on('submit', '#frmGeneratedPartB', function (e) {
    e.preventDefault();
    var $this = $(this);
    if ($this.valid() && checkPartB()) {
        var formData = $(this).serialize();
        $.ajax({
            url: $this.attr('action'),
            type: $this.attr('method'),
            global: false,
            data: formData,
            success: function (response) {
                var result;
                if (typeof (response) == "object")
                    result = response;
                else
                    result = JSON.parse(response);
                if (result.Status) {
                    GeneratedTable.ajax.reload();
                    alertify.success(result.Message);
                    $('.modal').modal('hide');
                }
                else {
                    alertify.error(result.Message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
                alertify.error(errorThrown.message);
            }
        });
    }
});

$(document).on('change', '#ExtendTransMode', function () {
    checkExtendedValidity();
});

function checkExtendedValidity() {
    var transMode = parseInt($('#ExtendTransMode').val());
    var validator = $("#FrmExtendValidityBill").validate();
    resetForm();
    if (transMode >= 1 && transMode <= 4) {
        $("#TransitType option").removeAttr('selected');
        $("#TransitType option:first").attr('selected', '');
        $("#TransitType").attr('disabled', '');
        $("#TransitType").selectpicker('refresh');
        $('#AddressLine1').val('');
        $('#AddressLine1').attr('disabled', '');
        $('#AddressLine2').val('');
        $('#AddressLine2').attr('disabled', '');
        $('#AddressLine3').val('');
        $('#AddressLine3').attr('disabled', '');
    }
    else {
        var IsValid = true;
        $("#TransitType").removeAttr('disabled');
        $("#TransitType").selectpicker('refresh');
        $('#AddressLine1').removeAttr('disabled');
        $('#AddressLine2').removeAttr('disabled');
        $('#AddressLine3').removeAttr('disabled');

        if ($("#TransitType").val() == "") {
            validator.showErrors({
                "TransitType": "Transit Type is a required field."
            });
            IsValid = false;
        }
        if ($("#AddressLine1").val() == "") {
            validator.showErrors({
                "AddressLine1": "Address 1 is a required field."
            });
            validator.showErrors({
                "AddressLine2": "Address 2 is a required field."
            });
            validator.showErrors({
                "AddressLine3": "Address 3 is a required field."
            });
            IsValid = false;
        }
        return IsValid;
    }
    return true;
}

function checkPartB() {
    var validator = $("#frmGeneratedPartB").validate();
    resetForm();
    if ($('#TransMode').val() == 1 && $('#VehicleNo').val() == "") {
        validator.showErrors({
            "VehicleNo": "Vehicle No is a required field."
        });
        return false;
    }
    else if ($('#TransDocNo').val() == "") {
        validator.showErrors({
            "TransDocNo": "Trans Doc No is a required field."
        });
        return false;
    }
    return true;
}


$(document).on('change', '#TransMode', function (e) {
    e.preventDefault();
    if ($('#TransMode').val() != 1) {
        $('#VehicleNo').val('');
        $('#VehicleNo').attr('disabled', '');
    }
    else {
        $('#VehicleNo').removeAttr('disabled');
    }
});

$(document).on('change', '#GroupId', function (e) {
    $('#GroupData').load('/Ebill/GetGroupDetails?GroupId=' + $(this).val(), function () {
        var minDate = new Date();
        var n = -6;
        if (minDate.getMonth() < n)
            minDate.setFullYear(minDate.getFullYear() - 1);
        minDate.setMonth((minDate.getMonth() + n) % 12);
        $('#ATransDocDate').datepicker({
            format: 'dd/mm/yyyy',
            endDate: new Date(),
            startDate: minDate
        });
        resetForm();
        removeValidationErrors('FrmAddMultiVehicle');
    });
});


function removeValidationErrors(frmId) {
    var myform = $('#' + frmId);
    var myValidator = myform.validate();
    $(myform).removeData('validator');
    $(myform).removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(myform);
    myValidator.resetForm();
    $('#' + frmId + ' input, select').removeClass('input-validation-error');
}

$(document).on('keydown', '.qty', function (e) {
    setTimeout(function () {
        ValidateQuantity();
    }, 100);
});

function ValidateQuantity() {
    var number = parseFloat($('#AQuantity').val());
    var max = parseFloat($('#AQuantity').attr('max'));
    if (number > max) {
        var validator = $("#FrmAddMultiVehicle").validate();
        resetForm();
        validator.showErrors({
            "AQuantity": "Quantity should be less than or equal to " + max
        });
        return false;
    }
    return true;
}

function ValidateMultiVehicle() {
    var vehNo = $('#AVehicleNo').val();
    var transMode = $('#TransMode').val();
    if (vehNo == "" && transMode == "Road") {
        var validator = $("#FrmAddMultiVehicle").validate();
        resetForm();
        validator.showErrors({
            "AVehicleNo": "Vehicle Number is a required field."
        });
        return false;
    }
    return true;
}