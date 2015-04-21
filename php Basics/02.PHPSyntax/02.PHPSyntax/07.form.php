<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <style>
        input {
            display: block;
            margin: 10px;
        }

        input[type="radio"] {
            display: inline-block;
        }
    </style>
</head>
<body>
<form method="post">
    <input type="text" placeholder="Name..." name="name" pattern="[A-Za-z0-9\s]+" required="required"/>
    <input type="text" PLACEHOLDER="Age..." name="age" pattern="\d+" required="required"/>
    <input type="radio" name="gender" value="male" required="required"/>Male
    <input type="radio" name="gender" value="female" required="required"/>Female
    <input type="submit"/>
</form>
<?php

$name = isset($_POST['name'])? $_POST['name']:"[name not set]";
$age = isset($_POST['age'])? $_POST['age']:"[age not set]";
$gender = isset($_POST['gender'])? $_POST['gender']:"[gender not set]";

echo "My name is $name. I am $age years old. I am $gender.";
?>
</body>
</html>