<?php
require("conn.php");
?>
<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</head>
<body>
<div class="row m-0">
    <div class="col-4">
<button type="button" class="btn btn-outline-success btn-lg" data-toggle="modal" data-target="#myModal">+ NEW</button>

<!-- Modal -->
<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">New Folder</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>

            </div>
            <div class="modal-body">
                <input type="text" name="newFolderName" id="newfolname" >
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">cancel</button>
                <input type="submit" class="btn btn-default" id="create"  data-dismiss="modal" value="create">
            </div>

        </div>

    </div>
</div>
    </div>
    <div class="col-8">
<?php
$id=$_SESSION["useri"];
$n=trim($_REQUEST['foldern']);
$i=$_REQUEST['parentfolderid'];
$sql="select * from folder where userid='$id' and foldername='$n' and parentfolder='$i'";
$result=mysqli_query($conn,$sql);
if($result)
    $recordsFound=mysqli_num_rows($result);
else
    $recordsFound = 0;

if($recordsFound)
{

    $row = mysqli_fetch_assoc($result);
    $i=$row["folderid"];
}
$parentfolder1d=trim($i);
//if(isset($_REQUEST["create"]))
//{
//    $foldername=$_REQUEST["newFolderName"];
//    $sql="insert into folder(foldername,parentfolder,userid) values('$foldername','$parentfolder1d','$id')";
//    $rec=$conn->query($sql);
//    echo "create";
//}
$sql="select * from folder where userid='$id' and parentfolder='$parentfolder1d'";
$result=mysqli_query($conn,$sql);
if($result)
    $recordsFound=mysqli_num_rows($result);
else
    $recordsFound = 0;

if($recordsFound)
{
    while( $row = mysqli_fetch_assoc($result))
    {
//        $fn=" ";
//       $o=str_replace(" ",$row["foldername"],$fn);
//        $r=str_replace("*"," ",$o);
        $fn=$row["foldername"];
        $r=str_replace("`"," ",$fn);
        ?><div style="display:inline-block" class="border rounder-sm folder w-25 p-3 m-1" ><?php echo $r?></div>
        <input type="hidden" id="f" value=<?php echo $row["foldername"]?>>
        <?php
    }
}
$conn->close();?>
    </div>
</div>

<input type="hidden" id="PFolder" value=<?php echo $parentfolder1d?>>
<script>
    $(document).ready(function(){
        $("#create").click(function()
        {
            var n=$("#newfolname").val();
            var i=$("#PFolder").val();
            var data={"action":"create","newFolderName":n,"pfid":i};
            $.get("api.php",data);
            location.reload();

        });
        $(".folder").dblclick(function(){
            var f=$(this).next().val();
            var id=$("#PFolder").val();
            alert(f);
            window.location.href="clickedfolder.php?foldern= "+f+"&parentfolderid= "+id;
        });
    });
</script>
</body>
</html>
