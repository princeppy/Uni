<?php
$text = $_GET['text'];
$minFontSize = $_GET['minFontSize'];
$maxFontSize = $_GET['maxFontSize'];
$step = $_GET['step'];
$currFontSize = $minFontSize;

$line_through = true;
$check = true;
$fontAction = '';
if($minFontSize<$maxFontSize){
    $fontAction = 'increase';
}

for ($i = 0; $i < strlen($text); $i++) {


    if (ord($text[$i]) % 2 == 0) {
        $line_through = true;
    } else {
        $line_through = false;
    }

    $currChar = htmlspecialchars($text[$i]);

    if ($line_through) {
        echo "<span style='font-size:$currFontSize;text-decoration:line-through;'>$currChar</span>";
    } else {
        echo "<span style='font-size:$currFontSize;'>$currChar</span>";

    }

    if ($fontAction == 'increase') {
        if (ctype_alpha($text[$i])) {

            if ($currFontSize + $step >= $maxFontSize) {
                $fontAction = 'decrease';

            }
            $currFontSize += $step;
        }


    } else if($fontAction=='decrease') {

        if (ctype_alpha($text[$i])) {
            if ($currFontSize - $step <= $minFontSize) {
                $fontAction = 'increase';

            }
            $currFontSize -= $step;

        }
    }

}



