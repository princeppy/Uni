<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <link rel="stylesheet" href="styles/style.css"/>
    <script src="scripts/script.js"></script>
    <?php include 'generate.php'; ?>
</head>
<body>
<div>
    <form method="post">
        <input class="hide" type="text" name="counterSkills" id="counterSkills" value="1"/>
        <input class="hide" type="text" name="counterLanguages" id="counterLanguages" value="1"/>
        <fieldset>
            <legend>Personal Information</legend>
            <input class="block-input" type="text" name="first-name" placeholder="First Name"/>
            <input class="block-input" type="text" name="last-name" placeholder="Last Name"/>
            <input class="block-input" type="email" name="email" placeholder="Email"/>
            <input class="block-input" type="tel" name="tel" placeholder="Phone Number"/>

            <div>
                <label for="gender-female">Female</label><input type="radio" name="gender" id="gender-female"
                                                                value="Female" checked/>
                <label for="gender-male">Male</label><input type="radio" name="gender" id="gender-male" value="Male"/>
            </div>
            <label for="birth" class="title">Birth Date</label>
            <input type="date" id="birth" name="birth"/>
            <label for="nationality" class="title">Nationality</label>
            <select name="nationality" id="nationality">
                <option value="Bulgarian">Bulgarian</option>
                <option value="Greek">Greek</option>
                <option value="Turkish">Turkish</option>
                <option value="Romanian">Romanian</option>
            </select>
        </fieldset>

        <fieldset>
            <legend>Last Work Position</legend>
            <div>
                <label for="company">Company Name</label>
                <input type="text" id="company" name="company-name"/>
            </div>
            <div>
                <label for="start-date">From</label>
                <input type="date" id="start-date" name="start-date"/>
            </div>
            <div>
                <label for="end-date">To</label>
                <input type="date" id="end-date" name="end-date"/>
            </div>

        </fieldset>

        <fieldset>
            <legend>Computer Skills</legend>
            <div id="container-skills">
                <label class="title">Programming Languages</label>

                <div id="skill-1">
                    <input type="text" id="prog-lang-1" name="prog-lang-1"/>
                    <select name="level-1" id="level-1">
                        <option value="beginner">Beginner</option>
                        <option value="intermediate">Intermediate</option>
                        <option value="advanced">Advanced</option>
                    </select>
                </div>

            </div>
            <div>
                <input type="button" value="Remove Language" name="remove-lang" onclick="removeCompSkill()"/>
                <input type="button" value="Add Language" name="add-lang" onclick="addCompSkill()"/>
            </div>


        </fieldset>
        <fieldset>
            <legend>Other Skills</legend>
            <label class="title">Languages</label>

            <div id="container-language">
                <div id="language-1">
                    <input type="text" id="lang-1" name="lang-1"/>
                    <select name="lang-level-1" id="lang-level-1">
                        <option selected="selected" disabled="disabled">-Comprehension-</option>
                        <option value="beginner">Beginner</option>
                        <option value="intermediate">Intermediate</option>
                        <option value="advanced">Advanced</option>
                    </select>
                    <select name="reading-1" id="reading-1">
                        <option selected="selected" disabled="disabled">-Reading-</option>
                        <option value="beginner">Beginner</option>
                        <option value="intermediate">Intermediate</option>
                        <option value="advanced">Advanced</option>
                    </select>
                    <select name="writing-1" id="writing-1">
                        <option selected="selected" disabled="disabled">-Writing-</option>
                        <option value="beginner">Beginner</option>
                        <option value="intermediate">Intermediate</option>
                        <option value="advanced">Advanced</option>
                    </select>
                </div>
            </div>

            <div>
                <input type="button" value="Remove Language" name="remove-lang" onclick="removeLanguage()"/>
                <input type="button" value="Add Language" name="add-lang" onclick="addLanguage()"/>
            </div>

            <label class="title">Driver's License</label>

            <div>
                B<input type="checkbox" value="B" name="check_list[]"/>
                A<input type="checkbox" value="A" name="check_list[]"/>
                C<input type="checkbox" value="C" name="check_list[]"/>
            </div>

        </fieldset>
        <input type="submit" name="submit" value="Generate CV"/>
    </form>
</div>

<div>

    <?php
    if (isset($_POST["submit"])) {
        generateCV();

    }
    ?>

</div>


<!--<table>-->
<!--    <th>Personal Information</th>-->
<!--    <tr><td>First Name</td><td>". $_POST["firstName"] ."</td></tr>-->
<!--</table>-->
</body>
</html>
