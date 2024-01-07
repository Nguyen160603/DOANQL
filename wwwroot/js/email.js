$(document).ready(function () {
    $("#submit").click(function (e) {
        e.preventDefault();
        var _name = $("#name").val();
        var _email = $("#email").val();
        var _message = $("#message").val();
        var _arivalDate = $("#arival_date").val(); // Update to match your input field ID
        var _departureDate = $("#departure_date").val(); // Update to match your input field ID
        var _chooseAdults = $("#chooseAdults").val(); // Update to match your select element ID
        var _chooseChildren = $("#chooseChildren").val(); // Update to match your select element ID

        $.ajax({
            url: "/Booking/Create",
            type: "POST",
            data: {
                name: _name,
                email: _email,
                adults: _chooseAdults,
                children: _chooseChildren,
                arivaldate: _arivalDate,
                departuredate: _departureDate,
                message: _message
            },
            success: function (result) {
                if (result.status) {
                    $("#name").val("");
                    $("#email").val("");
                    $("#message").val("");
                    $("#success").show();
                    $("#error").hide();
                } else {
                    $("#success").hide();
                    $("#error").show();
                }
            },
            error: function () {
                $("#success").hide();
                $("#error").show();
            }
        });
    });
});
