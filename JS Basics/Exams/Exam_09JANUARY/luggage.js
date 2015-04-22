function solve(input) {
    var result = {};
    var inside = {};
    for (var i in input) {
        if (i < input.length - 1) {
            var arrLine = input[i].split(/\.*\*\.*/g);

            var name = arrLine[0];
            var type = arrLine[1];
            var isFood = arrLine[2];
            var isDrink = arrLine[3];
            var isFragile = arrLine[4];
            var weight = Number(arrLine[5]);
            var transport = arrLine[6];


            inside = {kg: '', fragile: '', type: '', transferredWith: ''};
            inside.kg = weight;
            inside.fragile = isFragile==='true';
            if (isFood=='true') {
                inside.type = 'food';
            }
            else if (isDrink=='true') {
                inside.type = 'drink';
            }
            else {
                inside.type = 'other';
            }
            inside.transferredWith = transport;

            if (!result[name]) {
                result[name] = {};
            }
                result[name][type] = inside;





        }
        else {
            var sortType = input[i];
        }
    }

    if(sortType==='strict'){
        console.log(JSON.stringify(result));
    }
    else if(sortType==='luggage name'){
        for (var obj in result) {
            result[obj] = sortObj(result[obj])
        }
        console.log(JSON.stringify(result));
    }
    else if(sortType ==='weight'){
        var outputKgSort = {};
        Object.keys(result).forEach(function(key) {
            outputKgSort[key]={};
            var a = Object.keys(result[key]).sort(function (a,b) {
                return result[key][a].kg- result[key][b].kg;
            });
            a.forEach(function (value) {
                outputKgSort[key][value]= result[key][value];
            })
        });

        console.log(JSON.stringify(outputKgSort));
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

solve([
    'Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
    'strict'

])