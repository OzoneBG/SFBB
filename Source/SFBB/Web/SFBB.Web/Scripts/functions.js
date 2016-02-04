/*$(document).ready(function () {
    $(".glyphicon").click(function () {
        if ($(this).hasClass("glyphicon-plus")) {
            $(this).removeClass("glyphicon-plus").addClass("glyphicon-minus");
        } else {
            $(this).removeClass("gliphycon-minus").addClass("glyphicon-plus");
        }
    });
});*/

$(".glyphicon").click(function () {
    $(this).toggleClass("glyphicon-chevron-up").toggleClass("glyphicon-chevron-down");
});