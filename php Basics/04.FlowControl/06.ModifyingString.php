<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>

</head>
<body>
<div id="wrapper">

    <form method="post">
        <label for="">Input string: </label><input type="text" name="text" placeholder="Enter comma separated string"/>
        <input type="radio" id="palindrome" name="option" value="palindrome"/><label for="palindrome">Check Palindrome</label>
        <input type="radio" id="reverse" name="option" value="reverse"/><label for="reverse">Reverse String</label>
        <input type="radio" id="split" name="option" value="split"/><label for="split">Split</label>
        <input type="radio" id="hash" name="option" value="hash"/><label for="hash">Hash String</label>
        <input type="radio" id="shuffle" name="option" value="shuffle"/><label for="shuffle">Shuffle String</label>
        <input type="submit" name="submit"/>
    </form>
    <?php

    if (isset($_POST['submit'])) {

        $text = $_POST['text'];
        $value = $_POST['option'];
        echo "Selected option: $value <br/>";
        if($value=='palindrome'){
            $check = true;
            for($i=0; $i<strlen($text)/2; $i++){

                if($text[$i]!== $text[strlen($text)-1-$i]){

                    $check = false;
                    break;
                }
            }
            if($check){
                echo "$text is palindrome";
            }
            else{
                echo "$text is not a palindrome";
            }

        }

        else if($value=='reverse'){
            echo strrev($text);
        }

        else if($value =='split'){
            $arr =  str_split($text,1);
            echo implode(' ',$arr);
        }

        else if($value=='hash'){
            echo hash("sha384",$text);
        }

        else if($value=='shuffle'){
            $arr =  str_split($text,1);
            shuffle($arr);
            echo implode('',$arr);
        }
    }
    ?>
</div>
</body>
</html>