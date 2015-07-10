$(function () {
    var options = {
        source: $("#autoComplete").attr("data-otf-action"),
        select: function (event, ui) {
            $(this).val(ui.item.value);//make sure the selected value will be populated in the input box.
            $("form[data-otf-ajax='true']").trigger("submit");
        }
    };
    $("#autoComplete").autocomplete(options);
});