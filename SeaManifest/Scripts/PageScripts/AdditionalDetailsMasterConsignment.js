$(function () {
    initAdditionalDetailsMasterConsignments();
});

var AdditionalDetailsMasterConsignmentTable;

function initAdditionalDetailsMasterConsignments() {
    AdditionalDetailsMasterConsignmentTable = $('#tblAdditionalDetailsMasterConsignment').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/AdditionalDetailsMasterConsignment/GetAdditionalDetailsMasterConsignment",
            "type": "POST",
        },
        "columns": [
            {
                "data": "sTagRef",
            },
            {
                "data": "dRefSerialNo"
            },
            {
                "data": "sInfoType",
            },
            {
                "data": "sInfoQualifier",
            },
            {
                "data": "sInfoCd",
            },
            {
                "data": "sInfoText",
            },
            {
                "data": "sInfoMsr",
            },
            {
                "data": "sInfoDate",
            },
            {
                "data": "iAdditionalDetailsId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs not-hide\" onClick=\"AddUpdateAdditionalDetailsMasterConsignment(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdateAdditionalDetailsMasterConsignment(iAdditionalDetailsMasterConsignmentId) {
    $('#addUpdateModallgContainer').load('/AdditionalDetailsMasterConsignment/AddUpdateAdditionalDetailsMasterConsignment?iAdditionalDetailsId=' + iAdditionalDetailsMasterConsignmentId, function () {
        initAddUpdateAdditionalDetailsMasterConsignment();
    });
}

function initAddUpdateAdditionalDetailsMasterConsignment() {
    $.validator.unobtrusive.parse('#frmAdditionalDetailsMasterConsignment');
    $('#frmAdditionalDetailsMasterConsignment select').selectpicker();
    $('#psInfoDate').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('#addUpdatelgModal').modal('show');
}

$(document).on('submit', '#frmAdditionalDetailsMasterConsignment', function (e) {
    e.preventDefault();
    if ($(this).valid())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    AdditionalDetailsMasterConsignmentTable.ajax.reload();
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