$(function() {

    $('#txtCpf').mask('000.000.000-00');

});

$(document).on("submit", function () {

    $.each(Page_Validators, function (i, v) {
        var strControlToValidateID = v.controltovalidate;
        var $controlToValidate = $("#" + strControlToValidateID);

        var arrInvalidControls = new Array();

        if (!v.isvalid) {
            $controlToValidate.addClass("error");

            arrInvalidControls.push(strControlToValidateID);

        } else {

            if (!$.inArray(strControlToValidateID, arrInvalidControls)) {
                $controlToValidate.removeClass("error");
            }
        }
    });
});
