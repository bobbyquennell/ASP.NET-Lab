$(function () {
    var ajaxGetStudentList = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            type: "get"
        };
        $.ajax(options).done(function (data) {
            $("#StudentList").html(data);
            $("td.studentGpa").each(function (index) {
                if (parseFloat($(this).text()) >= 3.2) {
                    $(this).prev().prev().css('color', 'red');
                    console.log(index + "found High GPA!" + $(this).text());
                }
                
            });
        });
        return false;
    };

    $(".main-content").on("click", ".CourseName a", ajaxGetStudentList);


});