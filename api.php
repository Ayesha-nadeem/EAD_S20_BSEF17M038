<?php
session_start();
$servername = "localhost";
$user = "root";
$pass = "1234";
$dbname = "data";
$conn = new mysqli($servername, $user, $pass, $dbname);
if (!$conn) {
    die("connection failed:" . mysqli_connect_error());
}
$id=$_SESSION["useri"];
?>
<?php
if(isset($_REQUEST["action"]) && !empty($_REQUEST["action"]))
{
    $action=$_REQUEST["action"];
    if($action=="create")
    {
    $foldername=trim($_REQUEST["newFolderName"]);
    $parentfolder1d=$_REQUEST["pfid"];
    $sql="select * from folder where userid='$id' and foldername='$foldername' and parentfolder='$parentfolder1d' ";
    $result=mysqli_query($conn,$sql);
    while(mysqli_num_rows($result))
    {
        $foldername .="`";
        $sql="select * from folder where userid='$id' and foldername='$foldername' and parentfolder='$parentfolder1d' ";
        $result=mysqli_query($conn,$sql);
    }
        $sql="insert into folder(foldername,parentfolder,userid) values('$foldername','$parentfolder1d','$id')";
        $rec=$conn->query($sql);
    }
    if($action=="signin")
    {
        $error="";
        $result;

            $name=$_REQUEST["user"];
            $pass=$_REQUEST["pass"];

            $sql="select * from user where login='$name' and password='$pass'";

            $result=mysqli_query($conn,$sql);
            if($result)
                $recordsFound=mysqli_num_rows($result);
            else
                $recordsFound = 0;
            if($recordsFound)
            {
                $row = mysqli_fetch_assoc($result);
                $_SESSION['useri']=$row["userid"];
                $result=true;
                echo json_encode($result);
            }
            else
            {
                $result=false;
                echo json_encode($result);
            }

    }
}?>
