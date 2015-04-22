function solve(input) {
    var result = {students: [], trainers: []};
    var arr = input[0].split('^');
    var sortStudents = arr[0];
    var sortTrainers = arr[1];
    for (var i = 1; i < input.length; i++) {
        var arr = JSON.parse(input[i]);
        if (arr['role'] === 'student') {
            var st = arr;

            var grades = st['grades'].map(function (x) {
                return parseFloat(x)
            });

            var a = averageArray(grades);
            st['averageGrade'] = a;
            var b = st['certificate'];
            delete st['certificate'];
            st['certificate'] = b;
            result.students.push(st);

        }

        if (arr['role'] == 'trainer') {
            var tr = arr;
            result.trainers.push(tr);
        }
    }

    if(sortStudents=='name') {

        result.students.sort(function (a, b) {
            if(a['firstname']==b['firstname']){
                return a['lastname'].localeCompare(b['lastname']);
            }
            return a['firstname'].localeCompare( b['firstname']);
        })
    }

    if(sortStudents=='level') {

        result.students.sort(function (a, b) {
            if(Number(a['level'])==Number(b['level'])){
                return Number(a['id']) - Number(b['id']);
            }
            return Number(a['level']) - Number(b['level']);
        })
    }

    result.trainers.sort(function (a, b) {
        if(a['courses'].length==b['courses'].length){
            return Number(a['lecturesPerDay']) - Number(b['lecturesPerDay']);
        }
        return a['courses'].length - b['courses'].length;
    })

    for (var obj in result) {
        for (var obj1 in result[obj]) {
            delete result[obj][obj1]['level'];
            delete result[obj][obj1]['role'];
            delete result[obj][obj1]['town'];
            delete result[obj][obj1]['grades'];
        }
    }
    console.log(JSON.stringify(result))


    function averageArray(arr) {
        var sum = arr.reduce(function (a, b) {
            return a + b;
        });
        var avg = sum / arr.length;
        return avg.toFixed(2);
    }


    function sortObj(arr) {
// Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};

// Separate keys and sort them
        for (var i in arr) {
            sortedKeys.push(i);

        }
        sortedKeys.sort();

// Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];

        }
        return sortedObj;

    }



}

//solve([
//    'name^courses',
//    '{"id":0,"firstname":"Angel","lastname":"petrov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//    '{"id":2,"firstname":"Aishe","lastname":"Window","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
//
//])

solve([
   'level^courses',
   '{"id":0,"firstname":"Hristiqn","lastname":"Petrov","town":"Sofia","role":"student","grades":["4.06","5.17"],"level":5,"certificate":false}',
   '{"id":1,"firstname":"Angel","lastname":"Petrov","town":"Sofia","role":"trainer","courses":["Java","JS OOP"],"lecturesPerDay":6}',
   '{"id":2,"firstname":"Gergana","lastname":"Nakov","town":"Sliven","role":"trainer","courses":["Java","JS OOP","SDA"],"lecturesPerDay":5}',
   '{"id":3,"firstname":"Angel","lastname":"Nakova","town":"Burgas","role":"trainer","courses":["Database","JS OOP","JS","C#","iOS","HTML/CSS"],"lecturesPerDay":6}',
   '{"id":4,"firstname":"Petq","lastname":"Nakova","town":"Petrich","role":"student","grades":["5.14"],"level":4,"certificate":true}',
   '{"id":5,"firstname":"Julieta","lastname":"Petrov","town":"Svishtov","role":"trainer","courses":["iOS","OOP","JS","C#","Java"],"lecturesPerDay":6}',
   '{"id":6,"firstname":"Ivan","lastname":"Ivanov","town":"Stara Zagora","role":"student","grades":["5.28","2.15","4.25","4.95"],"level":2,"certificate":true}',
   '{"id":7,"firstname":"Gergana","lastname":"Daskalov","town":"Sofia","role":"trainer","courses":["PHP","ASP.NET","SDA"],"lecturesPerDay":5}',
   '{"id":8,"firstname":"Qvor","lastname":"Dimitrov","town":"Sevlievo","role":"student","grades":["4.30","3.14","4.09","4.08","2.25"],"level":5,"certificate":true}',
   '{"id":9,"firstname":"Petq","lastname":"Nakov","town":"Gabrovo","role":"trainer","courses":["JS Apps","Java","JS","iOS","SDA","HTML/CSS"],"lecturesPerDay":9}',
   '{"id":10,"firstname":"Bobi","lastname":"Nakov","town":"Gabrovo","role":"student","grades":["3.80"],"level":1,"certificate":false}'

])