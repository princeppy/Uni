<?php

$text = $_GET['text'];
$letters = str_split($text);

foreach ($letters as $letter) {

   if(ord($letter)%2==0){
       echo "<span style='color:red'>$letter </span>";
   }else{
       echo "<span style='color:blue'>$letter </span>";
   }
}
