<?php

$text = $_GET['text'];

$match = preg_match_all('/(\<a\s*?href)=(.+?(?=\>)(>))/',$text,$matches);


$aTag = $matches[1][0];

$linksToReplace = $matches[2];

$text = preg_replace("/$aTag/","[URL",$text);


foreach ($linksToReplace as $link) {
    $rep = preg_quote($link,"/+*?[^]$(){}=!<>|:-");
    $text = preg_replace("/$rep/",substr($link,0,strlen($link)-1)."]",$text);
    $text = preg_replace("/\\<\\/a\\>/","[/URL]",$text);
}


echo $text;






