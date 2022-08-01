$(document).ready(function () {
    $('#lstCity').change(function () {
        var selectedCity = $('#lstCity').val();

        var suburbSelect = $('#lstSuburb');
        suburbSelect.empty();

        if (selectedCity != null && selectedCity != '') {
            $.getJSON('@Url.Action("GetSuburbs")', { CityID: selectedCity }, function (suburbs) {
                if (suburbs != null && !jQuery.isEmptyObject(suburbs)) {
                    suburbSelect.append($('<option/>', {
                        value: "",
                        text: "Select suburb..."
                    }));
                    /*  debugger;*/
                    $.each(suburbs, function (index, suburb) {
                        suburbSelect.append($('<option/>', {
                            value: suburb.value,
                            text: suburb.text
                        }));
                    });
                }
            });


        }
    })
})