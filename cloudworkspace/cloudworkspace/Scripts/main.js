
$(document).on('click', '.side-nav li', function () {
    $(".side-nav li").removeClass("active");
    $(this).addClass("active");
});