function solve(input) {
    var n = Number(input[0]);
    input = input.slice(1);
    //console.log(input);

    var currentSum = 0;
    var currentMax = 0;
    var arr = [];

    for (var j=0; j < input.length; j++)
    {
        currentSum += Number(input[j]);
        //console.log(currentSum);

        if (currentMax < currentSum)
            currentMax = currentSum;
        else if (currentSum < 0){
            currentSum = 0;
        }
    }

    console.log(currentMax);
}


solve([
    '8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'

])