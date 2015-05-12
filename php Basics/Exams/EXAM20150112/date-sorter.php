    <?php
    date_default_timezone_set('Europe/Sofia');
    $objects = $_GET['list'];
    $currDate = trim($_GET['currDate'],' ');
    $currDate = preg_replace('/\s+/',' ',$currDate);
    $currDate = date_parse($currDate);

    $currDate = DateTime::createFromFormat("d/m/Y",$currDate['day']."/".$currDate['month']."/".$currDate['year']);
    $currDate = $currDate;

    //var_dump($objects);


    $objects = preg_split('/\r?\n/',$objects,null,PREG_SPLIT_NO_EMPTY);
    $dates = [];
    foreach ($objects as $date) {

        $date = trim($date);

        if(!empty($date)){
            $dates[] = $date;
        }
    }
    //var_dump($dates);

    $validDates = [];
    foreach ($dates as $date) {
        if(date_parse($date)){
            $temp = date_parse($date);
    //        var_dump($temp);

            $temp1 = DateTime::createFromFormat("d/m/Y",$temp['day']."/".$temp['month']."/".$temp['year']);
            if($temp1){
                $validDates[] = $temp1;

            }
        }
    }

    asort($validDates);

    echo "<ul>";
    if(empty($validDates)){
        echo "<li></li>";
    }
    foreach ($validDates as $date) {
    //    var_dump($date);
        if($currDate>$date){

            echo "<li><em>".date_format($date,'d/m/Y')."</em></li>";
        }
        else{
            echo "<li>".date_format($date,'d/m/Y')."</li>";

        }

    }
    echo "</ul>";

    //var_dump($validDates);




