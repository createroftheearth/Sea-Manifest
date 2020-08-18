$(function () {
    initItenaryHouseCargo();
});

var ItenaryHouseCargo;
function initItenaryHouseCargo() {
    ItenaryHouseCargo = $('#tblItenaryHouseCargo').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/ItineraryHouseCargo/GetItineraryHouseCargo",
            "type": "POST",
        },
        "columns": [
            {
                "data": "dPortOfCallSequenceNo",
            },
            {
                "data": "sPortOfCallCd"
            },
            {
                "data": "sPortOfCallName",
            },
            {
                "data": "sNextPortOfCallCdd",
            },
            {
                "data": "sNextPortOfCallName",
            },
            {
                "data": "sModeOfTransport",
            },
            {
                "data": "iItineraryId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateItineraryHouseCargo(" + data + ")\"><i class=\"fa fa-edit\"></i></button> ";
                        
                }
            },
        ]
    });
}

function resetForm() {
    var $form = $("form");

    // get validator object
    var $validator = $form.validate();

    // get errors that were created using jQuery.validate.unobtrusive
    var $errors = $form.find(".field-validation-error span");

    // trick unobtrusive to think the elements were succesfully validated
    // this removes the validation HouseCargo
    //$errors.each(function () { $validator.settings.success($(this)); })

    // clear errors from validation
    $validator.resetForm();
}


function AddUpdateItineraryHouseCargo(iItenaryHouseCargoId) {
    $('#addUpdateModallgContainer').load('/ItineraryHouseCargo/AddUpdateItineraryHouseCargo?iItenaryHouseCargoId=' + iItenaryHouseCargoId, function () {
        initAddUpdateItenaryHouseCargo();
    });
}

function initAddUpdateItenaryHouseCargo() {
    $.validator.unobtrusive.parse('#frmItineraryHouseCargo');
    $('#frmItineraryHouseCargo select').selectpicker();
    $('#addUpdatelgModal').modal('show');
}

$(document).on('submit', '#frmItineraryHouseCargo', function (e) {
    e.preventDefault();
    if ($(this).valid())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    ItenaryHouseCargo.ajax.reload();
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


