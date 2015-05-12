<?php

$arrows[] = $_GET['arrows'];
$arrows[] = $_GET['arrows1'];
$arrows[] = $_GET['arrows2'];
$arrows[] = $_GET['arrows3'];

$pattern = '/>>>----->>|>>----->|>----->/';

$largeCount = 0;
$mediumCount = 0;
$smallCount = 0;
foreach ($arrows as $line) {
    //Large
    preg_match_all($pattern,$line,$matches);
    $line = preg_replace($pattern,"",$line);
//    $largeCount +=count($matchesLarge[0]);
//    var_dump(count($matchesLarge));

//    var_dump(count($matchesSmall));

//    var_dump($matchesLarge);
//    var_dump($matchesMedium);
//    var_dump($matchesSmall);

//    var_dump($matches);

    foreach ($matches[0] as $match) {

        if($match=='>----->'){
            $smallCount++;
        }
        if($match=='>>----->'){
            $mediumCount++;
        }
        if($match=='>>>----->>'){
            $largeCount++;
        }

    }

}


    $dec = $smallCount . $mediumCount . $largeCount;
    $dec = intval($dec);

if($dec===0){
    echo 0;
}
//var_dump($dec);$
else {
    $bin = decbin($dec);
//var_dump($bin);

    $revBin = strrev($bin);
//var_dump($revBin);

    $str = $bin . $revBin;
//var_dump($str);

    $number = bindec($str);


    echo $number;
}
//var_dump($arrows);



