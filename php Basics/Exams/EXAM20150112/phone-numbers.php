<?php

$text = $_GET['numbersString'];

preg_match_all('/([A-Z]{1}[A-Za-z]*)([^0-9A-Za-z+]*)(\+?[0-9]+[0-9\)\(\/\. \-]*[0-9]+)/',$text,$matches);

$names = $matches[1];
$phones = $matches[3];


if(empty($names)){
    echo "<p>No matches!</p>";
}
else{


echo "<ol>";
for($i=0; $i<count($names); $i++){

    $phone = preg_replace('/[\s\/\.\)\(\-]/',"",$phones[$i]);
//    var_dump($phone);
    if(preg_match('/\d{2,}/',$phone)){
        echo "<li><b>$names[$i]:</b> ".$phone."</li>";
    }



}
    echo "</ol>";
}


//var_dump($matches);