$(document).ready(function () {
    var $container = $("html,body");
    var $scrollTo;
    $scrollTo = $('.register-ibox-content');
    $container.animate({
        scrollTop: $scrollTo.offset().top - 120,
        scrollLeft: 0
    }, 1000);
});


$(document).on('mouseenter', '.user-details > .text-center', function () {
    $('#ProfilePicture').css('opacity','0.2');
    $('.selectPhoto').show();
});
$(document).on('mouseleave', '.user-details > .text-center', function () {
    $('#ProfilePicture').css('opacity', '1');
    $('.selectPhoto').hide();
});

$(document).on('click', '.selectPhoto', function () {
    $('#profilePicture').click();
});

function ValidatePicture() {
    var formData = new FormData();
    var fileInput = document.getElementById('profilePicture');
    var file = fileInput.files[0];
    var fileType = file["type"];
    var ValidImageTypes = ["image/jpeg", "image/png"];
    if ($.inArray(fileType, ValidImageTypes) < 0) {
        alertify.error('Please select JPG/PNG image.');
        $('#profilePicture').val('');
        return;
    }
    var maxSize = 4;
    if (maxSize < fileInput.files[0].size / 1024 / 1024) {
        alertify.error('Please select image less than 5 MB.');
        $('#profilePicture').val('');
        return;
    }
    var reader = new FileReader();
    reader.onload = function (e) {
        $('#ProfilePicture').attr('src', e.target.result);
    }
    reader.readAsDataURL(file);
}