function solve(input) {
    var S = Number(input[0]);
    var c1 = Number(input[1]);
    var c2 = Number(input[2]);
    var c3 = Number(input[3]);
    function countCoins(target, array) {
        'use strict';
        var targetsLength = target;
        var arrayLength = array.length;
        target = [1];

        for (var a = 0; a < arrayLength; a ++) {
            for (var b = 1; b < targetsLength; b ++) {

                // initialise undefined target
                target[b] = target[b] ? target[b] : 0;

                // accumulate target + operand ways
                target[b] += (b < array[a]) ? 0 : array[a];
            }

        }
        console.log(target);

        return target[targetsLength-1];
    }


    console.log( countCoins(S,[c1,c2,c3]));
}

solve([
    '110',
    '19',
    '29',
    '39'
]);