<?php

$object = json_decode($_GET['jsonTable']);


$words = $object[0];
$maxLength = max(array_map('strlen', $words));
//var_dump($maxLength);


//E(x) = (k*x + s) % m

$k = intval($object[1][0]);
$s = intval($object[1][1]);
$m = 26;
$E = 0;
echo "<table border='1' cellpadding='5'>";
$arr = [];
foreach ($words as $word) {
    echo "<tr>";

    $arr[$word] = [];
    for ($i = 0; $i < $maxLength; $i++) {
        echo "<td";
        if ($i < strlen($word)) {
            $letter = $word[$i];
        } else {
            $letter = '';
        }

//        foreach (str_split($word) as $letter) {
        if (ctype_alpha($letter)) {
            $x = ord(strtoupper($letter)) - ord("A");
//           var_dump($x);
            $E = ($k * $x + $s) % $m;
            $arr[$word][] = chr($E + ord("A"));

            $temp = chr($E + ord("A"));

            echo " style='background:#CCC'>$temp";


        } else if($letter==''){
            $arr[$word][] = $letter;
            echo ">$letter";
        }
        else{
            echo " style='background:#CCC'>$letter";
        }

        echo "</td>";
//        }
    }

    if(empty($arr[$word])){
        echo "<td></td>";
    }

    echo "</tr>";


}

echo "</table>";



//var_dump(ord("A")-ord("B"));
//var_dump($arr);
//var_dump($words);
//var_dump($k);
//var_dump($s);
//
//
