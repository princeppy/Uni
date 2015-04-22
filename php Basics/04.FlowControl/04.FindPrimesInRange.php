<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        table, tr, td {
            border: 1px solid black;
        }
    </style>
</head>
<body>
<div id="wrapper">

    <form method="post">
        <label for="">Starting index: </label><input type="text" name="start" placeholder="Enter start index"/>
        <label for="">End index: </label><input type="text" name="end" placeholder="Enter end index"/>
        <input type="submit" name="submit"/>
    </form>
    <?php

    if (isset($_POST['submit'])) {

        $arr = [];
        $start = $_POST['start'];
        $end = $_POST['end'];
        for($i=$start; $i<=$end; $i++){
            $check = true;
            for($j=2; $j<=$i*$i; $j++){
                if($i%$j==0&&$i!=$j){
                    $check=false;
                    break;
                }
            }

            if($check==false){
                $arr[] = $i;
            }
            else{
                $arr[]= "<b>$i</b>";
            }
        }
        echo implode(",",$arr);
    }
    ?>
</div>
</body>
</html>