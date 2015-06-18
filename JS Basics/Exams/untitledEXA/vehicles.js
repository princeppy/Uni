function solve(input) {
    var totalWheels = Number(input[0]);
    function countCoins(target, array) {
        'use strict';
        var targetsLength = target + 1;
        var arrayLength = array.length;
        target = [1];

        for (var a = 0; a < arrayLength; a ++) {
            for (var b = 1; b < targetsLength; b ++) {

                // initialise undefined target
                target[b] = target[b] ? target[b] : 0;

                // accumulate target + operand ways
                target[b] += (b < array[a]) ? 0 : target[b - array[a]];
            }
        }
        console.log(target);
        return target[targetsLength - 1];

    }


    console.log( countCoins(totalWheels,[3,4,10]));
    
}

solve([40]);