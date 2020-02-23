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
echo "connected sucessfully";
$id=$_SESSION["useri"];
?>
<?php
if(isset($_REQUEST["action"]) && !empty($_REQUEST["action"]))
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
    $action=$_REQUEST["action"];
    if($action="create")
    {
        $sql="insert into folder(foldername,parentfolder,userid) values('$foldername','$parentfolder1d','$id')";
        $rec=$conn->query($sql);
    }
}?>
