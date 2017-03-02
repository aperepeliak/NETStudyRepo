$(() => {

    let ajaxFormSubmit = function() {
        let $form = $(this);

        let options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done((data) => {
            let $target = $($form.attr("data-otf-target"));
            let $newHtml = $(data);

            $target.replaceWith($newHtml);
            $newHtml.effect("highlight", {color: "pink"}, 400);
        });

        return false;
    };

    let submitAutocompleteForm = function (event, ui) {
        let $input = $(this);
        $input.val(ui.item.label);

        let $form = $input.parents("form:first");
        $form.submit();
    };

    let createAutocomplete = function () {
        let $input = $(this);

        let options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    let getPage = function () {
        let $a = $(this);

        let options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done((data) => {           
            let target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });

        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);

    $(".body-content").on("click", ".pagedList a", getPage);
});