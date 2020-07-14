var ValidForgotPasswordForm = function () {

    $("#forgotpasswordform").validate({
        //== Validate only visible fields
        ignore: ":hidden",

        rules: {
            UserName: {
                required: true,
                minlength: 8,
                maxlength: 25
            },
        },
        messages: {
            UserName: {
                required: "Please enter Username.",
                minlength: "Username should contain atleast 8 characters.",
                maxlength: "Username should contain atleast 25 characters.",
            },
        },
    }).form();
}