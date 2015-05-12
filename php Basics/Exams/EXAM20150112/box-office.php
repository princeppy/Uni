<?php

$lines = preg_split('/\r?\n/', $_GET['list'], null, PREG_SPLIT_NO_EMPTY);
$minSeats = intval($_GET['minSeats']);
$maxSeats = intval($_GET['maxSeats']);
$filter = $_GET['filter'];
$order = $_GET['order'];

$movies = [];

foreach ($lines as $line) {

    $line = preg_split('/-\s+/', $line, null, PREG_SPLIT_NO_EMPTY);

    $starAndSeats = $line[1];

    $starAndSeats = preg_split('/\s\/\s/', $starAndSeats, null, PREG_SPLIT_NO_EMPTY);

    $stars = preg_split('/,\s/', $starAndSeats[0], null, PREG_SPLIT_NO_EMPTY);
    $seats = intval(trim($starAndSeats[1]));


    $nameAndGenre = $line[0];
    $nameAndGenre = preg_split('/\(/', $nameAndGenre, null, PREG_SPLIT_NO_EMPTY);

    $name = trim($nameAndGenre[0]);
    $genre = $nameAndGenre[1];
    $genre = str_replace(")", "", $genre);
    $genre = trim($genre);


    if ($seats >= $minSeats && $seats <= $maxSeats) {
        if ($filter == $genre || $filter == 'all') {
            $movies[] = ['name' => $name,
                'genre' => $genre,
                'stars' => $stars,
                'seats' => $seats];
        }
    }
}




    uasort($movies, function ($m1, $m2) use ($order) {
        if ($m1['name'] === $m2['name']) {

            return $m1['seats'] > $m2['seats'];
        }
        if($order=='ascending'){
            return strcmp($m1['name'], $m2['name']);
        }
        return strcmp($m2['name'], $m1['name']);
    });



foreach ($movies as $movie) {
    echo '<div class="screening"><h2>' . htmlspecialchars($movie['name']), '</h2>';


    echo '<ul>';

    foreach ($movie['stars'] as $star) {
        echo '<li class="star">';
        echo htmlspecialchars($star);
        echo "</li>";
    }
    echo "</ul>";


//    ><span class="seatsFilled">160 seats filled</span></
    echo '<span class="seatsFilled">';
    echo htmlspecialchars($movie['seats']) . " seats filled";
    echo "</span>";

    echo '</div>';
}



//var_dump($movies);


