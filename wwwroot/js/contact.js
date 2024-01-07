$(document).ready(function () {

    (function ($) {
        "use strict";


        jQuery.validator.addMethod('answercheck', function (value, element) {
            return this.optional(element) || /^\bcat\b$/.test(value)
        }, "type the correct answer -_-");

        $(document).ready(function () {
            $("#submit").click(function (e) {
                e.preventDefault();
                var _name = $("#name").val();
                var _email = $("#email").val();
                var _subject = $("#subject").val();
                var _message = $("#message").val();

                $.ajax({
                    url: "/Contact/Create",
                    type: "POST",
                    data: { name: _name, email: _email, subject: _subject, message: _message },
                    success: function (result) {
                        if (result != null) {
                            $("#name").val("");
                            $("#email").val("");
                            $("#subject").val("");
                            $("#message").val("");
                            $("#success").show();
                            $("#error").hide();
                        } else {
                            $("#success").hide();
                            $("#error").show();
                        }
                    },
                    error: function (result) {
                        console.log(result); // Log lỗi để kiểm tra
                        $("#success").hide();
                        $("#error").show();
                    }
                });
            });
        });
        // validate contactForm form
        $(function () {
            $('#contactForm').validate({
                rules: {
                    name: {
                        required: true,
                        minlength: 2
                    },
                    subject: {
                        required: true,
                        minlength: 2
                    },
                    email: {
                        required: true,
                        email: true
                    },
                    message: {
                        required: true,
                        minlength: 20
                    }
                },
                messages: {
                    name: {
                        required: "come on, you have a name, don't you?",
                        minlength: "your name must consist of at least 2 characters"
                    },
                    subject: {
                        required: "come on, you have a subject, don't you?",
                        minlength: "your name must consist of at least 2 characters"
                    },
                    email: {
                        required: "no email, no message"
                    },
                    message: {
                        required: "um...yea, you have to write something to send this form.",
                        minlength: "thats all? really?"
                    }
                },
                
            })
        })

    })(jQuery)
})