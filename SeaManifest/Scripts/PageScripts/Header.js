$(function () {
    initHeader();
});

var HeaderTable;
function initHeader() {
    HeaderTable = $('#tblHeader').DataTable({
        "searching": true,
        "ordering":false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/MessageImplementation/GetHeaders",
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
                    return "<button type=\"button\" onClick=\"AddUpdateHeader("+data+")\"><i class=\"fa fa-edit\"></i></button>";
                }
            },
        ]
    });
}


function AddUpdateHeader(iMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/MessageImplementation/AddUpdateHeader?iMessageImplementationId=' + iMessageImplementationId, function () {
        $.validator.unobtrusive.parse('#frmHeader');
        $('#addUpdatelgModal').modal('show');
    });
}

$(document).on('submit', '#frmHeader', function (e) {
    e.preventDefault();
    $.ajax({
        type: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        success: function (response) {
            if (response.Status) {
                alertify.success(response.Message);
                HeaderTable.ajax.reload();
                $('.modal').modal('hide');
            } else {
                alertify.error(response.Message);
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

