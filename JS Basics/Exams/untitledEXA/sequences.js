function solve(input) {

    var num = +input[0];
    input = input.slice(1);
    var result = 1;
    for (var i = 0, len = input.length; i < len; i += 1) {
        if (input[i] > input[i + 1])
            result++;

    }
    console.log(result);

}

solve([
    '7',
    '1',
    '2',
    '-3',
    '4',
    '4',
    '0',
    '1'

])

solve([
   '6',
   '1',
   '3',
   '-5',
   '8',
   '7',
   '-6'

])

solve([
    '9',
    '1',
    '8',
    '9',
    '7',
    '6',
    '5',
    '7',
    '7',
    '6'

])