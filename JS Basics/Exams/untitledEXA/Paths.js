function solve(input) {

    var arr = input[0].split(/\s+/);
    var rows = Number(arr[0].trim());
    var cols = Number(arr[1].trim());
    

    input = input.slice(1);

    var matrix = [];
    for (var i in input) {
        var line = input[i].split(/\s+/);
        matrix.push(line);
    }
    var matrixSum = [];
    for (var i = 0; i < rows; i++) {
        var start = Math.pow(2, i);
        matrixSum[i] = [];
        for (var j = 0; j < cols; j++) {
            matrixSum[i][j] = start;
            start++;
        }
    }


    var currRow = 0;
    var currCol = 0;

    var isEscaped = false;
    var isFailed = false;
    var sum = 1;
    while (true) {
        var cell = matrix[currRow][currCol];
        //console.log(currRow);
        //console.log(currCol);
        switch (cell) {
            case 'dr':
                if (currRow < (rows - 1) && currCol < (cols - 1)) {
                    currRow++;
                    currCol++;
                    if (matrixSum[currRow][currCol] === 'x') {
                        isFailed = true;
                    }
                    else {
                        sum += matrixSum[currRow][currCol];
                        matrixSum[currRow][currCol] = 'x';
                    }
                } else {
                    isEscaped = true;
                }
                break;
            case 'dl':
                if (currRow < (rows-1) && currCol > 0) {
                    currRow++;
                    currCol--;
                    if (matrixSum[currRow][currCol] === 'x') {
                        isFailed = true;
                    }
                    else {
                        sum += matrixSum[currRow][currCol];
                        matrixSum[currRow][currCol] = 'x';
                    }
                } else {
                    isEscaped = true;
                }
                break;
            case 'ur':
                if (currRow > 0 && currCol < (cols-1)) {
                    currRow--;
                    currCol++;
                    if (matrixSum[currRow][currCol] === 'x') {
                        isFailed = true;
                    }
                    else {
                        sum += matrixSum[currRow][currCol];
                        matrixSum[currRow][currCol] = 'x';
                    }
                } else {
                    isEscaped = true;
                }
                break;
            case 'ul':
                if (currRow > 0 && currCol > 0) {
                    currRow--;
                    currCol--;
                    if (matrixSum[currRow][currCol] === 'x') {
                        isFailed = true;
                    }
                    else {
                        sum += matrixSum[currRow][currCol];
                        matrixSum[currRow][currCol] = 'x';
                    }
                } else {
                    isEscaped = true;
                }
                break;



        }
        if (isEscaped) {
            console.log('successed with ' + sum);
            break;
        }
        if (isFailed) {
            console.log('failed at (' + currRow + ', ' + currCol + ')');
            break;
        }

    }
}

solve([
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
])

solve([
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
])