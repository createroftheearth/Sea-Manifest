$(document).ready(function () {
    $(".MapMenu").hide();

    $(document).on('click', ".imgApp", function () {
        $(this).parents('fieldset:eq(0)').find('.dvMenu').toggle();
        $(this).toggleClass("menu-map-icn-minus");
        return false;
    });

    $(document).on('click', ".imgMenu", function () {
        $(this).parents('fieldset:eq(0)').find('.dvSubMenu').toggle();
        $(this).toggleClass("submenu-map-icn-minus");
        return false;
    });

    //clicking the parent checkbox should check or uncheck all child checkboxes
    $(document).on('click', ".chkMenuRead", function () {
        $(this).parents('fieldset:eq(0)').find('.chkSubMenuRead').prop('checked', this.checked);
    });

    //clicking the last unchecked or checked checkbox should check or uncheck the parent checkbox
    $(document).on('click', ".chkSubMenuRead", function () {
        if ($(this).parents('fieldset:eq(0)').find('.chkMenuRead').prop('checked') == true && this.checked == false)
            $(this).parents('fieldset:eq(0)').find('.chkMenuRead').prop('checked', false);
        if (this.checked == true) {
            var flag = true;
            $(this).parents('fieldset:eq(0)').find('.chkSubMenuRead').each(
                function () {
                    if (this.checked == false)
                        flag = false;
                }
            );
            $(this).parents('fieldset:eq(0)').find('.chkMenuRead').prop('checked', flag);
        }
    });

    //clicking the parent checkbox should check or uncheck all child checkboxes
    $(document).on('click', ".chkMenuWrite", function () {
        $(this).parents('fieldset:eq(0)').find('.chkSubMenuWrite').prop('checked', this.checked);
    });
    //clicking the last unchecked or checked checkbox should check or uncheck the parent checkbox
    $(document).on('click', ".chkSubMenuWrite", function () {
        if ($(this).parents('fieldset:eq(0)').find('.chkMenuWrite').prop('checked') == true && this.checked == false)
            $(this).parents('fieldset:eq(0)').find('.chkMenuWrite').prop('checked', false);
        if (this.checked == true) {
            var flag = true;
            $(this).parents('fieldset:eq(0)').find('.chkSubMenuWrite').each(
                function () {
                    if (this.checked == false)
                        flag = false;
                }
            );
            $(this).parents('fieldset:eq(0)').find('.chkMenuWrite').prop('checked', flag);
        }

    });

    //clicking the parent checkbox should check or uncheck all child checkboxes
    $(document).on('click', ".chkMenuModify", function () {
        $(this).parents('fieldset:eq(0)').find('.chkSubMenuModify').prop('checked', this.checked);
    });

    //clicking the last unchecked or checked checkbox should check or uncheck the parent checkbox
    $(document).on('click', ".chkSubMenuModify", function () {
        if ($(this).parents('fieldset:eq(0)').find('.chkMenuModify').prop('checked') == true && this.checked == false)
            $(this).parents('fieldset:eq(0)').find('.chkMenuModify').prop('checked', false);
        if (this.checked == true) {
            var flag = true;
            $(this).parents('fieldset:eq(0)').find('.chkSubMenuModify').each(
                function () {
                    if (this.checked == false)
                        flag = false;
                }
            );
            $(this).parents('fieldset:eq(0)').find('.chkMenuModify').prop('checked', flag);
        }

    });

    //clicking the parent checkbox should check or uncheck all child checkboxes
    $(document).on('click', ".chkMenuDelete", function () {
        $(this).parents('fieldset:eq(0)').find('.chkSubMenuDelete').prop('checked', this.checked);
    });

    //clicking the last unchecked or checked checkbox should check or uncheck the parent checkbox
    $(document).on('click', ".chkSubMenuDelete", function () {
        if ($(this).parents('fieldset:eq(0)').find('.chkMenuDelete').prop('checked') == true && this.checked == false)
            $(this).parents('fieldset:eq(0)').find('.chkMenuDelete').prop('checked', false);
        if (this.checked == true) {
            var flag = true;
            $(this).parents('fieldset:eq(0)').find('.chkSubMenuDelete').each(
                function () {
                    if (this.checked == false)
                        flag = false;
                }
            );
            $(this).parents('fieldset:eq(0)').find('.chkMenuDelete').prop('checked', flag);
        }

    });
});
