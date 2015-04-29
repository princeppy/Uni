<?php

$users = preg_split('/\r?\n/', $_GET['list'], null, PREG_SPLIT_NO_EMPTY);
$minLength = $_GET['length'];
//$show = $_GET['show'];
//var_dump($users);

echo "<ul>";

foreach ($users as $user) {

    if (strlen($user) < $minLength && isset($_GET['show'])) {
        echo '<li style="color: red;">' . htmlspecialchars($user) . "</li>";
    } else if (strlen($user) < $minLength && !isset($_GET['show'])) {
        continue;
    } else {
        echo "<li>" . htmlspecialchars($user) . "</li>";

    }
}

echo "</ul>";