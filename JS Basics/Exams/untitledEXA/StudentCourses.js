function baaasiRukiteChuek(input) {

    var pattern = /([A-Za-z\s]+)\s*\|\s*(.+?(?=\|))\s*\|\s*([^\|]+)\s*\|\s*(.+)/;

    var result = [];
    for (var i in input) {
        var match = pattern.exec(input[i]);
        //console.log(match);
        var name = match[1].trim();
        var courseName = match[2].trim();
        var mark = parseFloat(match[3].trim());
        var visits = parseFloat(match[4].trim());

        var courseExist = false;
        for (var j in result) {

            if (result[j].course === courseName) {
                result[j].avgGrade.push(mark);
                result[j].avgVisits.push(visits);
                if (result[j].students.indexOf(name) < 0) {
                    result[j].students.push(name);
                }
                courseExist = true;
            }
            result[j].students.sort(function (a, b) {
                return a.localeCompare(b);
            });
        }
        if (!courseExist) {
            result.push({'course': courseName, 'avgGrade': [mark], 'avgVisits': [visits], 'students': [name]});
        }
    }

    for (var obj in result) {

        result[obj].avgGrade = parseFloat(averageArray(result[obj].avgGrade));
        result[obj].avgVisits = parseFloat(averageArray(result[obj].avgVisits));
    }

    result.sort(function (a, b) {
        return a.course.localeCompare(b.course);
    })

var finalResult = {};
    for (var obj1 in result) {
        finalResult[result[obj1].course] = {'avgGrade':result[obj1].avgGrade,'avgVisits':result[obj1].avgVisits,'students':result[obj1].students};
    }

    console.log(JSON.stringify(finalResult));


//Custom
    function averageArray(arr) {
        var sum = arr.reduce(function (a, b) {
            return a + b;
        });
        var avg = sum / arr.length;
        return avg.toFixed(2);
    }
}

baaasiRukiteChuek([
'    Milen Georgiev|PHP|2.02|2',
'    Ivan Petrov | C# Basics | 3.20 | 22',
'Peter Nikolov | C# | 5.522 | 18',
'Maria Kirova | C# Basics | 5.40 | 4.5',
'Stanislav Peev | C# | 4.012 | 15',
'Ivan Petrov |    PHP Basics     |     5.120 |6',
'Ivan Goranov | SQL | 5.926 | 12',
'Todor Kirov | Databases | 5.50 |0.0000',
'Maria Ivanova | Java | 5.83 | 37',
'Milena Ivanova |    C# |   1.823 | 4.5',
'Stanislav Peev   |    C#|   4.122    |    15',
'Kiril Petrov |PHP| 5.10 | 6',
'Ivan Petrov|SQL|5.926|3',
'Peter Nikolov   |    Java  |   5.9996    |    9',
'Stefan Nikolov | Java | 4.00 | 9.5',
'Ivan Goranov | SQL | 5.926 | 12.5',
'Todor Kirov | Databases | 5.150 |0.0000',
'Kiril Ivanov | Java | 5.083 | 327',
'Diana Ivanova |    C# |   1.823 | 4',
'Stanislav Peev   |    C#|   4.122    |    15',
'Kiril Petrov |PHP| 5.10 | 6'

]);

