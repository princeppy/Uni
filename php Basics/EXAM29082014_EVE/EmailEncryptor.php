<?php
$recipient = htmlspecialchars($_GET['recipient']);
$subject = htmlspecialchars($_GET['subject']);
$body = htmlspecialchars($_GET['body']);
$key = $_GET['key'];

$formattedMessage = "<p class='recipient'>".$recipient."</p><p class='subject'>".$subject."</p><p class='message'>".$body."</p>";
$formattedMessage = ($formattedMessage);

$str = "|";
for($i=0; $i<strlen($formattedMessage); $i++){

    $char = ord($formattedMessage[$i]);
    $keyChar = ord($key[$i%strlen($key)]);
    $hex = base_convert(floatval($char*$keyChar),10,16);
    $str .= $hex."|";

}
//var_dump($formattedMessage);
echo "$str";