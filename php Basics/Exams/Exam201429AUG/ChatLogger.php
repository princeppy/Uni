<?php
date_default_timezone_set('Europe/Sofia');
$currDate = strtotime($_GET['currentDate']);
$messages = $_GET['messages'];

$arrMessages = preg_split('/\s+\/\s+|\r?\n/', $messages, -1, PREG_SPLIT_NO_EMPTY);
$messageDateArr = [];

for ($i = 0; $i < count($arrMessages); $i += 2) {

    $tempMessage = $arrMessages[$i];
    $tempDate = strtotime($arrMessages[$i + 1]);
    $messageDateArr[$tempMessage] = $tempDate;
}
asort($messageDateArr);
//echo count($messageDateArr);
//var_dump($messageDateArr);

$lastSeen = '';
foreach ($messageDateArr as $message => $date) {

    echo "<div>" . htmlspecialchars($message) . "</div>\n";
    $lastSeen =     $date;
}
//var_dump(date('d-m-Y H:i:s',$lastSeen));

$text = lastSeen($currDate, $lastSeen);
echo "<p>Last active: <time>" . $text . "</time></p>";


function lastSeen($currDate, $lastSeen)
{


    $currDate = new DateTime(date('d-m-Y H:i:s',$currDate));
    $lastSeen = new DateTime(date('d-m-Y H:i:s',$lastSeen));


    $interval = $currDate->diff($lastSeen);

    if (date('z',$currDate->getTimestamp())-date('z',$lastSeen->getTimestamp())==1) {
        return 'yesterday';
    }
    else if ($interval->d == 0) {

        if ($interval->h == 0 && $interval->i < 1) {


            return 'a few moments ago';
        } else if ($interval->h < 1) {
            $str = $interval->i==1? " minute ago":"minutes ago";
            return $interval->i . " minute(s) ago";
        } else {
            $str = $interval->i==1? " hour ago":"hours ago";

            return $interval->h . " hour(s) ago";
        }
    }else{
        return $lastSeen->format('d-m-Y');
    }


//    else if()




}


//var_dump($messageDateArr);