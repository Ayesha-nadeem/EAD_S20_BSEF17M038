
var folderManager = (function () {
    return {
        getChildFolders: function (d) {
            var settings = {
                type: "GET",
                dataType: "json",
                url:'/User/GetChildFolders',
                data: d,

                success: function (r) {
                    if (r.response[0] !== "") {
                        var len = r.response.length;
                        for (var i = 0; i < r.response.length; i++) {
                            var obj = r.response[i];
                            var folder = obj.FolderName;
                            $("#info").append("<div style='display:inline-block' class='border rounder-sm folder w-25 p-2 m-1' ondblclick='fun(this)' onclick='selected(this)'>" + folder + "</div> <input type='hidden' id='f' value=" + obj.FolderID + ">")
                        }
                    }
                },
                error: function (err, type, httpStatus) {
                    alert("error has occured");
                }
            };
            $.ajax(settings);
        },
        create: function (d) {
            var settings = {
                type: "GET",
                url:'/User/Create',
                data: d,

                success: function (response) {
                    if (response.empty == true && response.valid == false) {
                        alert("invalid folder name");
                    }
                    else if (response.valid == true && response.empty == false) {
                        $("#info").empty();
                        $("#newfolname").val("untitled folder");
                        ajaxRequest();
                    }
                },
                error: function (err, type, httpStatus) {
                    alert("error has occured");
                }
            };
            $.ajax(settings);
        },
        fun: function (currentDiv) {
            var parentFolderID = currentDiv.nextElementSibling.value;
            $("#parentfolderID").val(parentFolderID);
            $("#info").empty();
            ajaxRequest();
        },
        Validation: function () {
            var ele = $("#newfolname").val();
            document.getElementById("create").disabled = ele === '';
        },
        selected: function (e) {
            $(e).css({ "background-color": "#b8daff" });
            $(e).siblings().css({ "background-color": "white" });
        }
    };
}())