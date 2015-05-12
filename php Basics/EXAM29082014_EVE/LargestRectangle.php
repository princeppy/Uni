<?php


$matrix = json_decode($_GET['jsonTable']);

$possible = [];
for($i=0; $i<count($matrix)-1; $i++){
    for($j=0; $j<count($matrix[$i])-1; $j++){
        if($matrix[$i][$j]==$matrix[$i+1][$j]&&$matrix[$i][$j]==$matrix[$i][$j+1]){
            $possible[$i]['row'] = $i;
            $possible[$i]['col'] = $j;
        }
    }

}

var_dump($possible);
//
//
//foreach ($possible as $pos) {
//
//}
