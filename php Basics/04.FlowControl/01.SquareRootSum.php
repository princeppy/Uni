<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        table,tr,td{
            border:1px solid black;
        }
        .title{
            font-weight: bold;
        }
    </style>
</head>
<body>
<div id="wrapper">
    <?php

    echo "<table><tr><td class='title'>Number</td><td class='title'>Square</td></tr>";

    $sum = 0;
    for ($i = 0; $i <= 100; $i += 2) {
        $sqrtNum = number_format(sqrt($i),2,'.','');
        echo "<tr><td>$i</td><td>$sqrtNum</td>";
        $sum+=$sqrtNum;
    }
        echo "<tr><td class='title'>Total:</td><td>$sum</td></tr>";
    echo "</table>";
    ?>

</div>
</body >
</html>