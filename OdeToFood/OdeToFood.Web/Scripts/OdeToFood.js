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
    $("#autoComplete").autocomplete(options);
    //$("#ajaxTag").click(ajaxGetResaurantList);//way A: this will only trigger the ajax call when an user clicks the submit button but not the autocomplete way.
    $("form[data-otf-ajax='true']").submit(ajaxGetResaurantList);//better way: bind an event handler when the submit event 
    //is triggered.in this way, ajax search will be called either by clicking the submit button or selecting an autocomplete pop-up item.

});