$(function () {
    initAmendmentDetailsMessageImplementation();
});

var AmendmentDetailsMessageImplementationTable;

function initAmendmentDetailsMessageImplementation() {
    AmendmentDetailsMessageImplementationTable = $('#tblAmendmentDetailsMessageImplementation').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/AmendmentDetailsMessageImplementation/GetAmendmentDetailsMessageImplementation",
            "type": "POST",
        },
        "columns": [
            {
                "data": "sAmendRefNo",
            },
            {
                "data": "sAmendFlag"
            },
            {
                "data": "sAmendType",
            },
            {
                "data": "iAmendmentId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs not-hide\" onClick=\"AddUpdateAmendmentDetailsMessageImplementation(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdateAmendmentDetailsMessageImplementation(iAmendmentDetailsMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/AmendmentDetailsMessageImplementation/AddUpdateAmendmentDetailsMessageImplementation?iAmendmentId=' + iAmendmentDetailsMessageImplementationId, function () {
        initAddUpdateAmendmentDetailsMessageImplementation();
    });
}

function initAddUpdateAmendmentDetailsMessageImplementation() {
    $.validator.unobtrusive.parse('#frmAmendmentDetailsMessageImplementation');
    $('#frmAmendmentDetailsMessageImplementation select').selectpicker();
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


$(document).on('submit', '#frmAmendmentDetailsMessageImplementation', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkSupportDocs())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    AmendmentDetailsMessageImplementationTable.ajax.reload();
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

function checkSupportDocs() {
    var returnValue = true;
    var validator = $("#frmAmendmentDetailsMessageImplementation").validate();
    var data = $('#sReportingEvent').val();
    if (data !== "SAA") {
        if ($('#sAmendRefNo').val() == "") {
            validator.showErrors({
                "sAmendRefNo": "Amendment Ref No. is a required field."
            });
            $('#sAmendRefNo').focus();
            returnValue = false;
        }
        if ($('#sAmendFlag').val() == "") {
            validator.showErrors({
                "sAmendFlag": "Amendment Flag is a required field."
            });
            $('#sAmendFlag').focus();
            returnValue = false;
        }
        if ($('#sAmendType').val() == "") {
            validator.showErrors({
                "sAmendType": "Amendment Type is a required field."
            });
            $('#sAmendType').focus();
            returnValue = false;
        }
    }
    return returnValue;
}
