<?php
$text = $_GET['code'];
$variables = [];
$loops = ['while' => [], 'for' => [], 'foreach' => []];
$conditionals = [];

$patternVariable = '/\$[A-Za-z0-9_]+/';

preg_match_all($patternVariable, $text, $matchesVariables);
//var_dump($matchesVariables);
foreach ($matchesVariables as $var) {
    foreach ($var as $value) {

        if (array_key_exists(trim($value), $variables)) {
            $variables[trim($value)]++;
        } else {
            $variables[trim($value)] = 1;
        }
    }
}

$patternLoops = '/(while|for|foreach)\s+([^{]*)/';


preg_match_all($patternLoops, $text, $matchesLoops);
//var_dump($matchesLoops);
$count = 0;
foreach ($matchesLoops[0] as $loop) {
    if ($matchesLoops[1][$count] == 'for') {
        $loops['for'][] = trim($loop);
    }
    if ($matchesLoops[1][$count] == 'while') {
        $loops['while'][] = trim($loop);
    }
    if ($matchesLoops[1][$count] == 'foreach') {
        $loops['foreach'][] = trim($loop);
    }

    $count++;

}


$patternConditionals = '/(if|(else\s*if))\s*(\w\W)+/';
preg_match_all($patternConditionals, $text, $matchesConditionals);

//var_dump($matchesConditionals);

foreach ($matchesConditionals[0] as $conditional) {
    $conditionals[] = trim($conditional," {");
}



//
//var_dump($variables);
//var_dump($loops);
//var_dump($conditionals);


$final=['variables'=>$variables,'loops'=>$loops,'conditionals'=>$conditionals];

echo json_encode($final);