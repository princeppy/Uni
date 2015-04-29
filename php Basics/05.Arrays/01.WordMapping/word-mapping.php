<?php

$text = $_GET['text'];
$words = preg_split('/\W/',$text,null, PREG_SPLIT_NO_EMPTY);

$arr = [];

//var_dump($words);
foreach ($words as $word) {

   $word = strtolower($word);

    if(isset($arr[$word])){
        echo "test";
        $arr[$word]++;
    }else{
        $arr[$word] = 1;
    }
}

var_dump($arr);
