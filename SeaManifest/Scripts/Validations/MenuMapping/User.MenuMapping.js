$(document).ready(function () {
    UserMenuMapping();
});

$("#SelectedUserId").change(function () {
    var userId = $("#SelectedUserId").val();
    var roleId= $("#RoleId").val();    
    var appID = $("#AppId").val();
    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ roleId: roleId, appID: appID, UserId: userId }),
        url: '/ManageUser/MenuBindUser',
        success: function (result) {
            if (result != null) {
                $("#dvRaw").html('');
                $("#dvDdl").html(result.htmlString);
            }
        },
        error: function (obj) {
        }
    });
}).change();

$("#btnUserMenuSubmit").click(function () {
    document.getElementById("btnSubmit").disabled = true;
    $(".MapMenu").show();
    var roleId = $("#RoleId").val();
    var selectedUserId = $("#SelectedUserId").val();
    var appDetail;
    var flag = false;
    $('input:checkbox').each(function () {
        var sThisVal = (this.checked ? $(this).val() : "");
        if (this.id != 'IsSelectUser') {
            if (sThisVal == 'on') {
                if (appDetail != 'undefined') {
                    flag = true;
                    appDetail = appDetail + ',' + $(this).attr("id") + "_IsCheckedTrue";
                }
            }
            else {
                if (appDetail != 'undefined')
                    appDetail = appDetail + ',' + $(this).attr("id") + "_IsCheckedFalse";
            }
        }
    });
    if (flag == false) {
        alertify.error("Please select atleast one menu or submenu.");
        document.getElementById("btnSubmit").disabled = false;
        $(".MapMenu").hide();
        return false;
    }

    if (roleId == "" || roleId == null) {
        alertify.error("Please select role.");
        document.getElementById("btnSubmit").disabled = false;
        $(".MapMenu").hide();
        return false;
    }

    if (selectedUserId == "" || selectedUserId == null) {
        alertify.error("Please select UserId.");
        document.getElementById("btnSubmit").disabled = false;
        $(".MapMenu").hide();
        return false;
    }

    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ appDetail: appDetail, SelectedUserId: selectedUserId }),
        url: '/ManageUser/SaveUserMenuMapping',
        success: function (result) {
            if (result == true)
                alertify.success("Record added successfully");
            window.location.href = "/ManageUser/Index/";
        },
        error: function (obj) {
            alert("Error Ocurred while updating.");
        }
    });
});

$("#btnCancel").click(function () {
    window.location.href = "/ManageUser/Index/";
});

function UserMenuMapping() {
    var userId = $("#UserId").val();
    if (userId != "" && userId != null && userId > 0) {
        //$(".UserSelection").show();
        $("#btnUserMenuSubmit").show();
        $("#btnSubmit").hide();
        $("#RoleId").prop("disabled", true);
        $('select').select2();

    }
}