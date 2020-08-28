$(function () {
    $('#tblUser').DataTable({
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
            url: '/User/GetUsers',
            method: 'POST'
        },
        'columns': [
            {
                "data": "iUserId", 'orderable': false, 'mRender': function (data, abc, full) {
                    return '<button type="button" onClick="AddUser(' + data + ')" class="btn btn-xs btn-warning"><i class="fa fa-edit"></i></button>'
                }
            },
            { "data": "sFirstName", 'orderable': false },
            { "data": "sLastName", 'orderable': false },
            { "data": "sEmailID", 'orderable': false },
            { "data": "sRoleName", 'orderable': false },
            { "data": "sPhoneNo", 'orderable': false },
        ]
    })
});
function AddUser(iUserId) {
    $('#addUpdateModallgContainer').load('/User/AddUpdateUser?iUserId=' + iUserId, function () {
        $.validator.unobtrusive.parse('#frmSaveUser');
        $('#iRoleId').selectpicker();
        //$('#iSocietyId').selectpicker();
        $('#addUpdatelgModal').modal('show');
    });
}

$(document).on('submit', '#frmSaveUser', function (e) {
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
                    $('#tblUser').DataTable().ajax.reload();
                    $('#addUpdatelgModal').modal('hide');
                }
                else {
                    alertify.error(res.Message);
                }
            }
        })
    }
});

