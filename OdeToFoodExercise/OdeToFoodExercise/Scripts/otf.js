﻿$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith(data);
        });
        return false;
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
});