
var ValidApplicationForm = function () {

    $("#frm_application").validate({
        //== Validate only visible fields
        ignore: ":hidden",

        rules: {
            AppName: {
                required: true,
                isAlphanumeric: true
            }
        },
        messages: {
            AppName: {
                required: "Please enter your Application Name.",
                isAlphanumeric: "Application Name contains letters,numbers and underscore only.",
            }
        },
    }).form();
}