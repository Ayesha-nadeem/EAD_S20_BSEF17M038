<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</head>
<body>

<!--<form action="signin.php">-->
    Name:
    <input type="text" name="user" id="user" />
    <br/>
    Password:
    <input type="password" name="pass" id="password"/><br>
    <span style="color:red" id="invalidmsg"></span>
    <input type="submit" name="submit" value="submit" id="submit"/>
    <a href="1.php">register</a>
<!--</form>-->
<script>
    $(document).ready(function(){
        $("#submit").click(function()
        {
            var n=$("#user").val();
            var i=$("#password").val();
            var d={"action":"signin","user":n,"pass":i};
            $.get("api.php",d,function(data)
            {
               if(data=="false")
               {
                   $("#invalidmsg").html("invalid username or password");
               }
               else
               {
                   window.location.href="home.php";
               }
            });
        });
    });
</script>
</body>
</html>