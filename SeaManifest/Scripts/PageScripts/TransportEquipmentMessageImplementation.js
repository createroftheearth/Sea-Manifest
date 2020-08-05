$(function () {
    initTransportEquipmentMessageImplementations();
});

var TransportEquipmentMessageImplementationTable;

function initTransportEquipmentMessageImplementations() {
    TransportEquipmentMessageImplementationTable = $('#tblTransportEquipmentMessageImplementation').DataTable({
        "searching": true,
        "ordering": false,
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "bLengthChange": false,
        "filter": true,
        "ajax": {
            "url": "/TransportEquipmentMessageImplementation/GetTransportEquipmentMessageImplementation",
            "type": "POST",
        },
        "columns": [
            {
                "data": "iEquipmentSequenceNo",
            },
            {
                "data": "sEquipmentId"
            },
            {
                "data": "sEquipmentType",
            },
            {
                "data": "sEquipmentSize",
            },
            {
                "data": "sEquipmentLoadStatus",
            },
            {
                "data": "sAdditionalEquipmentHold",
            },
            {
                "data": "sEventDate",
            },
            {
                "data": "sEquipmentSealType",
            },
            {
                "data": "sEquipmentSealNo",
            },
            {
                "data": "sOtherEquipmentId",
            },
            {
                "data": "sSOCFlag",
            },
            {
                "data": "sContainerAgentCode",
            },
            {
                "data": "dContainerWeight",
            },
            {
                "data": "dTotalNoOfPackages",
            },
            {
                "data": "iVoyageTransportId", "mRender": function (data) {
                    return "<button type=\"button\" class=\"btn btn-warning btn-xs\" onClick=\"AddUpdateTransportEquipmentMessageImplementation(" + data + ")\"><i class=\"fa fa-edit\"></i> Edit</button> ";
                }
            },
        ]
    });
}

function AddUpdateTransportEquipmentMessageImplementation(iTransportEquipmentMessageImplementationId) {
    $('#addUpdateModallgContainer').load('/TransportEquipmentMessageImplementation/AddUpdateTransportEquipmentMessageImplementation?iTransporterEquipmentId=' + iTransportEquipmentMessageImplementationId, function () {
        initAddUpdateTransportEquipmentMessageImplementation();
    });
}

function initAddUpdateTransportEquipmentMessageImplementation() {
    $.validator.unobtrusive.parse('#frmTransportEquipmentMessageImplementation');
    $('#frmTransportEquipmentMessageImplementation select').selectpicker();
    $('#psEventDate').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    changeReportingEvent();
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


$(document).on('submit', '#frmTransportEquipmentMessageImplementation', function (e) {
    e.preventDefault();
    if ($(this).valid() && checkTransportEquipments())
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.Status) {
                    alertify.success(response.Message);
                    TransportEquipmentMessageImplementationTable.ajax.reload();
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

function checkTransportEquipments() {
    var returnValue = true;
    var validator = $("#frmTransportEquipmentMessageImplementation").validate();
    var data = $('#sReportingEvent').val();
    if (data !== "SAA") {
        if ($('#iEquipmentSequenceNo').val() == "") {
            validator.showErrors({
                "iEquipmentSequenceNo": "Equipment Sequence No. is a required field."
            });
            $('#iEquipmentSequenceNo').focus();
            returnValue = false;
        }
        if ($('#sEquipmentId').val() == "") {
            validator.showErrors({
                "sEquipmentId": "Equipment Id is a required field."
            });
            $('#sEquipmentId').focus();
            returnValue = false;
        }
        if ($('#sEquipmentType').val() == "") {
            validator.showErrors({
                "sEquipmentType": "Equipment Type is a required field."
            });
            $('#sEquipmentType').focus();
            returnValue = false;
        }
        if ($('#sEquipmentLoadStatus').val() == "") {
            validator.showErrors({
                "sEquipmentLoadStatus": "Equipment Load Status is a required field."
            });
            $('#sEquipmentLoadStatus').focus();
            returnValue = false;
        }
        if ($('#sSOCFlag').val() == "") {
            validator.showErrors({
                "sSOCFlag": "SOC Flag is a required field."
            });
            $('#sSOCFlag').focus();
            returnValue = false;
        }
    }
    return returnValue;
}

function changeReportingEvent() {
    var reportingEvent = $('#sReportingEvent').val();
    if (reportingEvent == "SAA") {
        $('#sFinalLocation').parent('div').show();
        $('#sEventDate').parent('div').parent('div').show();
        $('#sEquipmentStatus').parent('div').show();
        $('#sStoragePositionCoded').parent('div').show();
    }
    else {
        $('#sFinalLocation').parent('div').hide();
        $('#sEventDate').parent('div').parent('div').hide();
        $('#sEquipmentStatus').parent('div').hide();
        $('#sStoragePositionCoded').parent('div').hide();
    }
}