<?php
date_default_timezone_set('Europe/Sofia');
$str = $_GET['text'];

$arr = preg_split('/\r?\n/',$str);



foreach ($arr as $text)
{
    echo "<div>\n";
preg_match('/\%/',$text,$matches,PREG_OFFSET_CAPTURE);

$title = trim(substr($text,0,$matches[0][1]));
$text = substr($text,$matches[0][1]+1);

preg_match('/\;/',$text,$matches,PREG_OFFSET_CAPTURE);

$author =trim(substr($text,0,$matches[0][1]));
$text = substr($text,$matches[0][1]+1);

preg_match('/\-/',$text,$matches,PREG_OFFSET_CAPTURE);

$day = trim(substr($text,0,$matches[0][1]));
$text = substr($text,$matches[0][1]+1);

preg_match('/\-/',$text,$matches,PREG_OFFSET_CAPTURE);


$monthNum = trim(substr($text,0,$matches[0][1]));
$month = date('F', mktime(0, 0, 0, intval($monthNum), 10));
$text = substr($text,$matches[0][1]+1);

preg_match('/\-/',$text,$matches,PREG_OFFSET_CAPTURE);

$year = trim(substr($text,0,$matches[0][1]));
$text = substr($text,$matches[0][1]+1);

$content = trim($text);
//var_dump($content);

if(strlen($content)>100){
    $content = substr($content,0,100)."...";
}
    else{
        $content = $content  . '...';
    }

//var_dump($title);
//var_dump($author);
//var_dump($day);
//var_dump($month);
//var_dump($year);


echo "<b>Topic:</b> <span>$title</span>\n";
echo "<b>Author:</b> <span>$author</span>\n";
echo "<b>When:</b> <span>$month</span>\n";
echo "<b>Summary:</b> <span>$content</span>\n";
    echo "</div>\n";
}



//var_dump($end);
