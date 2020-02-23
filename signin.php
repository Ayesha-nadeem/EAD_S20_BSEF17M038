<!DOCTYPE html>

<?php
require("conn.php");
?>
<?php
$error="";
$uname="";
if(isset($_REQUEST["submit"]))
{
    $name=$_REQUEST["user"];
    $pass=$_REQUEST["pass"];

    $sql="select * from user where login='$name' and password='$pass'";

    $result=mysqli_query($conn,$sql);
    if($result)
        $recordsFound=mysqli_num_rows($result);
    else
        $recordsFound = 0;
echo "<h1>$name$pass$recordsFound</h1>";
    if($recordsFound)
    {
        $row = mysqli_fetch_assoc($result);
        $_SESSION['useri']=$row["userid"];
        header('Location:home.php');
    }
    else
    {
        $error="invalid user name or password";
    }
    $conn->close();
}?>
<html>
<body>

<form action="signin.php">
    Name:
    <input type="text" name="user" />
    <br/>
    Password:
    <input type="password" name="pass" /><br>
    <span style="color:red"><?php echo "$error"?></span>
    <input type="submit" name="submit" value="submit"/>
    <a href="1.php">register</a>
</form>
</body>
</html>