<?php

//Uncomment the row you wish to check
//$var1 = 'hello';
//$var1 = 15;
$var1 = 1.234;
//$var1 = array(1,2,3);
//$var1 = (object)[2,34];

if(is_numeric($var1)){
    var_dump($var1);
}
else{
    echo gettype($var1);
}
