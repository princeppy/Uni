<?php

$text = $_GET['text'];
$banList = preg_split('/\s*,\s*/',$_GET['banlist'],null,PREG_SPLIT_NO_EMPTY);


foreach ($banList as $ban) {
    $replace = str_repeat("*",strlen($ban));
    $text=preg_replace("/$ban/",$replace,$text);
}

echo "$text";






