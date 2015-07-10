$(function () {
    var options = {
        source: $("#autoComplete").attr("data-otf-action"),
        select: function (event, ui) {
            $(this).val(ui.item.value);//make sure the selected value will be populated in the input box.
            $("form[data-otf-ajax='true']").trigger("submit");
        }
    };
    var ajaxGetResaurantList = function () {
        var options = {
            url: $("form[data-otf-ajax='true']").attr("action"),
            type: "get",
            data: $("#autoComplete").serialize()
        }
        $.ajax(options).done(function (data) {
            $("div.RestaurantListPartial").html(data).effect("highlight");
        });
        return false;
    }
    var ajaxPageListUpdate = function () {
        var options = {
            url: $(this).attr("href"),
            type: "get",
            data: $("#autoComplete").serialize()//send searchterm value to index method, otherwise, if we have 10 pages search result, then cannot display the next pages of search results.
        }
        $.ajax(options).done(function (data) {
            $("div.RestaurantListPartial").html(data).effect("highlight");
        });
        return false;
    }
    $("#autoComplete").autocomplete(options);
    //$("#ajaxTag").click(ajaxGetResaurantList);//way A: this will only trigger the ajax call when an user clicks the submit button but not the autocomplete way.
    $("form[data-otf-ajax='true']").submit(ajaxGetResaurantList);//better way: bind an event handler when the submit event 
    //is triggered.in this way, ajax search will be called either by clicking the submit button or selecting an autocomplete pop-up item.

    //$(".pagedList a").click(ajaxPageListUpdate);//method1: this method leads to a bug that only 1 out of 2 times clicking the next page will trige a ajax 
    //request, the other request is a http version, so the page will reload every two time, I don't know why
    $(".body-content").on("click", ".pagedList a", ajaxPageListUpdate);// method 2: fix the method1 bug.
});