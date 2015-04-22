function solve(args) {
    var result = {};
    for (var index in args) {
        var arr = args[index].split('|')

        var name = arr[0].trim();
        var course = arr[1].trim();
        var mark = Number(arr[2].trim());
        var visits = Number(arr[3].trim());


        if (!(course in result)) {

            var value = {};
            result[course] = value;
            value['avgGrade'] = [];
            value['avgVisits'] = [];
            value['students'] = [];

            value['avgGrade'].push(mark);
            value['avgVisits'].push(visits);
            value['students'].push(name);
        }
        else {
            var value = result[course];
            value['avgGrade'].push(mark);
            value['avgVisits'].push(visits);
            if (value['students'].indexOf(name) === -1) {
                value['students'].push(name);
            }
        }
    }
    var courses = Object.keys(result).sort();
    var final = {};
    for (var i in courses) {
        var info={avgGrade: calcAverage(result[courses[i]]['avgGrade']), avgVisits: calcAverage(result[courses[i]]['avgVisits']),
            students: (result[courses[i]]['students']).sort()};



        final[courses[i]] = info;

    }

    function calcAverage(ar) {
        var av = 0;
        for (var ob in ar) {
            av += ar[ob];
        }
        av = av / ar.length;
        av = Number(av.toFixed(2));


        return av;
    }


    console.log( JSON.stringify(final));

}
//
//solve(['Peter Nikolov | PHP  | 5.50 | 8',
//    'Maria Ivanova | Java | 5.83 | 7',
//    'Ivan Petrov   | PHP  | 3.00 | 2',
//    'Ivan Petrov   | C#   | 3.00 | 2',
//    'Peter Nikolov | C#   | 5.50 | 8',
//    'Maria Ivanova | C#   | 5.83 | 7',
//    'Ivan Petrov   | C#   | 4.12 | 5',
//    'Ivan Petrov   | PHP  | 3.10 | 2',
//    'Peter Nikolov | Java | 6.00 | 9'])

