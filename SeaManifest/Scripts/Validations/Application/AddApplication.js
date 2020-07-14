$(document).ready(function () {

    $(".SubmitApplication").hide();
});

$("#btnCancel").click(function () {
    window.location.href = '/ManageUser/ManageApplications/';
});

$("#btnApplicationSubmit").click(function () {
    ValidApplicationForm();
    var IsValid = $("#frm_application").valid();

    if (IsValid) {

        DisableButton("btnApplicationSubmit", true);
        $(".SubmitApplication").show();

        var appName = $('#AppName').val();
        var appDesc = $('#AppDesc').val();
        var hostIP = $('#HostIP').val();
        var publicHostIP = $('#PublicHostIP').val();

        $.ajax({
            dataType: 'json',
            type: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ AppName: appName, AppDesc: appDesc, HostIP: hostIP, PublicHostIP: publicHostIP }),
            url: "/ManageUser/SaveApplication",
            success: function (data) {
                if (data != null && data.message != null) {
                    if (data.responseCode == 200) { window.location.href = '/ManageUser/ManageApplications/'; }
                    else {
                        DisableButton("btnApplicationSubmit", false);
                        $(".SubmitApplication").hide();
                        alertify.error(data.message);
                    }
                }
                else {
                    alertify.error("Please try again later.");
                }
            },
            error: function (ajaxRequest, strError) {
                var respText = ajaxRequest.responseText;
            }
        });
    }
});