


var userManager = (function () {
    return {
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



