<!DOCTYPE html>

<?php
require("conn.php");
?>
<html>
<body>
<?php
$error="";
$msg="";
if(isset($_REQUEST["submit"]))
{
    $name=$_REQUEST["user"];
    $login=$_REQUEST["login"];
    $pass=$_REQUEST["pass"];
    $confPass=$_REQUEST["confPass"];
    if($pass!=$confPass)
    {
        $error="password donot match!";
    }
    else{
        $sql="insert into user(name,login,password) values('$name','$login','$pass')";
        if($conn->query($sql)===true)
        {
            $msg="registered sucessfully";
        }
        else
        {
            $msg="some problem has occured";
        }
        $conn->close();
    }
}?>
<form action="1.php">
    Name:
    <input type="text" name="user" />
    <br/>
    login:
    <input type="text" name="login" />
    <br/>
    Password:
    <input type="password" name="pass" />
    <br/>
    Confirm Password:
    <input type="password" name="confPass"/>
    <br/><span style="color:red"><?php echo "$error"?></span>
    <input type="submit" name="submit" value="submit"/>
    <span style="color:red"><?echo "$msg"?></span>
</form>
</body>
</html>