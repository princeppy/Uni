<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
        label {
            display: block;
        }

        select {
            display: inline-block;
        }

        input[type="submit"] {
            display: inline-block;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="amount">Enter Amount <input type="text" id="amount" name="amount"/></label>
    <input type="radio" name="currency" value="$"/>USD
    <input type="radio" name="currency" value="€"/>EUR
    <input type="radio" name="currency" value="lv"/>BGN
    <label for="compound">Compound Interest Amount <input type="text" id="compound" name="compound"/></label>
    <select name="interest" id="interest">
        <option value="6">6 months</option>
        <option value="12">1 year</option>
        <option value="24">2 years</option>
        <option value="60">5 years</option>
    </select>
    <input type="submit" value="Calculate" name="submit"/>
</form>
<?php
if (isset($_POST["submit"])) {
    $patternAmount = '/^\d+$/';
    $check = true;
    if (preg_match($patternAmount, $_POST["amount"])) {
        $amount = $_POST["amount"];
    } else {
        $check = false;
    }

    if (preg_match($patternAmount, $_POST["compound"])) {
        $compound = $_POST["compound"];
    } else {
        $check = false;
    }

    if ($check) {
        $months = $_POST["interest"];

        $interestPerMonth = (100 + $compound / 12) / 100;
        for ($i = 0; $i < $months; $i++) {
            $amount *= $interestPerMonth;
        }
        echo $_POST["currency"] . " " . number_format($amount, 2, ".", "");
    } else {
        echo "error";
    }


}
?>
</body>
</html>