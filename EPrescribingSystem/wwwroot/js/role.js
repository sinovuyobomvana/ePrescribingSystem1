$(document).ready(function () {
    $("#roles").change(function () {
        $(this).find("option:selected").each(function () {
            var optionValue = $(this).attr("value");

            /*debugger;*/

            if (optionValue == "doc" || optionValue == "pharm") {
                $("#pharm").not("." + optionValue).hide();
                $("#doc").not("." + optionValue).hide();
                $("#" + optionValue).show();
            } else {
                $(".box").show();
            }
        });

    }).change();
});


