<?php
session_start();
$servername="localhost";
$user="root";
$pass="1234";
$dbname="data";
$conn=new mysqli($servername,$user,$pass,$dbname);
if(!$conn)
{
    die("connection failed:".mysqli_connect_error());
}
echo "  ";
?>