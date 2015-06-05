$(function () {
    var ajaxGetStudentList = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            type: "get"
        };
        $.ajax(options).done(function (data) {
            $("#StudentList").html(data);
        });
        return false;
    };

    $(".main-content").on("click", ".CourseName a", ajaxGetStudentList);

});