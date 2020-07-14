var CreateTable, FreezedTable, GeneratedTable, ConsolidatedBill, ReceivedBill, CanceledBill, RejectedBill, ExtendedValidityBill, MultivehicledBill, html, apiType, supplyType;

$(document).ready(function () {
    BindTables();
});


function UpdateBillStatus(BillId) {
    var ewb_id = BillId;
    var radiobtnVal = $('input[name=Status' + ewb_id + ']:checked').val();
    if (ewb_id > 0) {
        var objUserModel = { EWB_ID: ewb_id, Status: radiobtnVal };
        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ ObjUserModel: objUserModel }),
            url: "UpdateBillStatus",
            success: function (data) {
                if (data != null && data.message != null) {
                    if (data != null && data.responseCode == 200) {
                        $('#CustomerModel').DataTable().ajax.reload();//Refresh the User grid.
                        $("#modal-default-" + ewb_id).modal('toggle');
                        alertify.success(data.message);
                    }
                    else { alertify.error(data.message); }
                }
                else {
                    $('#CustomerModel').DataTable().ajax.reload();
                    $("#modal-default-" + ewb_id).modal('toggle');
                    // alertify.error("Please try again later.");
                }
            },
            error: function (ajaxRequest, strError) {
                var respText = ajaxRequest.responseText;
            }
        });
    } else { alertify.error("Refresh the page."); }
}

$(document).on('click', '.nav-tabs', function () {
    BindTables();
});

function BindTables() {
    var SelectedTabId = $('.nav.nav-tabs >li > a.nav-link.active').attr('href');
    if (SelectedTabId == "#CreateBill") {
        initCreateTable();
    }
    else if (SelectedTabId == '#FreezedBill') {
        initFreezeTable();
    }
    else if (SelectedTabId == '#GeneratedBill') {
        initGeneratedTable();
    }
    else if (SelectedTabId == '#ConsolidatedBill') {
        initConsolidatedTable();
    }
    else if (SelectedTabId == '#ReceivedBill') {
        initReceivedTable();
    }

    else if (SelectedTabId == '#CanceledBill') {
        initCanceledTable();
    }
    else if (SelectedTabId == '#RejectedBill') {
        initRejectedTable();
    }
    else if (SelectedTabId == '#ExtendedValidityBill') {
        initExtendedValidityTable();
    }
    else if (SelectedTabId == '#MultivehicledBill') {
        initMultivehicledTable();
    }
}

function OpenUPopUp(ewbid) {
    $('#addUpdateModallgContainer').load('/EBILL/EbillDetails?ID=' + ewbid, function () {
        var target = $('.nav-tabs >li > a.active').attr('href');
        if (target == "#CreateBill")
            $('.m-t-none b').html('Created Bill');
        else if (target == "#FreezedBill")
            $('.m-t-none b').html('Freezed Bill');
        else if (target == "#GeneratedBill") {
            var EwayBillNo = $('#EwayBillNo').val();
            $('.m-t-none b').html('Generated Bill (' + EwayBillNo + ' )');
        }
        else if (target == "#ConsolidatedBill") {
            var EwayBillNo = $('#cEwbNo').val();
            $('.m-t-none b').html('Consolidated Bill (' + EwayBillNo + ' )');
        }
        else if (target == "#ReceivedBill")
            $('.m-t-none b').html('Received Bill');


        else if (target == "#CanceledBill") {
            var EwayBillNo = $('#EwayBillNo').val();
            $('.m-t-none b').html('Cancelled Bill (' + EwayBillNo + ' )');
        }
        else if (target == "#RejectedBill") {
            var EwayBillNo = $('#EwayBillNo').val();
            $('.m-t-none b').html('Rejected Bill (' + EwayBillNo + ' )');
        }
        else if (target == "#ExtendedValidityBill")
            $('.m-t-none b').html('Extended Validity Bill');
        else if (target == "#MultivehicledBill")
            $('.m-t-none b').html('Multivehicled Bill');


        $("#addUpdatelgModal").modal('show');
    });
}

$(document).on('click', '.GetView', function (e) {
    e.preventDefault();
    var href = $(this).data('href');
    $('#addUpdateModalContainer').load(href, function () {
        if ($('#date').length > 0)
            $('#date').datepicker({
                endDate: new Date(),
                format: "dd/mm/yyyy"
            });
        $.validator.unobtrusive.parse('form');
        $('#addUpdateModal').modal('show');
    });
});

$(document).on('submit', '#frmGetEwayBillDetail', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillDate', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillOtherParty', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillTransp', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillTranspGSTN', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillTranspState', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillRejectedBy', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

$(document).on('submit', '#frmGetEwayBillbyconsigner', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.isSuccess) {
                if (GeneratedTable != undefined) GeneratedTable.ajax.reload();
                alertify.success("Eway Bill Details has been saved.");
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

function UploadExcel() {
    $('#inpFile').click();
}

$(document).on('change', '#inpFile', function () {
    var fd = new FormData();
    var files = $('#inpFile')[0].files[0];
    fd.append('file', files);
    $.ajax({
        url: '/Ebill/UploadExcel',
        type: 'post',
        data: fd,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.hasExcel) {
                var btn = document.createElement('a');
                btn.href = response.Excel;
                btn.click();
                alertify.error(response.message);
            }
            else if (!response.status)
                alertify.error(response.message);
            else
                alertify.success(response.message);
            $("#inpFile").val(null);
        }
    });
});


function UploadJson() {
    $('#inpJsonFile').click();
}

$(document).on('change', '#inpJsonFile', function () {
    var fd = new FormData();
    var files = $('#inpJsonFile')[0].files[0];
    fd.append('file', files);
    $.ajax({
        url: '/Ebill/UploadJson',
        type: 'post',
        data: fd,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.hasJson) {
                var btn = document.createElement('a');
                btn.download = "";
                btn.href = response.Json;
                btn.click();
                alertify.error(response.message);
            }
            else if (!response.status)
                alertify.error(response.message);
            else
                alertify.success(response.message);
            $("#inpJsonFile").val(null);
        }
    });
});