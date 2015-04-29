<?php

$text = $_GET['text'];
$word = $_GET['word'];

$sentences = preg_split('/(\s*[!?.]+?\s*)/', $text, null, PREG_SPLIT_DELIM_CAPTURE);
//var_dump($sentences);
for ($i = 0; $i < count($sentences); $i += 2) {

//    var_dump(preg_match("/\\b$word\\b/",$sentences[$i]));
    if (preg_match("/\\b$word\\b/", $sentences[$i])) {

        if($i==count($sentences)-1){
            echo "<p>" . $sentences[$i] . "</p>";
        }else{
            echo "<p>" . $sentences[$i] . $sentences[$i + 1] . "</p>";
        }
    }
}







