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
if(isset($_POST["submit"])) {
    if(isset($_POST["input-text"])){
        $arr = explode(", ",$_POST["input-text"]);
    }
}
foreach($arr as $key=>$value)
{
    echo $key . " : " . $value . "<br/>";
}
unset($value);
unset($key);
?>
</body>
</html>