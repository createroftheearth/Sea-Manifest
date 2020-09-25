$(function () {
    initSupportDocMessageImplementation();
});

var SupportDocMessageImplementationTable;

function initSupportDocMessageImplementation() {
    SupportDocMessageImplementationTable = $('#tblSupportDocMessageImplementation').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/SupportDocMessageImplementation/GetSupportDocMessageImplementation",
            "type": "POST",
        },
        "columns": [
            {
                "data": "sTagRef",
            },
            {
                "data": "sRefSerialNo"
            },
            {
                "data": "sSubSerialNoRef",
            },
            {
                "data": "sIcegateUserId",
            },
            {
                "data": "sIRNNo",
            },
            {
                "data": "sDocRefNo",
            },
            {
                "data": "sDocTypeCd",
            },
            {
                "data": "sBeneficiaryCd",
            },
            {
                "data": "iSupportDocsId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs not-hide\" onClick=\"AddUpdateSupportDocMessageImplementation(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdateSupportDocMessageImplementation(iSupportDocMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/SupportDocMessageImplementation/AddUpdateSupportDocMessageImplementation?iSupportDocsId=' + iSupportDocMessageImplementationId, function () {
        initAddUpdateSupportDocMessageImplementation();
    });
}

function initAddUpdateSupportDocMessageImplementation() {
    $.validator.unobtrusive.parse('#frmSupportDocMessageImplementation');
    $('#frmSupportDocMessageImplementation select').selectpicker();
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


$(document).on('submit', '#frmSupportDocMessageImplementation', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkSupportDocs())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    SupportDocMessageImplementationTable.ajax.reload();
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
    var validator = $("#frmSupportDocMessageImplementation").validate();
    var data = $('#sReportingEvent').val();
    if (data !== "SAA") {
        if ($('#sTagRef').val() == "") {
            validator.showErrors({
                "sTagRef": "Tag Ref is a required field."
            });
            $('#sTagRef').focus();
            returnValue = false;
        }
        if ($('#sRefSerialNo').val() == "") {
            validator.showErrors({
                "sRefSerialNo": "Ref Serial No. is a required field."
            });
            $('#sRefSerialNo').focus();
            returnValue = false;
        }
        if ($('#sSubSerialNoRef').val() == "") {
            validator.showErrors({
                "sSubSerialNoRef": "Sub Serial No. Ref is a required field."
            });
            $('#sSubSerialNoRef').focus();
            returnValue = false;
        }
        if ($('#sIcegateUserId').val() == "") {
            validator.showErrors({
                "sIcegateUserId": "Ice gate User Id is a required field."
            });
            $('#sIcegateUserId').focus();
            returnValue = false;
        }
        if ($('#sIRNNo').val() == "") {
            validator.showErrors({
                "sIRNNo": "IRN No is a required field."
            });
            $('#sIRNNo').focus();
            returnValue = false;
        }
        if ($('#sDocRefNo').val() == "") {
            validator.showErrors({
                "sDocRefNo": "Doc Ref No is a required field."
            });
            $('#sDocRefNo').focus();
            returnValue = false;
        }
        if ($('#sDocTypeCd').val() == "") {
            validator.showErrors({
                "sDocTypeCd": "Doc Type Code is a required field."
            });
            $('#sDocTypeCd').focus();
            returnValue = false;
        }
        if ($('#sBeneficiaryCd').val() == "") {
            validator.showErrors({
                "sBeneficiaryCd": "Benificiary Code is a required field."
            });
            $('#sBeneficiaryCd').focus();
            returnValue = false;
        }
    }
    return returnValue;
}
