var userManager = (function () {
    return {
        validateUser: function (d) {
            var settings = {
                type: "POST",
                dataType: "json",
                url: '/User/ValidateUser',
                data: d,
                success: function (resp) {
                    if (resp.empty == true) {
                        $("#error").html("all fields required");
                    }
                    else if (resp.valid == true) {
                        location.href = resp.urlToRedirect;
                    }
                    else {
                        $("#error").html("Invalid Login/Password");
                    }
                },
                error: function (e) {
                    $("#error").html("something went wrong");
                }
            };
            $.ajax(settings);
        },
        save: function (d) {
            var settings = {
                type: "POST",
                dataType: "json",
                url: '/User/save',
                data: d,
                success: function (resp) {
                    if (resp.empty == true) {
                        $("#cpassSpan").html("all fields required");
                    }
                    else if (resp.valid == true) {
                        location.href = resp.urlToRedirect;
                    }
                    else {
                        $("#cpassSpan").html("Login already exist!");
                    }
                },
                error: function (e) {
                    $("#cpassSpan").html("error!");
                }
            };
            $.ajax(settings);
        }
    };
}())



