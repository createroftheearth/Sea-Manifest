
var ValidRoleForm = function () {

    $("#frm_role").validate({
        //== Validate only visible fields
        ignore: ":hidden",

        rules: {
            RName: {
                required: true,
                isAlphanumeric: true
            }
        },
        messages: {
            RName: {
                required: "Please enter your Application Name.",
                isAlphanumeric: "Application Name contains letters,numbers and underscore only.",
            }
        },
    }).form();
}