function listySharp(input) {

    var variables = {};
    for (var obj in input) {
        var regex = new RegExp('(.+(?=\\[))?\\[(.+(?=\\]))]');
        var match = regex.exec(input[obj]);


        if (match[1]) {
            var arr = match[1].split(/\s+/);
            arr = arr.filter(function (a) {
                return a !== '';

            })
            //console.log(arr);


            if (arr[0].toLowerCase() === 'def') {
                if (arr[2]) {
                    var arrLine = match[2].split(/,\s*/);
                    arrLine = arrLine.filter(function (a) {
                        return a !== '';
                    })
                    arrLine = arrLine.map(function (a) {
                        return a.trim();
                    })


                    //switch (arr[2].toLowerCase()) {
                    //    case 'sum':
                    //        sum(arrLine);
                    //        break;
                    //    case 'min':
                    //        min(arrLine);
                    //        break;
                    //    case 'max':
                    //        max(arrLine);
                    //        break;
                    //        break;
                    //    case 'avg':
                    //        break;
                    //
                    //}
                }
                else {
                    var arrLine = match[2].split(/,\s*/);
                    arrLine = arrLine.filter(function (a) {
                        return a !== '';
                    })
                    variables[arr[1]] = arrLine;
                }
            }

        }
        console.log(match);


    }
    //console.log(variables);
function sum(arrLine){
    var sum = 0;

    for (var obj1 in arrLine) {
        if (Number(arrLine[obj1])) {
            sum += Number(arrLine[obj1]);
        }
        else {

            if (Number(variables[arrLine[obj1]])) {
                sum += Number(variables[arrLine[obj1]]);
            }
            else {

                for (var obj2 in variables[arrLine[obj1]]) {
                    if(Number(variables[arrLine[obj1]][obj2])) {
                        sum += Number(variables[arrLine[obj1]][obj2]);
                    }
                    else{
                        for (var obj3 in variables[variables[arrLine[obj1]][obj2]]) {
                            sum+=Number(variables[variables[arrLine[obj1]][obj2]][obj3]);
                        }
                    }
                }
            }
        }
    }
    variables[arr[1]] = sum;
}
    function min(arrLine){
        var min = Infinity;
        for (var obj2 in arrLine) {

            if (Number(arrLine[obj2])) {

                if (min) {
                    if (Number(arrLine[obj2]) < min) {
                        min = Number(arrLine[obj2]);
                    }
                }
                else {
                    min = Number(arrLine[obj2]);
                }
            }

            else {

                if (Number(variables[arrLine[obj2]])) {

                    if (Number(variables[arrLine[obj2]]) < min) {
                        min = Number(variables[arrLine[obj2]]);
                    }

                }
                else {
                    variables[arrLine[obj2]] = variables[arrLine[obj2]].map(function (a) {
                        return Number(a);
                    })

                    if (Math.min.apply(Math, variables[arrLine[obj2]]) < min) {
                        min = Math.min.apply(Math, variables[arrLine[obj2]]);
                    }
                }
            }
        }
        //console.log(arr[1]);
        variables[arr[1]] = min;
    }

    function max(arrLine){
        var max = -Infinity;
        for (var obj3 in arrLine) {

            if (Number(arrLine[obj3])) {

                if (max) {
                    if (Number(arrLine[obj3]) > max) {
                        max = Number(arrLine[obj3]);
                    }
                }
                else {
                    max = Number(arrLine[obj3]);
                }
            }

            else {

                if (Number(variables[arrLine[obj3]])) {

                    if (Number(variables[arrLine[obj3]]) > max) {
                        max = Number(variables[arrLine[obj3]]);
                    }

                }
                else {
                    variables[arrLine[obj3]] = variables[arrLine[obj3]].map(function (a) {
                        return Number(a);
                    })

                    if (Math.max.apply(Math, variables[arrLine[obj3]]) > max) {
                        max = Math.max.apply(Math, variables[arrLine[obj3]]);
                    }
                }
            }
        }
        //console.log(arr[1]);
        variables[arr[1]] = max;
    }
}
listySharp([
    '  def func sum [5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'

])

listySharp([
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]',

])