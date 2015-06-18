function horsyIsTDaMan(input) {

    var arr = input[0].split(" ");
    var row = Number(arr[0]);
    var col = Number(arr[1]);

    input = input.slice(1);

    var matrix = [];
    var matrixSum = [];
    for (var i in input) {
        var line = [];
        var line1 = [];
        var power = Number(i);
        var num = Math.pow(2, power);
        //console.log(num);
        for (var j = 0; j < input[i].length; j++) {
            line1.push(num);
            line.push(Number(input[i][j]));
            num--;

        }
        matrix.push(line);
        matrixSum.push(line1);
    }

    var currRow = row - 1;
    var currCol = col - 1;
    var sum = matrixSum[currRow][currCol];

    var jumps = 1;

    var isOut = false;
    var isDoomed = false;

    var command = Number(matrix[currRow][currCol]);
    while (!isDoomed && !isOut) {
        matrixSum[currRow][currCol] = 'x';
        switch (command) {
            case 1:
                currRow -= 2;
                currCol += 1;
                break;
            case 2:
                currRow -= 1;
                currCol += 2;
                break;
            case 3:
                currRow += 1;
                currCol += 2;
                break;
            case 4:
                currRow += 2;
                currCol += 1;
                break;
            case 5:
                currRow += 2;
                currCol -= 1;
                break;
            case 6:
                currRow += 1;
                currCol -= 2;
                break;
            case 7:
                currRow -= 1;
                currCol -= 2;
                break;
            case 8:
                currRow -= 2;
                currCol -= 1;
                break;
        }

        if (currCol < 0 || currRow < 0 || currCol > col - 1 || currRow > row - 1) {
            isOut = true;
            break;
        }
        else {

            if (matrixSum[currRow][currCol] === 'x') {
                isDoomed = true;
                break;
            }
            sum += matrixSum[currRow][currCol];
            //matrixSum[currRow][currCol]='x';
            jumps++;
            //console.log([currRow] + "," + [currCol]);
        }
        command = Number(matrix[currRow][currCol])
    }
    if (isOut) {
        console.log('Go go Horsy! Collected ' + sum + ' weeds');
    }
    if (isDoomed) {
        console.log('Sadly the horse is doomed in ' + jumps + ' jumps');
    }

}
horsyIsTDaMan([
    '3 5',
    '54561',
    '43328',
    '52388',

])

horsyIsTDaMan([
    '3 5',
    '54361',
    '43326',
    '52188',
])