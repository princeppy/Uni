<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>

</head>
<body>
<form method="post">
    <p>Enter HTML tags:</p>
    <input type="text" name="input-text"/>
    <input type="submit" name="submit"/>
    <input type="submit" name="clear-sessions" value="Clear sessions"/>
</form>
<?php
session_start();
if (isset($_POST["submit"])) {
    if (isset($_POST["input-text"])) {
        $text = $_POST["input-text"];
    } else {
        $text = "error";
    }

    $arr = array("!--...--", "!doctype", "a", "abbr", "address",
        "area", "article", "aside", "audio", "b", "base",
        "bdi", "bdo", "blockquote", "body", "br", "button",
        "canvas", "caption", "cite", "code", "col", "colgroup",
        "data", "datalist", "dd", "del", "details", "dfn",
        "dialog", "div", "dl", "dt", "em", "embed", "fieldset",
        "figcaption", "figure", "footer", "form", "h1", "h2",
        "h3", "h4", "h5", "h6", "head", "header", "hgroup",
        "hr", "html", "i", "iframe", "img", "input", "ins",
        "kbd", "keygen", "label", "legend", "li", "link", "main",
        "map", "mark", "menu", "menuitem", "meta", "meter", "nav",
        "noscript", "object", "ol", "optgroup", "option", "output",
        "p", "param", "pre", "progress", "q", "rb", "rp", "rt",
        "rtc", "ruby", "s", "samp", "script", "section", "select",
        "small", "source", "span", "strong", "style", "sub", "summary",
        "sup", "table", "tbody", "td", "template", "textarea",
        "tfoot", "th", "thead", "time", "title", "tr", "track",
        "u", "ul", "var", "video", "wbr");


    if (!isset($_SESSION["count"])) {
        $_SESSION["count"] = 0;
    }
    if (in_array($text, $arr)) {
        echo "Valid HTML Tag!";
        $_SESSION["count"]++;
    } else {
        echo "Invalid HTML Tag!";
    }

    echo "<br/>Score: " . $_SESSION["count"];
}

if (isset($_POST["clear-sessions"])){
    session_unset($_SESSION["count"]);
}

?>
</body>
</html>