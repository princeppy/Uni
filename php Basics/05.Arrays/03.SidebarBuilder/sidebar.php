<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        aside{

            display: flex;
            flex-flow: column wrap;
            justify-content: space-around;
            width: 20%;
        }

        aside>section{
            background: dodgerblue;
            width: auto;
            margin: 20px;
            border: 1px solid black;
            border-radius: 10px;
            padding: 10px;
        }
        ul{
            width: auto;
            list-style-type: circle;
            padding: 0;
            margin: 0;
        }
        a{
            color: black;

        }
        li{
            margin: 10px 30px;
        }
        h2{
            width: auto;
            padding: 0;
            margin: 0;
        }


    </style>
</head>
<body>
<?php

$categories = preg_split('/\s*,\s*/',$_GET['categories'],null,PREG_SPLIT_NO_EMPTY);
$tags = preg_split('/\s*,\s*/',$_GET['tags'],null,PREG_SPLIT_NO_EMPTY);
$months = preg_split('/\s*,\s*/',$_GET['months'],null,PREG_SPLIT_NO_EMPTY);

//
//var_dump($categories);
//var_dump($tags);
//var_dump($months);

echo "<aside>";
//categories
echo "<section><h2>Categories</h2><ul>";
foreach ($categories as $value) {
    echo "<li><a href='#'>$value</a></li>";
}
echo "</ul></section>";
//tags
echo "<section><h2>Tags</h2><ul>";
foreach ($tags as $value) {
    echo "<li><a href='#'>$value</a></li>";
}
echo "</ul></section>";
//months
echo "<section><h2>Months</h2><ul>";
foreach ($months as $value) {
    echo "<li><a href='#'>$value</a></li>";
}
echo "</ul></section>";

echo "</aside>";
?>
</body>
</html>



