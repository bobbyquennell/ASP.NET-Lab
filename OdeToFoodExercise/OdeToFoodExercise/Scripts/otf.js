$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });
        return false;
    };
    var ajaxPageUpdate = function () {
        var $a = $(this);
        var options = {
        url: $a.attr("href"),
        type: "get"
        //data: $a.serialize() "get" method doesn't need to send data to server.
        };
        $.ajax(options).done(function(data){
            $("#restaurantList").replaceWith(data);
            //var target = $a.parents("div.pagedLlist").attr("data-otf-target");
            //$(target).replaceWith(data);
            });
        return false;// if we don't return false here, the HTTP get request will still send to server which will lead to redraw the page again.
            //to be more exactly, clicking "next page" one time will create two request to the server, one is http get request, the other 
                //is ajax get request sent from java script
    };
    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("#searchTag").autocomplete(
        {
            //source:[ "c++", "java", "php", "coldfusion", "javascript", "asp", "ruby" ]
            source: $("#searchTag").attr("data-otf-action"),
            select: function (event, ui) {
                $(this).val(ui.item.value);
                $("form[data-otf-ajax='true']").trigger("submit");
            }
            //minLength: 0
    });

    //$(".pagedList a").click(ajaxPageUpdate); //method1: this method leads to a bug that only 1 out of 2 times clicking the next page will trige a ajax 
    //request, the other request is a http version, so the page will reload every two time, I don't know why
    $(".main-content").on("click",".pagedList a", ajaxPageUpdate);// method 2: fix the method1 bug.
    
});