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
        }).then(function () {
            $("td.gpa").each(function () {
                if (parseFloat($(this).html()) >= 3.2) {
                    $(this).prev().prev().css("color", "red");
                }
            });
        });
        return false;
    }
    $(".body-content").on("click", ".CourseName a", AjaxShowStudentList);
});