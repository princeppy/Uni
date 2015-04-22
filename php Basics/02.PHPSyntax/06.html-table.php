<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <style>
        .orange {
            background-color: orange;
            font-weight: bold;
        }

        table, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 5px;
        }

        .right-col {
            text-align: right;
        }
    </style>
</head>
<body>
<?php

$person = array(
    "Name" => "Gosho",
    "Phone number" => "0882-321-423",
    "Age" => 24,
    "Address" => "Hadji Dimitar"
);

echo "<table>
        <tr><td class='orange'>Name</td><td class='right-col'>" . $person["Name"] . "</td></tr>
        <tr><td class='orange'>Phone number</td><td class='right-col'>" . $person["Phone number"] . "</td></tr>
        <tr><td class='orange'>Age</td><td class='right-col'>" . $person["Age"] . "</td></tr>
        <tr><td class='orange'>Address</td><td class='right-col'>" . $person["Address"] . "</td></tr>
      </table>";
?>
</body>
</html>

