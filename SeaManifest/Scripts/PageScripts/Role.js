$(function () {
    $('#tblRole').DataTable({
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
            url: '/Role/GetRoles',
            method: 'POST'
        },
        'columns': [
            {
                "data": "iRoleId", 'orderable': false, 'mRender': function (data, abc, full) {
                    return '<button type="button" onClick="AddRole(' + data + ')" class="btn btn-xs btn-warning"><i class="fa fa-edit"></i></button>'
                        + ' <button type="button" onClick="AddUpdateRolePermissions(' + data + ')" class="btn btn-xs btn-success"><i class="fa fa-plus"></i></button>';
                }
            },
            { "data": "sRolename", 'orderable': false },
        ]
    })
});
function AddRole(iRoleId) {
    $('#divAddUpdateRole').load('/Role/AddUpdateRole?iRoleId=' + iRoleId, function () {
        $.validator.unobtrusive.parse('#frmSaveRole');
    });
}

$(document).on('submit', '#frmSaveRolePermissions', function (e) {
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
                    $('#addUpdatelgModal').modal('hide');
                    alertify.success(res.Message);
                    $('#tblRole').DataTable().ajax.reload();
                    AddRole(0);
                }
                else {
                    alertify.error(res.Message);
                }
            }
        })
    }
});
$(document).on('submit', '#frmSaveRole', function (e) {
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
                    $('#tblRole').DataTable().ajax.reload();
                    AddRole(0);
                }
                else {
                    alertify.error(res.Message);
                }
            }
        })
    }
});


function AddUpdateRolePermissions(iRoleId) {
    $('#addUpdateModallgContainer').load('/Role/AddUpdateRolePermissions?iRoleId=' + iRoleId, function () {
        $('#addUpdatelgModal').modal('show');
        $.validator.unobtrusive.parse('#frmSaveRolePermissions');
    });
}


$(document).on('click', ".expandol", function () {
    $(this).toggle();
    $(this).next().toggle();
    $(this).parent().parent().children().last().toggle();
});

$(document).on('click', ".collapseol", function () {
    $(this).toggle();
    $(this).prev().toggle();
    $(this).parent().parent().children().last().toggle();
});

$(document).on('click', 'a .parent', function () {
    if ($(this).is(':checked')) {
        $(this).parent('a').next('ul').children('li').each(function () {
            $(this).find('a input[type="checkbox"]').prop('checked', true);
        });
    }
    else {
        $(this).parent('a').next('ul').children('li').each(function () {
            $(this).find('a input[type="checkbox"]:not(:disabled)').prop('checked', false);
        });
    }
});
