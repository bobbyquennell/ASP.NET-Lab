$(function () {
    var ajaxShowStudentList = function () {

        var settings = {
            type: "GET",
            url: $(this).attr("href")
        }
        $.ajax(settings).done(function (data) {
            $("#StudentSection").html(data);
            $('td.GPA').each(function () {
                var gpa = parseFloat($(this).text());
                if (gpa >= 3.2) {
                    $(this).prev().prev().css("color", "red");
                }
            });
        }).fail(function (){
            alert("failed to get ajax data");
        });
        console.log("clickHandlerFunction hitted");
        return false;
    };
    //$(".ShowStudentList a").click(ajaxShowStudentList);
    $(".main-content").on("click", ".ShowStudentList a", ajaxShowStudentList);
});