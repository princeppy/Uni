function solve(input) {

    var result = {};

    for (var i in input) {

        var arr = input[i].split('|');
        var group = arr[0].trim();
        var city = arr[1].trim();
        var date = arr[2].trim();
        var stadium = arr[3].trim();
        if (result[city] == undefined) {
            result[city] = {};
            result[city][stadium] = [];
            result[city][stadium].push(group);
        }
        else {
            if (result[city][stadium] == undefined) {
                result[city][stadium] = [];
            }
            if (result[city][stadium].indexOf(group) == -1) {
                result[city][stadium].push(group);
            }

        }

        result[city][stadium].sort();
        result[city] = sortObj(result[city]);
    }
    result = sortObj(result);
    //console.log(JSON.stringify(result))
    console.log(result)


    function sortObj(arr) {
// Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};

// Separate keys and sort them
        for (var i in arr) {
            sortedKeys.push(i);

        }
        sortedKeys.sort(function (a, b) {
            return a.localeCompare(b) < 0 ? -1 : a.localeCompare(b) > 0 ? 1 : 0;
        });

// Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];

        }
        return sortedObj;

    }
}


solve([
    'ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
    'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
    'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
    'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
    'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
    'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
    'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
    'Helloween | London | 28-Jul-2014 | Wembley Stadium',
    'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
    'Metallica | London | 03-Oct-2014 | Olympic Stadium',
    'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
    'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium'

])