function solve(input){
    var arr = input[0].split(/\s+/);
    arr =arr.filter(function(a){return a}).map(Number);

    input = input.slice(1);
    var rows = arr[0];
    var cols = arr[1];
    var num = 1;
    var matrix = [];
    for(var i= 0;i<rows;i+=1){
        matrix.push([]);
        for(var j= 0;j<cols;j+=1){
            matrix[i].push(num);
            num++;
        }
    }
    var rowsCols = input[0].split(/\s+/).filter(function(a){return a}).map(Number);
    var currRow = rowsCols[0];
    var currCol = rowsCols[1];
    var sum = matrix[currRow][currCol];
    input = input.slice(1);
    var isEscaped = false;
    var isCatched = false;
    var jumps = -1;
    while(true) {
        jumps++;
        for (var obj in input) {
            var arrLine = input[obj].split(/\s+/).filter(function (a) {
                return a
            }).map(Number);
            var deltaRow = currRow + arrLine[0];
            var deltaCol = currCol + arrLine[1];
            //console.log(matrix[deltaRow]);
            //console.log(matrix[deltaRow][deltaCol]);
            if (!matrix[deltaRow] || !matrix[deltaRow][deltaCol]) {
                isEscaped = true;

                break;
            }
            if (matrix[deltaRow][deltaCol] === 'x') {
                isCatched = true;
                break;
            }

            currRow = currRow + arrLine[0];
            currCol = currCol + arrLine[1];
            sum += matrix[currRow][currCol];
            matrix[currRow][currCol] = 'x';

        }

        if(isEscaped){

            console.log("escaped " + sum);
            return;

        }



        if(isCatched){
            console.log("caught " +jumps);
            return;
        }
    }
    if(k===arr[2]){
        console.log("escaped "+sum);
    }

    //console.log(matrix);
}



solve([
    '500 500 3',
    '0 0',
    '1 1',
    '1 2',
    '-1 -3'
])