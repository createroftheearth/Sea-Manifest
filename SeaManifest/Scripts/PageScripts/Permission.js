var Permission;
$(function () {
    Permission = $('#tblPermission').DataTable({
        "responsive": true,
        "pagingType": "simple_numbers",
        "iDisplayLength": 10,
        "processing": true,
        "serverSide": true,
        "filter": true,
        "bLengthChange": false,
        "searching": false,
        "destroy": true,
        ordering: false,
        'ajax': {
            url: '/Permissions/GetPermissions',
            method: 'POST'
        },
        'columns': [
            {
                "data": "iPermissionId", 'orderable': false, 'mRender': function (data, abc, full) {

                    var html = '<button type="button" onClick="AddPermission(' + data + ')" class="btn btn-xs btn-warning"><i class="fa fa-edit"></i></button>';
                    return html;
                }
            },
            {
                "data": "parent", 'orderable': false
            },
            {
                "data": "sPermissionName", 'orderable': false
            },
            {
                "data": "sPath", 'orderable': false
            },
            {
                "data": "iOrder", 'orderable': false
            },
        ]
    })
});

function AddPermission(iPermissionId) {
    $('#addUpdateModallgContainer').load('/Permissions/AddUpdatePermission?iPermissionId=' + iPermissionId, function () {
        $.validator.unobtrusive.parse('#frmSavePermission');
        $('#iParentId').selectpicker();
        $('#addUpdatelgModal').modal('show');
    });
}


$(document).on('submit', '#frmSavePermission', function (e) {
    e.preventDefault();
    var $this = $(this);
    var data = new FormData(this);
    if ($this.valid()) {
        $.ajax({
            url: $this.attr('action'),
            method: $this.attr('method'),
            contentType: false, // Not to set any content header  
            processData: false,
            data: data,
            success: function (res) {
                if (res.Status) {
                    alertify.success(res.Message);
                    $('#tblPermission').DataTable().ajax.reload();
                    $('#addUpdatelgModal').modal('hide');
                }
                else {
                    alertify.error(res.Message);
                }
            }
        })
    }
});
