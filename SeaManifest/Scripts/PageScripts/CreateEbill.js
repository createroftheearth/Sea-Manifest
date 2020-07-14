/* globals Stepper:false */
function StepperSteps() {
    $.validator.unobtrusive.parse("#frmEbillCreate");
    var stepperFormEl = document.querySelector('#stepperForm');
    window.stepperForm = new Stepper(stepperFormEl, {
        animation: true,
    });
}

$(document).on('click', '.btn-next-form', function () {
    GetPartialView($(this).parent('.bs-stepper-pane'), this);
});

$(document).on('click', '.btn-previous-form', function () {
    window.stepperForm.previous();
});


function GetPartialView(stepperPane, btn) {
    $(stepperPane).find('input:not(.IsValid),select:not(.IsValid)').each(function (i, ele) {
        $(ele).valid();
    });
    if ($(stepperPane).find('input:not(.IsValid),select:not(.IsValid)').valid()) {
        var target = $('.step.active').attr('data-target');
        if (target === "#billFrom" && !checkFromGSTIN())
            return;
        else if (target == '#billTo' && !checkToGSTIN())
            return;
        window.stepperForm.next();
        initPane();
    }
}
