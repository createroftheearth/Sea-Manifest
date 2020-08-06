$(function () {
    initItemDetailsHouseCargos();
});

var ItemDetailsHouseCargoTable;

function initItemDetailsHouseCargos() {
    ItemDetailsHouseCargoTable = $('#tblItemDetailsHouseCargo').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/ItemDetailsHouseCargo/GetItemDetailsHouseCargo",
            "type": "POST",
        },
        "columns": [
            {
                "data": "dCargoItemSequenceNo",
            },
            {
                "data": "sCargoItemDesc"
            },
            {
                "data": "dNoOfPakages",
            },
            {
                "data": "sTypesOfPackages",
            },
            {
                "data": "iItemDetailsHouseCargoId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateItemDetailsHouseCargo(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdateItemDetailsHouseCargo(iItemDetailsHouseCargoId) {
    $('#addUpdateModallgContainer').load('/ItemDetailsHouseCargo/AddUpdateItemDetailsHouseCargo?iItemDetailsHouseCargoId=' + iItemDetailsHouseCargoId, function () {
        initAddUpdateItemDetailsHouseCargo();
    });
}

function initAddUpdateItemDetailsHouseCargo() {
    $.validator.unobtrusive.parse('#frmItemDetailsHouseCargo');
    $('#frmItemDetailsHouseCargo select').selectpicker();
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
}

$(document).on('submit', '#frmItemDetailsHouseCargo', function (e) {
    e.preventDefault();
    if ($(this).valid())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    ItemDetailsHouseCargoTable.ajax.reload();
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