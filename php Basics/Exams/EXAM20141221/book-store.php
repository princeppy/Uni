<?php
date_default_timezone_set('Europe/Sofia');
$objects = preg_split('/\r?\n/', $_GET['text'], null, PREG_SPLIT_NO_EMPTY);
$minPrice = $_GET['min-price'];
$maxPrice = $_GET['max-price'];
$sort = $_GET['sort'];
$order = $_GET['order'];

//var_dump($objects);
$books = [];

foreach ($objects as $object) {
    $arr = preg_split('/(\s*)?\/(\s*)?/', $object, null, PREG_SPLIT_NO_EMPTY);

    //Get the data
    $author = $arr[0];
    $name = $arr[1];
    $genre = $arr[2];
    $price = $arr[3];
    $date = $arr[4];

    $date = new DateTime($date);
    $timestamp = $date->getTimestamp();;
    $info = $arr[5];
    $books[$name] = ['author' => $author, 'genre' => $genre, 'publish-date' => $timestamp, 'info' => $info, 'price' => floatval($price)];

}
//Sorting

if ($sort == 'publish-date') {
    if ($order == 'ascending') {
        $books = array_sort($books, 'publish-date', SORT_ASC);
    } else {
        $books = array_sort($books, 'publish-date', SORT_DESC);
    }

} else {
    if ($sort == 'author') {
        if ($order == 'ascending') {
            uasort($books, function ($b1, $b2) {

                if (strcmp($b1['author'], $b2['author']) == 0) {

                    return $b1['publish-date'] > $b2['publish-date'];
                } else {
                    return strcmp($b1['author'], $b2['author']);
                }
            });
        }
        else{
            uasort($books, function ($b1, $b2) {

                if (strcmp($b1['author'], $b2['author']) == 0) {

                    return $b1['publish-date'] > $b2['publish-date'];
                } else {
                    return strcmp($b2['author'], $b1['author']);
                }
            });
        }
    } else if ($sort == 'genre') {
        if ($order == 'ascending') {
            uasort($books, function ($b1, $b2) {

                if (strcmp($b1['genre'], $b2['genre']) == 0) {
                    return $b1['publish-date'] > $b2['publish-date'];
                } else {
                    return strcmp($b1['genre'], $b2['genre']);
                }
            });
        }
        else{
            uasort($books, function ($b1, $b2) {

                if (strcmp($b1['genre'], $b2['genre']) == 0) {
                    return $b1['publish-date'] > $b2['publish-date'];
                } else {
                    return strcmp($b2['genre'], $b1['genre']);
                }
            });
        }
    }

}

$isBooks = false;
foreach ($books as $name => $details) {
    if ($details['price'] >= $minPrice && $details['price'] <= $maxPrice) {
        $isBooks = true;
//start div
        echo "<div>";

        echo "<p>" . htmlspecialchars($name) . "</p>";

        //start ul
        echo "<ul>";

        echo "<li>" . htmlspecialchars($details['author']) . "</li>";
        echo "<li>" . htmlspecialchars($details['genre']) . "</li>";
        echo "<li>" . htmlspecialchars(number_format($details['price'], '2', '.', '')) . "</li>";
        echo "<li>" . htmlspecialchars(date('Y-m-d', $details['publish-date'])) . "</li>";
        echo "<li>" . htmlspecialchars($details['info']) . "</li>";


        //end ul
        echo "</ul>";

//end div
        echo "</div>";
    }
}
if(!$isBooks){
    echo "<div>No books</div>";
}

//var_dump($books);


function array_sort($array, $on, $order = SORT_ASC)
{
    $new_array = array();
    $sortable_array = array();

    if (count($array) > 0) {
        foreach ($array as $k => $v) {
            if (is_array($v)) {
                foreach ($v as $k2 => $v2) {
                    if ($k2 == $on) {
                        $sortable_array[$k] = $v2;
                    }
                }
            } else {
                $sortable_array[$k] = $v;
            }
        }

        switch ($order) {
            case SORT_ASC:
                asort($sortable_array);
                break;
            case SORT_DESC:
                arsort($sortable_array);
                break;
        }

        foreach ($sortable_array as $k => $v) {
            $new_array[$k] = $array[$k];
        }
    }

    return $new_array;
}






