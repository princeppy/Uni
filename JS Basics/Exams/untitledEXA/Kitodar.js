function BogiPrezident(input) {
    var minedJewels = {"*Silver: ": 0, "*Gold: ": 0, "*Diamonds: ": 0};
    var pattern = /(.+?)(?=\s)(\s+(.+?)?)(?=-)-\s+(.+?)(?=:):\s+(.+)/;
    for (var i in input) {
        var tokens = input[i].split(/\s+|\s*-\s*|\s*:\s*/);
        var match = pattern.exec(input[i]);
        //console.log(match);
        //tokens = tokens.filter(function (a) {
        //    return a != '';
        //});
        //console.log(tokens);
        if (match != null) {
            if (match[1].trim().toLowerCase() === 'mine') {

                if (match[4].trim().toLowerCase() === 'gold') {


                        minedJewels['*Gold: '] += parseInt(match[5].trim());


                }
                if (match[4].trim().toLowerCase() === 'silver') {

                        minedJewels['*Silver: '] += parseInt(match[5].trim());



                }
                if (match[4].trim().toLowerCase() === 'diamonds') {

                        minedJewels['*Diamonds: '] += parseInt(match[5].trim());



                }
            }
        }
    }
    for (var obj in minedJewels) {
        console.log(obj + minedJewels[obj]);
    }
    //console.log(minedJewels);
}

BogiPrezident([
    'mine     bobovDol -    gold :     10',
    'mine medenrudnik - silver: 22',
    'mine chernoMore - shrimps : 24',
    'gold: 50'

])

BogiPrezident([
        'mine bobovdol - gold : 10',
        'mine - diamonds : 5',
        'mine colas - wood : 10',
        'mine myMine - silver :  14',
        'mine silver:14 - silver : 14'
    ]
)
//<?php
//    $data = $_GET['data'];
//$lines = preg_split('/\s*,\s*/',$data,-1,PREG_SPLIT_NO_EMPTY);
//
//
//$minedJewels = ["*Gold: "=>0,"*Silver: "=>0,"*Diamonds: "=>0];
//foreach ($lines as $line) {
//    $tokens = preg_split('/\s+/',$line,-1, PREG_SPLIT_NO_EMPTY);
////    var_dump($tokens);
//
//
//    if(count($tokens)===4){
//        if(strtolower($tokens[0]) === 'mine'){
//            if(strtolower($tokens[2])==='gold'){
//                if(intval($tokens[3])){
//                    $minedJewels['*Gold: ']+=intval($tokens[3]);
//                }
//
//            }
//            if(strtolower($tokens[2])==='silver'){
//                if(intval($tokens[3])){
//                    $minedJewels['*Silver: '] +=intval($tokens[3]);
//                }
//
//
//            }
//            if(strtolower($tokens[2])==='diamonds'){
//                if(intval($tokens[3])){
//                    $minedJewels['*Diamonds: ']+=intval($tokens[3]);
//                }
//
//
//            }
//        }
//    }
//
//
//}
//
//foreach ($minedJewels as $key=>$jewel) {
//    echo "<p>".htmlspecialchars($key) . htmlspecialchars($jewel)."</p>";
//}
//
////var_dump($minedJewels);
