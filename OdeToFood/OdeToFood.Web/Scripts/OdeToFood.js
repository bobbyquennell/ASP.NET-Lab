$(function () {
    var options = {
        source: $("#autoComplete").attr("data-otf-action"),
        select: function (event, ui) {
            $(this).val(ui.item.value);
            //$("form[data-otf-ajax='true']").trigger("submit");
        }
    };
    $("#autoComplete").autocomplete(options);
});