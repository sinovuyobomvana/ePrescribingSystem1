$(document).ready(function (){

    $('#buttonClick').click(function () {

        $(".overlay,.popup").fadeIn();

        CallAPI();


    });

    function LoadingBar () {

        $("Fade_area").removeAttr("style");
        $("#myModal").removeAttr("style");
    }

    function CallAPI() {
        debugger;
        $.ajax({

            url: "",
            type: 'post',
            contentType: function () {
                setTimeout(function () { LoadingBar() }, 200);
            },
            error: function () {

                setTimeout(function () { LoadingBar() }, 200);
            }

        });
    }

});