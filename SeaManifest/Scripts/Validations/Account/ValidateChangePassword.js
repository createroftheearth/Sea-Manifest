
var ValidChangePasswordForm = function () {

    $("#form_ChangePassword").validate({
        //== Validate only visible fields
        ignore: ":hidden",

        rules: {
            OldPassword: {
                required: true,
                minlength: 8,
                maxlength: 25
            },
            Password: {
                required: true,
                minlength: 8,
                maxlength: 25
            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                maxlength: 25,
                equalTo: "#Password"
            },
        },
        messages: {
            OldPassword: {
                required: "Please enter your Old Password.",
                minlength: "Old Password should contain atleast 8 characters.",
                maxlength: "Old Password contain maximum 25 characters.",
            },
            Password: {
                required: "Please enter your Password.",
                minlength: "Password should contain atleast 8 characters.",
                maxlength: "Password contain maximum 25 characters.",
            },
            ConfirmPassword: {
                required: "Please enter your Confirm Password.",
                minlength: "Password should contain atleast 8 characters.",
                maxlength: "Password contain maximum 25 characters.",
                equalTo: "Password not matched."
            },
        },
    }).form();
}