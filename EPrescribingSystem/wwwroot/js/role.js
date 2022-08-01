<head>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $("select").change(function () {
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
    </script>
</head>
