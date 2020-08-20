var PortTable;
$(function () {
    initPort();
});

function initPort() {
    PortTable = $('#tblPort').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/Port/GetPort",
            "type": "POST",
        },
        "columns": [
            {
                "data": "sCountryName",
            },
            {
                "data": "sStateName"
            },
            {
                "data": "sPortCode",
            },
            {
                "data": "sPortDescription",
            },
            {
                "data": "iPortId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdatePort(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdatePort(iPortId) {
    $('#addUpdateModallgContainer').load('/Port/AddUpdatePort?iPortId=' + iPortId, function () {
        initAddUpdatePort();
    });
}

function initAddUpdatePort() {
    $.validator.unobtrusive.parse('#frmPort');
    $('#frmPort select').selectpicker();
    changeCountryCode();
    $('#addUpdatelgModal').modal('show');
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

$(document).on('submit', '#frmPort', function (e) {
    e.preventDefault();
    if ($(this).valid())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    PortTable.ajax.reload();
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

$(document).on('change', '#sCountryCode', function () {
    changeCountryCode();
});


function changeCountryCode() {
    if ($('#sCountryCode').val() == "IN") {
       $('#SstateCode').selectpicker('refresh');
        $('#SstateCode').parent('div').parent('div').show();
    }
    else {
        $('#SstateCode').parent('div').parent('div').hide();
    }
}