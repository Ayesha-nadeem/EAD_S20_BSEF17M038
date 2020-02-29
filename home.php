
<?php
session_start();
if(isset($_SESSION["useri"])==false)
{
    header('Location:signin.php');
}
?>
<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</head>
<body>
<input type="hidden" id="parentfolderID" value=0>
<div class="row m-0">
    <div class="col-2">

        <button type="button" class="btn btn-outline-success btn-lg mt-1" data-toggle="modal" data-target="#myModal">+ NEW</button>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">New Folder</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>

                    </div>
                    <div class="modal-body">
                        <input type="text" name="newFolderName" id="newfolname" onkeyup="Validation()" value="untitled folder">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">cancel</button>
                        <input type="submit" class="btn btn-primary" id="create"  data-dismiss="modal" value="create">
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="col-10">
        <div id="info"></div>
    </div>
</div>
<script>
    function ajaxRequest()
    {
        var i=$("#parentfolderID").val();
        var d={"action":"getchildfolders","pfid":i};
        var settings={
            type:"POST",
            dataType:"json",
            url:"api.php",
            data:d,

            success:function(response)
            {
                if(response.data[0]!=="") {
                    for (var i = 0; i < response.data.length; i++) {
                        var obj = response.data[i];
                        var folder=obj.foldername;
                        $("#info").append("<div style='display:inline-block' class='border rounder-sm folder w-25 p-3 m-1' ondblclick='fun(this)' onclick='selected(this)'>" + folder + "</div> <input type='hidden' id='f' value=" + obj.folderid + ">")
                    }
                }
            },
            error:function(err,type,httpStatus)
            {
                alert("error has occured");
            }
        };
        $.ajax(settings);
    }
    $(document).ready(function(){
        ajaxRequest();
        $("#create").click(function()
        {
            var n=$("#newfolname").val();
            var i=$("#parentfolderID").val();
            var d={"action":"create","newFolderName":n,"pfid":i};
            var settings={
                type:"GET",
                url:"api.php",
                data:d,

                success:function(response)
                {
                    $("#info").empty();
                    ajaxRequest();
                },
                error:function(err,type,httpStatus)
                {
                    alert("error has occured");
                }
            };
            $.ajax(settings);
        });

    });
    function fun(currentDiv) {
        var parentFolderID=currentDiv.nextElementSibling.value;
        $("#parentfolderID").val(parentFolderID);
        $("#info").empty();
        ajaxRequest();
    }
    function Validation()
    {
        var ele=$("#newfolname").val();
        document.getElementById("create").disabled = ele === '';
    }
    function selected(e)
    {
        $(e).css({"background-color":"#b8daff"});
        $(e).siblings().css({"background-color":"white"});
    }
</script>
</body>
</html>
