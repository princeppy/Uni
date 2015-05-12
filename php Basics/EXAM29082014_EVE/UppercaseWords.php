<?php

$text= $_GET['text'];

preg_match_all('/(?<=\W|[0-9]|\b)[A-Z]+(?=\W|[0-9]|\b)/',$text,$matches,PREG_OFFSET_CAPTURE);


foreach ($matches as $match) {
    foreach ($match as $value) {
//        var_dump($value);

        if(checkPalindrome($value[0])){

            $replace = doubleWord($value[0]);
//            var_dump($value[0]);

           $text = preg_replace('/(?<=\W|[0-9]|\b)'.$value[0].'(?=\W|[0-9]|\b)/',$replace,$text);
        }
        else{
            $reverse = strrev($value[0]);
            $text = preg_replace('/(?<=\W|[0-9]|\b)'.$value[0].'(?=\W|[0-9]|\b)/',$reverse,$text);
        }


    }

}
echo "<p>".htmlspecialchars($text)."</p>";
//var_dump($text);
function checkPalindrome($str){
    for($i=0; $i<strlen($str)/2; $i++){
        if($str[$i]!=$str[strlen($str)-1-$i]){
            return false;
            break;
        }
    }

    return true;
}


function doubleWord($str){
    $strDouble = '';
    for($i=0; $i<strlen($str); $i++){

        $strDouble .= $str[$i].$str[$i];

    }
    return $strDouble;
}

//var_dump($matches);