$(document).ready(function () {
    $(document).on('removeFromCart', function () {
        $.ajax({
            url: "Cart/BodySummary",
            type: "GET",
            success: function (res) {
                $('.body-summary').html(res);
            }
        })
    })
})