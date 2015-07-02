$(function () {
    var AjaxShowStudentList = function () {
        var target = $(this).attr("href");
        var options = {
            type: "GET",
            url:target
        }
        $.ajax(options).done(function (data) {
            if ($(".StudentSection div") != null) {
                console.log("found target!");
            }
            $("#StudentSection").html(data);
            console.log("done!");
        });
        console.log("bingo!!!!!")
        return false;
    }
    $(".body-content").on("click", ".CourseName a", AjaxShowStudentList);
});