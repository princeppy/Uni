<?php

$text = preg_match('/(?<=\d)[^\d]*$/', $_GET['keys'], $matchesEnd);
$stringText = $_GET['text'];
$endKey = '';
$startKey = '';
if (preg_match('/[^A-Za-z_]/', $matchesEnd[0])) {
    $endKey = '';
} else {
    $endKey = $matchesEnd[0];
}



$text = preg_match('/^[A-Za-z_]+(?=\d)/', $_GET['keys'], $matchesStart);
if (!empty($matchesStart)) {
    $startKey = $matchesStart[0];
} else {
    $startKey = '';
}

//var_dump($startKey);
//var_dump($endKey);

if ($startKey === '' || $endKey === '') {
    echo "<p>A key is missing</p>";

} else {

    preg_match_all("/$startKey(.*?)($endKey)/", $stringText, $matchesSymbols);

//    var_dump($startKey);
//    var_dump($endKey);
//    var_dump($stringText);
//
//    var_dump($matchesSymbols);

    $symbolsToSum = $matchesSymbols[1];
    $sum = 0;
    foreach ($symbolsToSum as $value) {

        if (is_numeric($value)) {
            $sum += floatval($value);

        }
    }

    if ($sum === 0) {
        echo "<p>The total value is: <em>nothing</em></p>";
    } else {
        echo "<p>The total value is: <em>$sum</em></p>";
    }
}






