<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
</head>
<body>
<form method="post">
    Enter tags:
    <input type="text" name="input-text"/>
    <input type="submit" name="submit"/>
</form>
<?php
if (isset($_POST["submit"])) {
    if (isset($_POST["input-text"])) {
        $arr = explode(", ", $_POST["input-text"]);
    }
    $arrFinal = array();
    foreach ($arr as $value) {
        if (array_key_exists($value, $arrFinal)) {
            $var = $arrFinal[$value];
            $arrFinal[$value]++;
        } else {
            $arrFinal[$value] = 1;
        }
    }
    unset($value);
    arsort($arrFinal);
    foreach ($arrFinal as $key => $value) {
        echo $key . " : " . $value . ($value === 1 ? " time" : " times") . "<br/>";
    }
    $mostFrequent = max(array_keys($arrFinal));
    echo "<br/>   Most frequent tag is: " . $mostFrequent;
    unset($value);
    unset($key);
}

?>
</body>
</html>