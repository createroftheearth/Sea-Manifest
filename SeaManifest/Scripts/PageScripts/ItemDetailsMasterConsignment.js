$(function () {
    initItemDetailsMasterConsignments();
});

var ItemDetailsMasterConsignmentTable;

function initItemDetailsMasterConsignments() {
    ItemDetailsMasterConsignmentTable = $('#tblItemDetailsMasterConsignment').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/ItemDetailsMasterConsignment/GetItemDetailsMasterConsignment",
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
                "data": "iItemDetailsMasterConsignmentId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateItemDetailsMasterConsignment(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdateItemDetailsMasterConsignment(iItemDetailsMasterConsignmentId) {
    $('#addUpdateModallgContainer').load('/ItemDetailsMasterConsignment/AddUpdateItemDetailsMasterConsignment?iItemDetailsMasterConsignmentId=' + iItemDetailsMasterConsignmentId, function () {
        initAddUpdateItemDetailsMasterConsignment();
    });
}

function initAddUpdateItemDetailsMasterConsignment() {
    $.validator.unobtrusive.parse('#frmItemDetailsMasterConsignment');
    $('#frmItemDetailsMasterConsignment select').selectpicker();
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

$(document).on('submit', '#frmItemDetailsMasterConsignment', function (e) {
    e.preventDefault();
    if ($(this).valid())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    ItemDetailsMasterConsignmentTable.ajax.reload();
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