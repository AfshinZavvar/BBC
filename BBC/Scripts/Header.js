$(document).ready(function () {
    var doEffect = function () {

        $("#menu > li").hover(function () {
            $(this).css("font-weight", "bold");
        },
            function () {
                $(this).css("font-weight", "normal");
            });
    };

    var setActive = function () {
        $(location).attr('href');
        var url = window.location + "";
        if (url.indexOf("Categories") > -1) {
            var arr = url.split("/");
            var category = arr[arr.length - 1];
            $("#menu >li").removeClass("active");
            $("#" + category).addClass("active");
        }
    };

    doEffect();
    setActive();
});