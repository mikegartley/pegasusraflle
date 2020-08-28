var form = $(".validation-wizard").show();

$(".validation-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Enter Platform"
    },
    onStepChanging: function (event, currentIndex, newIndex) {
        return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
    },
    onFinishing: function (event, currentIndex) {
        $(".preloader").fadeIn();

        return form.validate().settings.ignore = ":disabled", form.valid()
    },
    onFinished: function (event, currentIndex) {
        form.submit();
    }
}),

$(".validation-wizard").validate({
    ignore: "input[type=hidden]",
    errorClass: "text-danger small",
    successClass: "text-success",
    highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    },
    unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    },
    errorPlacement: function (error, element) {
        var placement = $(element).data('error');
        if (placement) {
            $(placement).fadeIn().append(error)
        } else {
            error.insertAfter(element);
        }
    },
    messages: {
        acceptTerms: {
            required: "By declining to accept the Terms, you will not be able to view or participate in this Event"
        },
        chkInterests: {
            required: "Please select at least 1 interest."
        }
    }
})