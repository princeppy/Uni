function solve(args) {
    var matrix = [];
    var matrixResult = [];
    args.forEach(function (str) {

        var arrLine = str.split('');
        arrLine.filter(function (a) {
            return a
        });
        arrLine = arrLine.map(function (a) {
            return a.toLowerCase()
        });
        matrix.push(arrLine);

        var line = str.split('');
        line.filter(function (a) {
            return a
        });
        line = line.map(function (a) {
            return a
        });

        matrixResult.push(line);
    });


    for (var row = 1; row < matrix.length-1; row++) {
        for (var col = 0; col < matrix[row].length; col++) {
            var symbol = matrix[row][col];
            if (
                symbol == matrix[row - 1][col] &&
                symbol == matrix[row + 1][col] &&
                symbol == matrix[row][col - 1] &&
                symbol == matrix[row][col + 1]
            ) {
                matrixResult[row][col] = '';
                matrixResult[row - 1][col] = '';
                matrixResult[row + 1][col] = '';
                matrixResult[row][col - 1] = '';
                matrixResult[row][col + 1] = '';
            }

        }

    }
    //console.log(matrix);
    //matrix[0][0] = 555;
    //console.log(matrix);
    //console.log(matrixResult);


    for (var el in matrixResult) {

        console.log(matrixResult[el].join(''));
    }
}



//solve([
//    'ab**l5',
//    'bBb*555',
//    'absh*5',
//    'ttHHH',
//    'ttth'
//
//]);

solve(
    [
        'freee',
        'eeeeeeee',
        'eeeeeeee',
        'yourself',
        'freeeeee',
        'yourselef'
    ]
);

solve([
    'sos',
    'oSo',
    's0s'

])