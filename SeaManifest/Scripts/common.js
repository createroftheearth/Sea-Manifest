

//$(function () {

//    //Initialize Select2 Elements
//    $('.select2').select2()

//    $('input').iCheck({
//        checkboxClass: 'icheckbox_square-blue',
//        radioClass: 'iradio_square-blue',
//        increaseArea: '20%' // optional
//    });
//});

function DisableButton(buttonName, status) {
    document.getElementById(buttonName).disabled = status;
}

//var specialKeys = new Array();
//specialKeys.push(8); //Backspace
//function IsNumeric(e) {
//    var keyCode = e.which ? e.which : e.keyCode
//    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
//    if (ret == false)
//        return false;
//}

//function ValidateEmail(email) {
//    var expr = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
//    return expr.test(email);
//}

//function isAlphanumeric(name) {
//    var pattern = /^[a-zA-Z0-9\s]+$/;
//    return pattern.test(name);
//}


////Jquery Validation Methods
//$.validator.addMethod("isAlphanumeric", function (value, element) {
//    var pattern = /^[a-zA-Z0-9\s]+$/;
//    return this.optional(element) || pattern.test(value);
//}, "* contains letters,numbers and underscore only");

//$.validator.addMethod("isValidEmailAddress", function (value, element) {
//    var pattern = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
//    return this.optional(element) || pattern.test(value);
//}, "* enter a valid email id");


//$.validator.addMethod("isNumeric", function (value, element) {
//    var pattern = /^[0-9]+$/i;
//    return this.optional(element) || pattern.test(value);
//}, "* contains numbers only");


//$.validator.addMethod("isSelect", function (value, element) {
//    return this.optional(element) || (value == null || value == "");
//}, "* contains numbers only");
