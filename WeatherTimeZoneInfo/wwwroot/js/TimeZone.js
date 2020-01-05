$(document).ready(function () {
    $(".only-numeric").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode

        if (event.keyCode == 13) {
            $("#btGetInfo").click();
        }
        else
        {

            if (!(keyCode >= 48 && keyCode <= 57)) {
                $(".error").css("display", "inline");
                $("#btGetInfo").css("display", "none");

                return false;
            } else {
                $(".error").css("display", "none");
                $("#btGetInfo").css("display", "inline");
            }
        }
    });
});