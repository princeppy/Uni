<?php

$date = new DateTime('now');

$days = $date->format('t');

$dayNow = $date->format('j');

for($i=$dayNow; $i<$days; $i++){
    $date->add(new DateInterval('P1D'));
    if($date->format('l')==="Sunday"){
        echo $date->format('dS F Y').'<br>';
    }
}



