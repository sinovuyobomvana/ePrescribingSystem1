$(document).ready(function ()
{

    var navListItems = $('div.setup-panel div a'), // tab nav items
        allWells = $('.setup-content'), // content div
        allNextBtn = $('.nextBtn'); // next button

        //allWells.hide(); // hide all contents by defauld

    navListItems.click(function (e)
    {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });
    // next button
    allNextBtn.click(function ()
    {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='email'],input[type='password'],input[type='url']"),
            isValid = true;
        // Validation
        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++)
        {
            if (!curInputs[i].validity.valid)
            {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }
        // move to next step if valid
        if (isValid)
            nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-primary').trigger('click');
});