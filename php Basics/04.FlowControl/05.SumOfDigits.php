<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        table, tr, td {
            border: 1px solid black;
        }

        table{
            margin-top: 10px;
        }
    </style>
</head>
<body>
<div id="wrapper">

    <form method="post">
        <label for="">Input string: </label><input type="text" name="numbers" placeholder="Enter comma separated string"/>
        <input type="submit" name="submit"/>
    </form>
    <?php

    if (isset($_POST['submit'])) {

        $arr = preg_split('/,\\s*/',$_POST['numbers'],null,PREG_SPLIT_NO_EMPTY);

        echo "<table>";
        foreach ($arr as $number) {
            $sum = 'no';
            if(is_numeric($number)){
                for($i=0; $i<strlen($number); $i++){

                    $sum+=intval($number[$i]);
                }
            }
            if($sum!=='no'){
                echo "<tr><td>$number</td><td>$sum</td></tr>";
            }
            else{
                echo "<tr><td>$number</td><td>I cannot sum this</td></tr>";
            }
        }

    }
    ?>
</div>
</body>
</html>