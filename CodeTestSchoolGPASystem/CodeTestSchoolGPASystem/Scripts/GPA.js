$(function () {
    var ajaxShowStudentList = function () {
        console.log("ajaxShowStudentList");
    };
    //$(".ShowStudentList a").click(ajaxShowStudentList);
    $(".main-content").on("click", ".ShowStudentList a", ajaxShowStudentList);
});