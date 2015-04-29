<?php

$text = $_GET['text'];

$arr = preg_split('/\r?\n/', $text, -1, PREG_SPLIT_NO_EMPTY);

$songs = [];


foreach ($arr as $line) {
    $arrLine = preg_split('/\s*\|\s*/', $line, -1, PREG_SPLIT_NO_EMPTY);
    $name = $arrLine[0];
    $genre = $arrLine[1];

    $arrArtists = preg_split('/\s*,\s*/',$arrLine[2],-1,PREG_SPLIT_NO_EMPTY);
    natcasesort($arrArtists);
    $downloads = $arrLine[3];
    $rating = $arrLine[4];

    $songs[$name]['genre'] = $genre;
    $songs[$name]['artists'] = $arrArtists;
    $songs[$name]['downloads'] = floatval($downloads);
    $songs[$name]['rating'] = floatval($rating);
}


$sort = $_GET['property'];
$order = $_GET['order'];

uasort($songs,function($song1, $song2){
   if($_GET['order']=='ascending'){
       if($_GET['property'] == 'name')
       return $song1 - $song2;
       else{
           return $song1[$_GET['property']]>$song2[$_GET['property']];
       }
   }else{
       if($_GET['property'] == 'name')
           return $song2 - $song1;
       else{
           return $song2[$_GET['property']]<$song1[$_GET['property']];
       }
   }

//    var_dump($song1[$_GET['property']]);
//    var_dump($song2);

});



//var_dump($songs);


echo "<table>\n";
echo "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";


foreach ($songs as $name=>$song) {

    if(in_array($_GET['artist'],$song['artists'])){
        echo "<tr><td>".$name."</td><td>".$song['genre']."</td><td>".implode(', ',$song['artists'])."</td><td>".$song['downloads']."</td><td>".$song['rating']."</td></tr>\n";
    }

}

echo "</table>";

