$(function () {
    var ajaxShowStudentList = function () {

        var settings = {
            type: "GET",
            url: $(this).attr("href")
        }
        $.ajax(settings).done(function (data) {
            $("#StudentSection").html(data);
        }).fail(function(){
            alert("failed to get ajax data");
        });
        console.log("clickHandlerFunction hitted");
        return false;
    };
    //$(".ShowStudentList a").click(ajaxShowStudentList);
    $(".main-content").on("click", ".ShowStudentList a", ajaxShowStudentList);
});