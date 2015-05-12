<?php
$data = $_GET['data'];
$lines = preg_split('/\s*,\s*/',$data,-1,PREG_SPLIT_NO_EMPTY);


$minedJewels = ["*Gold: "=>0,"*Silver: "=>0,"*Diamonds: "=>0];
foreach ($lines as $line) {
    $tokens = preg_split('/\s+/',$line,-1, PREG_SPLIT_NO_EMPTY);
//    var_dump($tokens);


    if(count($tokens)===4){
        if(strtolower($tokens[0]) === 'mine'){
            if(strtolower($tokens[2])==='gold'){
                if(intval($tokens[3])){
                    $minedJewels['*Gold: ']+=intval($tokens[3]);
                }

            }
            if(strtolower($tokens[2])==='silver'){
                if(intval($tokens[3])){
                    $minedJewels['*Silver: '] +=intval($tokens[3]);
                }


            }
            if(strtolower($tokens[2])==='diamonds'){
                if(intval($tokens[3])){
                    $minedJewels['*Diamonds: ']+=intval($tokens[3]);
                }


            }
        }
    }


}

foreach ($minedJewels as $key=>$jewel) {
    echo "<p>".htmlspecialchars($key) . htmlspecialchars($jewel)."</p>";
}

//var_dump($minedJewels);

