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

        table {
            margin-top: 15px;
        }
    </style>
</head>
<body>
<div id="wrapper">

    <form method="post">
        <label for="">Enter number of years: </label>
        <input type="text" name="years" placeholder="Enter number of years"/>
        <input type="submit" name="submit" value="Show costs"/>
    </form>
    <?php if (isset($_POST['years'])): ?>


        <!--Create Months Row-->
        <?php

        echo "<table><tr><td class='title'>Year</td>";
        for ($i = 1; $i <= 12; $i++) {
            $dateObj = DateTime::createFromFormat('!m', $i);
            $monthName = $dateObj->format('F');
            echo "<td class='title'>$monthName</td>";
        }
        echo "<td class='title'>Total:</td></tr>";

        ?>

        <?php
        $dateNow = new DateTime();
        $yearNow = intval($dateNow->format('Y'));
        for ($i = 0; $i < $_POST['years']; $i++) {

            $tempYear = $yearNow - $i;
            $sum = 0;

            echo "<tr><td class='title'>$tempYear</td>";
            for ($j = 0; $j < 12; $j++) {
                $random = rand(0, 999);
                echo "<td>$random</td>";
                $sum += $random;
            }
            echo "<td>$sum</td></tr>";
        }
        echo "</table>";

        ?>
    <?php endif; ?>
</div>
</body>
</html>