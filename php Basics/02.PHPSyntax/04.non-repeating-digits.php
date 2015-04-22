<?php
$number = 247;
$check = false;
if ($number < 100) {
    echo "no";
} else {
    for ($i = 100; $i <= $number && $i < 1000; $i++) {
        $last = $i%10;
        $mid = ($i/10)%10;
        $first = ($i/100)%10;

        if($last!==$mid && $last!==$first&&$mid!==$first){
            echo "$i" . "<br/>";
            $check = true;
        }
    }
}

if($check==false){
    echo "no";
}