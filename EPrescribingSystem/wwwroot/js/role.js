
        $(document).ready(function () {
            $("#role").change(function () {
                $(this).find("option:selected").each(function () {
                    var optionValue = $(this).attr("value");
                    if (optionValue) {
                        $("#pharm").not("." + optionValue).hide();
                        $("#doc").not("." + optionValue).hide();
                        $("#" + optionValue).show();
                    } else {
                        $(".box").show();
                    }
                });
            }).change();
        });


