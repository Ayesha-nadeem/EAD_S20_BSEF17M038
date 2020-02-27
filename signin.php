<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</head>
<body>

<!--<form action="signin.php">-->
<div class="form-group">
    <label for="user"> Name:</label>
    <input type="text" name="user" id="user" class="form-control w-25" placeholder="enter name"/><span style="color:red" id="userspan"></span>
</div>
<div class="form-group">
    <label for="password">Password:</label>
    <input type="password" name="pass" id="password" class="form-control w-25" placeholder="enter password"/><span style="color:red" id="passspan"></span>
    <span style="color:red" id="invalidmsg"></span>
</div>
    <input type="submit" class="btn btn-outline-dark" name="submit" value="submit" id="submit"/>
    <a href="1.php" class="btn btn-outline-dark">register</a>
<!--</form>-->
<script>
    $(document).ready(function(){
        $("#submit").click(function()
        {
            var n=$("#user").val();
            var i=$("#password").val();
            if(n==="" && i==="")
            {
                $("#userspan").html("required");
                $("#passspan").html("required");
            }
            else if(n==="")
            {
                $("#passspan").html("");
                $("#userspan").html("required");
            }
            else if(i==="")
            {
                $("#userspan").html("");
                $("#passspan").html("required");
            }
            else
            {
                $("#passspan").html("");
                $("#userspan").html("");
            var d={"action":"signin","user":n,"pass":i};
            $.post("api.php",d,function(data)
            {
               if(data==="false")
               {
                   $("#invalidmsg").html("invalid username or password");
               }
               else if(data==="true")
               {
                   window.location.href="home.php";
               }
               else
               {
                   alert("error");
               }
            });
            }
        });
    });
</script>
</body>
</html>