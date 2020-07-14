$(document).ready(function () {
    $(".UserSelection").hide();
    $("#btnUserMenuSubmit").hide();
});

$("#RoleId").change(function () {
    var roleId;
    var selsectedUserLevelId = $("#RoleId").val();
    if (selsectedUserLevelId == 0)
        roleId = $("#RoleId").val();
    else
        roleId = selsectedUserLevelId;
    var appID = $("#AppId").val();
    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ roleId: roleId, appID: appID }),
        url: '/ManageUser/MenuBind',
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

$("#btnSubmit").click(function () {
    document.getElementById("btnSubmit").disabled = true;
    $(".MapMenu").show();
    var roleId = $("#RoleId").val();
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

    $.ajax({
        dataType: 'json',
        type: 'Post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ appDetail: appDetail, roleId: roleId }),
        url: '/ManageUser/SaveMenuMapping',
        success: function (result) {
            if (result == true)
                alertify.success("Record added succssfully");
            window.location.href = "/ManageUser/ManageRoles/";
        },
        error: function (obj) {
            alert("Error Ocurred while updating.");
        }
    });
});

$("#btnCancel").click(function () {
    window.location.href = "/ManageUser/ManageRoles/";
});