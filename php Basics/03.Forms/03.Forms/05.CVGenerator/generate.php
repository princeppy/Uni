<?php
function validateData()
{
    $firstName = $_POST["first-name"];
    $lastName = $_POST["last-name"];
    $email = $_POST["email"];
    $phoneNumber = $_POST["tel"];
    $companyName = $_POST["company-name"];
    if (!preg_match("/^[A-Za-z]{2,20}$/", $_POST["first-name"])) {
        $firstName = "not valid";
    }
    if (!preg_match("/^[A-Za-z]{2,20}$/", $_POST["last-name"])) {
        $lastName = "not valid";
    }
    if (!preg_match("/^[A-Za-z0-9]{2,}@[A-Za-z0-9]{2,}\\.com|net|bg|org$/", $_POST["email"])) {
        $email = "not valid";
    }
    if (!preg_match("/\\+[\\d\\-\\s]+$/", $_POST["tel"])) {
        $phoneNumber = "not valid";
    }
    if (!preg_match("/^[A-Za-z]{2,20}$/", $_POST["company-name"])) {
        $companyName = "not valid";
    }

    return ["firstName" => $firstName,
        "lastName" => $lastName,
        "email" => $email,
        "phoneNumber" => $phoneNumber,
        "companyName" => $companyName
    ];
}

function printPersonalInfo()
{
    $arrData = validateData();
    $firstName = $arrData["firstName"];
    $lastName = $arrData["lastName"];
    $phoneNumber = $arrData["phoneNumber"];
    $email = $arrData["email"];
    $gender = $_POST["gender"];
    $birthDate = $_POST["birth"];
    $nationality = $_POST["nationality"];

    echo "<table>
    <th colspan='2'>Personal Information</th>
    <tr><td>First Name</td><td>$firstName</td></tr>
    <tr><td>Last Name</td><td>$lastName </td></tr>
    <tr><td>Email</td><td>$email</td></tr>
    <tr><td>Phone Number</td><td>$phoneNumber</td></tr>
    <tr><td>Gender</td><td>$gender</td></tr>
    <tr><td>Birth Date</td><td>$birthDate</td></tr>
    <tr><td>Nationality</td><td>$nationality</td></tr>
</table>";
}

function printWorkInfo()
{
    $arrData = validateData();
    $companyName = $arrData["companyName"];
    $from = $_POST["start-date"];
    $to = $_POST["end-date"];

    echo "<table>
    <th colspan='2'>Last Work Position</th>
    <tr><td>Company Name</td><td>$companyName</td></tr>
    <tr><td>From</td><td>$from </td></tr>
    <tr><td>To</td><td>$to</td></tr>

</table>";
}

function printComputerSkills()
{
    $count = $_POST["counterSkills"];

    echo "<table>
    <th colspan='3'>Computer Skills</th>
    <tr><td rowspan=" . (intval($count) + 2) . ">Programming Languages</td><td>Language</td><td>Skill Level</td></tr>";

    for ($i = 1; $i <= $count; $i++) {
        echo "<tr><td>" . $_POST["prog-lang-" . $i] . "</td><td>" . $_POST["level-" . $i] . "</td></tr>";

    }
    echo "</table>";
}

function printOtherSkills()
{
    $count = $_POST["counterLanguages"];

    echo "<table>
    <th colspan='5'>Computer Skills</th>
    <tr><td rowspan=" . (intval($count) + 1) . ">Languages</td><td>Language</td><td>Comprehension</td><td>Reading</td><td>Writing</td></tr>";

    for ($i = 1; $i <= intval($count); $i++) {
        echo "<tr><td>" . (isset($_POST["lang-" . $i]) ? $_POST["lang-" . $i] : 'not valid') . "</td>
        <td>" . (isset($_POST["lang-level-" . $i]) ? $_POST["lang-level-" . $i] : 'not valid') . "</td>
        <td>" . (isset($_POST["reading-" . $i]) ? $_POST["reading-" . $i] : 'not valid') . "</td>
        <td>" . (isset($_POST["writing-" . $i]) ? $_POST["writing-" . $i] : 'not valid') . "</td></tr>";
    }

    if (isset($_POST['check_list'])) {
        $arr = $_POST['check_list'];
        echo "<tr><td>Driver's License</td><td colspan='4'>" . implode(",", $arr) . "</td></tr>";
    } else {
        echo "<tr><td>Driver's License</td><td colspan='4'>no license</td></tr>";
    }

    echo "</table>";
}


function generateCV()
{
    echo "<h1>CV</h1>";
    printPersonalInfo();
    printWorkInfo();
    printComputerSkills();
    printOtherSkills();
}
