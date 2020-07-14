$(document).ready(function () {
    var $container = $("html,body");
    var $scrollTo;
    $scrollTo = $('.signin-form');
    $container.animate({
        scrollTop: $scrollTo.offset().top - 120,
        scrollLeft: 0
    }, 1000);
});