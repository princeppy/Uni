<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        table, tr, td {
            border: 1px solid black;
        }

        .title {
            font-weight: bold;
        }
    </style>
</head>
<body>
<div id="wrapper">

    <form method="post">
        <input type="text" name="cars" placeholder="Enter cars list separated by comma"/>
        <input type="submit" name="submit"/>
    </form>
    <?php

    if (isset($_POST['cars'])) {

        echo "<table><tr><td class='title'>Car</td><td class='title'>Color</td><td class='title'>Count</td></tr>";

        $carArray = preg_split('/,\\s*/', $_POST['cars'],NULL,PREG_SPLIT_NO_EMPTY);
        $color = ["red", "green", "blue", "yellow", "brown", "purple", "cyan", "white", "black"];
        for ($i = 0; $i < count($carArray); $i++) {
            $randomColor = array_rand($carArray, 1);
            $randCount = rand(1, 5);
            echo "<tr><td>$carArray[$i]</td><td>$color[$randomColor]</td><td>$randCount </td></tr>";
        }
        echo "</table>";
    }
    ?>
</div>
</body>
</html>