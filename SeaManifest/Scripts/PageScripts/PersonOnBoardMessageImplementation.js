$(function () {
    initPersonOnBoardMessageImplementation();
});

var PersonOnBoardMessageImplementationTable;

function initPersonOnBoardMessageImplementation() {
    PersonOnBoardMessageImplementationTable = $('#tblPersonOnBoardMessageImplementation').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/PersonOnBoardMessageImplementation/GetPersonOnBoardMessageImplementation",
            "type": "POST",
        },
        "columns": [
            {
                "data": "dPersonOnBaordSeqNo",
            },
            {
                "data": "sPersonDetailsPersonTypeCdd"
            },
            {
                "data": "sPersonDetailsPersonFamilyName",
            },
            {
                "data": "sPersonDetailsPersonGivenName",
            },
            {
                "data": "sPersonDetailsPersonNationalityCdd",
            },
            {
                "data": "dPersonDetailsPassengersInTransitIndicator",
            },
            {
                "data": "sPersonDetailsPersonGenderCdd",
            },
            {
                "data": "dtPersonDetailsPersonDateOfBirth",
            },
            {
                "data": "sPersonDetailsPersonPlaceOfBirthName",
            },
            {
                "data": "sPersonDetailsPersonCountryOfBirthCdd",
            },
            {
                "data": "dtPersonIdDocExpiryDate",
            },
            {
                "data": "sPersonIdOrTravelDocIssuingNationCdd",
            },
            {
                "data": "sPersonIdOrTravelDocNo",
            },
            {
                "data": "sPersonIdOrTravelDocTypeCdd",
            },
            {
                "data": "sVisaDetailsPersonVisa",
            },
            {
                "data": "sVisaDetailsPNRNo",
            },
            {
                "data": "iPersonOnBoardId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdatePersonOnBoardMessageImplementation(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdatePersonOnBoardMessageImplementation(iPersonOnBoardMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/PersonOnBoardMessageImplementation/AddUpdatePersonOnBoardMessageImplementation?iPersonOnBoardId=' + iPersonOnBoardMessageImplementationId, function () {
        initAddUpdatePersonOnBoardMessageImplementation();
    });
}

function initAddUpdatePersonOnBoardMessageImplementation() {
    $.validator.unobtrusive.parse('#frmPersonOnBoardMessageImplementation');
    $('#frmPersonOnBoardMessageImplementation select').selectpicker();
    $('#addUpdatelgModal').modal('show');
    $('#psdtPersonDetailsPersonDateOfBirth').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('#psdtPersonIdDocExpiryDate').datetimepicker({
        format: 'DD/MM/YYYY'
    });
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


$(document).on('submit', '#frmPersonOnBoardMessageImplementation', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkFormPersonOnBoard())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    PersonOnBoardMessageImplementationTable.ajax.reload();
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




function checkFormPersonOnBoard() {
    var validator = $("#frmPersonOnBoardMessageImplementation").validate();
    var data = $('#sReportingEvent').val();
    var returnValue = true;
    if ((data == "SAM")) {
        if ($('#dtPersonIdDocExpiryDate').val() == "") {
            validator.showErrors({
                "dtPersonIdDocExpiryDate": "PersonId Doc Expiry Date is a required field."
            });
            $('#dtPersonIdDocExpiryDate').focus();
            returnValue = false;
        }
        if ($('#sPersonIdOrTravelDocIssuingNationCdd').val() == "") {
            validator.showErrors({
                "sPersonIdOrTravelDocIssuingNationCdd": "PersonId Or Travel Doc Issuing NationCdd is a required field."
            });
            $('#sPersonIdOrTravelDocIssuingNationCdd').focus();
            returnValue = false;
        }
        if ($('#sPersonIdOrTravelDocNo').val() == "") {
            validator.showErrors({
                "sPersonIdOrTravelDocNo": "PersonId Or Travel DocNo is a required field."
            });
            $('#sPersonIdOrTravelDocNo').focus();
            returnValue = false;
        }
        if ($('#sPersonIdOrTravelDocTypeCdd').val() == "") {
            validator.showErrors({
                "sPersonIdOrTravelDocTypeCdd": "PersonId Or Travel Doc Type Cdd is a required field."
            });
            $('#sPersonIdOrTravelDocTypeCdd').focus();
            returnValue = false;
        }
    }
    return returnValue;
}


//function checkSupportDocs() {
//    var returnValue = true;
//    var validator = $("#frmPersonOnBoardMessageImplementation").validate();
//    var data = $('#sReportingEvent').val();
//    if (data !== "SAA") {
//        if ($('#sTagRef').val() == "") {
//            validator.showErrors({
//                "sTagRef": "Tag Ref is a required field."
//            });
//            $('#sTagRef').focus();
//            returnValue = false;
//        }
//        if ($('#sRefSerialNo').val() == "") {
//            validator.showErrors({
//                "sRefSerialNo": "Ref Serial No. is a required field."
//            });
//            $('#sRefSerialNo').focus();
//            returnValue = false;
//        }
//        if ($('#sSubSerialNoRef').val() == "") {
//            validator.showErrors({
//                "sSubSerialNoRef": "Sub Serial No. Ref is a required field."
//            });
//            $('#sSubSerialNoRef').focus();
//            returnValue = false;
//        }
//        if ($('#sIcegateUserId').val() == "") {
//            validator.showErrors({
//                "sIcegateUserId": "Ice gate User Id is a required field."
//            });
//            $('#sIcegateUserId').focus();
//            returnValue = false;
//        }
//        if ($('#sIRNNo').val() == "") {
//            validator.showErrors({
//                "sIRNNo": "IRN No is a required field."
//            });
//            $('#sIRNNo').focus();
//            returnValue = false;
//        }
//        if ($('#sDocRefNo').val() == "") {
//            validator.showErrors({
//                "sDocRefNo": "Doc Ref No is a required field."
//            });
//            $('#sDocRefNo').focus();
//            returnValue = false;
//        }
//        if ($('#sDocTypeCd').val() == "") {
//            validator.showErrors({
//                "sDocTypeCd": "Doc Type Code is a required field."
//            });
//            $('#sDocTypeCd').focus();
//            returnValue = false;
//        }
//        if ($('#sBeneficiaryCd').val() == "") {
//            validator.showErrors({
//                "sBeneficiaryCd": "Benificiary Code is a required field."
//            });
//            $('#sBeneficiaryCd').focus();
//            returnValue = false;
//        }
//    }
//    return returnValue;
//}
