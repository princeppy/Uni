<?php
date_default_timezone_set('Europe/Sofia');
$page = intval($_GET['page']);
$pageSize = intval($_GET['pageSize']);

$confs = $_GET['conferences'];

$confs = preg_split('/\r?\n/', $confs, -1, PREG_SPLIT_NO_EMPTY);

$data = [];
foreach ($confs as $line) {
    preg_match("/(\\d{4}(-|\\/)\\d{2}(-|\\/)\\d{2})\\s*,\\s*(#[A-Za-z\\.\\-]+)\\s*,\\s*(\\'[^\\']+\\')\\s*,\\s*([A-Za-z\\,\\-]+(?=,))\\s*,\\s*(\\d+)\\s*,\\s*(\\d+)/", $line, $matches);
//    var_dump($matches);
    if (!empty($matches)) {
        $date = date_create(trim($matches[1])); //create the date
        if (!$date) {
            continue;
        }
        $hashTag = trim($matches[4]);
        $eventName = trim($matches[5], '\s\'');
        $location = trim($matches[6]);
        $ticketsAll = intval($matches[7]);
        $ticketsSold = intval($matches[8]);

        $dateNow = new DateTime();
//        var_dump($dateNow);
//        var_dump($date);

        $interval = $dateNow->diff($date);
//        var_dump($interval);
        if ($interval->days === 0) {
            $interval = $interval->format('+%a days');
        } else if ($interval->invert == 0) {
            $days = $interval->days + 1;
            $interval = "+" . $days . " days";

        } else {
            $interval = $interval->format('%R%a days');
        }


        $seatsLeft = $ticketsAll - $ticketsSold;


        $temp = [];

        $temp['date'] = $date;
        $temp['location'] = $location;
        $temp['name'] = $eventName;
        $temp['hash'] = $hashTag;
        $temp['interval'] = $interval;
        $temp['seatsLeft'] = $seatsLeft;

        $data[] = $temp;

//
//        var_dump($date);
//        var_dump($eventName);
//        var_dump($hashTag);
//        var_dump($interval);
//        var_dump($seatsLeft);
    }

}
//var_dump($data);
//if(empty[$data]){
//    if(empty($sorted)){
//        echo '<table border="1" cellpadding="5">';
//        echo "<tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>";
//        echo "<tr><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>";
//        echo "</table>";
//    }
//}
$sorted = array_orderby($data, 'date', SORT_DESC, 'location', SORT_ASC, 'seatsLeft', SORT_DESC, 'name', SORT_ASC);//check for natSort for alphabetically

//var_dump($sorted);

$pagesCount = ceil(count($sorted) / $pageSize);

$pages = [];
$num = 1;
for ($i = 0; $i < count($sorted); $i += $pageSize) {
    $temp = [];

    for ($j = $i; $j < $i + $pageSize && $j < count($sorted); $j++) {
//        var_dump($j);
        $temp[] = $sorted[$j];
//        var_dump($temp);

        $pages[$num][] = $sorted[$j];

    }
    $num++;

}

//var_dump($pages);

//$counts = [];
//for ($i = 0; $i < count($pages[$i]); $i++) {
//    $count = 1;
//    for ($j = $i + 1; $j < count($data); $j++) {
//        if ($data[$i]['date'] == $data[$j]['date']) {
//            $count++;
//        } else {
//            $i = $j - 1;
//            break;
//        }
//    }
//    $counts[] = $count;
//}
//
//var_dump($counts);


if ($pagesCount < $page) {
    echo '<table border="1" cellpadding="5">';
    echo "<tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>";
    echo "<tr><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>";
    echo "</table>";

} else {
    echo '<table border="1" cellpadding="5">';
    echo "<tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>";
    for ($i = 1; $i <= count($pages); $i++) {

//        var_dump($row);
//        foreach ($counts as $span) {
//
//        }

        $counts = [];
//        var_dump($pages[$i]);
        for ($j = 0; $j < count($pages[$i]); $j++) {
            $count = 1;
            for ($k = $j + 1; $k < count($pages[$i]); $k++) {
//                var_dump($pages[$i][$j]);
                if ($pages[$i][$j]['date'] == $pages[$i][$k]['date']) {
                    $count++;
                } else {
                    $j = $k - 1;
                    break;
                }
            }
            $counts[] = $count;
        }
//
//        var_dump($counts);
        $tempCount = 0;
        if ($page === $i) {

            foreach ($counts as $val) {
//                var_dump($val);
//                var_dump($pages[$i]);
                if ($tempCount >= $pageSize) {
                    break;
                }
                if ($val > 1) {
                    $dateToPrint = $pages[$i][$tempCount]['date'];
                    $dateToPrint = $dateToPrint->format("Y-m-d");
                    echo '<tr><td rowspan="' . $val . '">' . htmlspecialchars( $dateToPrint) . "</td>";

                    for ($q = 0; $q < $val; $q++) {

                        if ($q > 0) {
                            echo "<tr>";
                        }
                        echo "<td>" . htmlspecialchars($pages[$i][$tempCount]['name']) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['hash']) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['interval']) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['seatsLeft']) . " seats left</td></tr>";
                        $tempCount++;
//                        var_dump($pages[$i]);
                    }

                } else {
//                    var_dump($pages[$i][$tempCount]);

                    $dateToPrint = $pages[$i][$tempCount]['date'];
                    $dateToPrint = $dateToPrint->format("Y-m-d");
                    echo '<tr><td>' . htmlspecialchars( $dateToPrint) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['name']) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['hash']) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['interval']) . "</td><td>" . htmlspecialchars($pages[$i][$tempCount]['seatsLeft']) . " seats left</td></tr>";
                    $tempCount++;

                }
//                var_dump($tempCount);


            }


        }
    }

    echo "</table>";

}
//var_dump($sorted);
//var_dump($pages[$page]);


//var_dump($counts);

function array_orderby()
{
    $args = func_get_args();
    $data = array_shift($args);
    foreach ($args as $n => $field) {
        if (is_string($field)) {
            $tmp = array();
            foreach ($data as $key => $row)
                $tmp[$key] = $row[$field];
            $args[$n] = $tmp;
        }
    }
    $args[] = &$data;
    call_user_func_array('array_multisort', $args);
    return array_pop($args);
}


//var_dump($confs);