<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</head>
<body>
<div class="form-group">
    <label for="user"> Name:</label>
    <input type="text" name="user"  id="user" class="form-control w-25" placeholder="enter name"/>
</div>
<div class="form-group">
    <label for="login">login:</label>
    <input type="text" name="login" id="login" class="form-control w-25" placeholder="enter login"/>
</div>
<div class="form-group">
    <label for="pass">Password:</label>
    <input type="password" name="pass" id="pass" class="form-control w-25" placeholder="enter password"/>
</div>
<div class="form-group">
    <label for="confPass">Confirm Password:</label>
    <input type="password" name="confPass" id="confPass" class="form-control w-25" placeholder="confirm password"/><span style="color:red" id="cpassSpan"></span>
</div>
    <input type="submit" name="submit" value="submit" id="submit" class="btn btn-outline-dark"/>
    <span style="color:red" id="recordExist"></span>
<span style="color:red" id="cpassSpan"></span>
<script>
    $(document).ready(function(){
        $("#submit").click(function()
        {
            var n=$("#user").val();
            var i=$("#pass").val();
            var l=$("#login").val();
            var c=$("#confPass").val();
            var d={"action":"register","user":n,"pass":i,"login":l};
            if(n==="" || i==="" ||l==="" || c==="")
            {
               $("#cpassSpan").html("all fields required");
            }
           else if(i!==c)
            {
               $("#cpassSpan").html("password donnot match");
            }
            else {
                $.post("api.php", d, function (data) {
                    if (data === "false") {
                       $("#recordExist").html("login already exist")
                    } else {
                        window.location.href="home.php";
                    }
                });
            }
        });
    });
</script>
</body>
</html>