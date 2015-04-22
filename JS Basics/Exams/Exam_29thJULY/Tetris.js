function solve(args) {
    var matrix = [];
    for (var i in args) {
        var line = args[i].split('');
        line.filter(function (a) {
            return a;
        })
        matrix.push(line);
    }
    var arr = {'I': 0, 'L': 0, 'J': 0, 'O': 0, 'Z': 0, 'S': 0, 'T': 0};

    //PATTERN I
    var PatternI = [
        ['o'],
        ['o'],
        ['o'],
        ['o']];
    var count = 0;
    if (matrix.length >= 4) {
        for (var col = 0; col <= matrix[0].length - PatternI[0].length; col++) {
            var counter = matrix.length - 4 + 1;

            for (var row = 0; row <= matrix.length - PatternI.length; row++) {
                if (matrix[row][col] !== PatternI[0][0] ||
                    matrix[row + 1][col] !== PatternI[1][0] ||
                    matrix[row + 2][col] !== PatternI[2][0] ||
                    matrix[row + 3][col] !== PatternI[3][0]) {
                    counter--;
                }
            }
            count += counter;
        }
        arr.I = count;
    }

    //PATTERN L
    var PatternL = [
        ['o'],
        ['o'],
        ['o', 'o'],
    ];
    var count = 0;
    if (matrix.length >= 3) {

        for (var col = 0; col <= matrix[0].length - PatternL[0].length; col++) {
            var counter = matrix.length - 3 + 1;

            for (var row = 0; row <= matrix.length - PatternL.length; row++) {
                if (matrix[row][col] !== PatternL[0][0] ||
                    matrix[row + 1][col] !== PatternL[1][0] ||
                    matrix[row + 2][col] !== PatternL[2][0] ||
                    matrix[row + 2][col + 1] !== PatternL[2][1]
                ) {
                    counter--;
                }
            }
            count += counter;
        }
        arr.L = count;
    }

    //PATTERN J
    var PatternJ = [
        ['x', 'o'],
        ['x', 'o'],
        ['o', 'o'],
    ];
    var count = 0;
    if (matrix.length >= 3) {
        for (var col = 0; col <= matrix[0].length - PatternJ[0].length; col++) {
            var counter = matrix.length - 3 + 1;

            for (var row = 0; row <= matrix.length - PatternJ.length; row++) {
                if (matrix[row][col + 1] !== PatternJ[0][1] ||
                    matrix[row + 1][col + 1] !== PatternJ[1][1] ||
                    matrix[row + 2][col + 1] !== PatternJ[2][1] ||
                    matrix[row + 2][col] !== PatternJ[2][0]) {
                    counter--;
                }
            }
            count += counter;
        }
        arr.J = count;
    }

    //PATTERN O
    var PatternO = [
        ['o', 'o'],
        ['o', 'o']];
    var count = 0;

    for (var col = 0; col <= matrix[0].length - PatternO[0].length; col++) {
        var counter = matrix.length - 2 + 1;

        for (var row = 0; row <= matrix.length - PatternO.length; row++) {
            if (matrix[row][col] !== PatternO[0][0] ||
                matrix[row + 1][col] !== PatternO[1][0] ||

                matrix[row][col + 1] !== PatternO[0][1] ||
                matrix[row + 1][col + 1] !== PatternO[1][1]) {
                counter--;
            }
        }
        count += counter;
    }
    arr.O = count;

    //PATTERN Z
    var PatternZ = [
        ['o', 'o', 'x'],
        ['x', 'o', 'o']];
    var count = 0;
    if (matrix[0].length >= 3) {
        for (var col = 0; col <= matrix[0].length - PatternZ[0].length; col++) {
            var counter = matrix.length - 2 + 1;

            for (var row = 0; row <= matrix.length - PatternZ.length; row++) {
                if (matrix[row][col] !== PatternZ[0][0] ||

                    matrix[row][col + 1] !== PatternZ[0][1] ||
                    matrix[row + 1][col + 1] !== PatternZ[1][1] ||

                    matrix[row + 1][col + 2] !== PatternZ[1][2]) {
                    counter--;
                }
            }
            count += counter;
        }
        arr.Z = count;
    }

    //PATTERN S
    var PatternS = [
        ['x', 'o', 'o'],
        ['o', 'o', 'x']];
    var count = 0;
    if (matrix[0].length >= 3) {
        for (var col = 0; col <= matrix[0].length - PatternS[0].length; col++) {
            var counter = matrix.length - 2 + 1;

            for (var row = 0; row <= matrix.length - PatternS.length; row++) {
                if (matrix[row + 1][col] !== PatternS[1][0] ||

                    matrix[row][col + 1] !== PatternS[0][1] ||
                    matrix[row + 1][col + 1] !== PatternS[1][1] ||

                    matrix[row][col + 2] !== PatternS[0][2]) {
                    counter--;
                }
            }
            count += counter;
        }
        arr.S = count;
    }

    //PATTERN T
    var PatternT = [
        ['o', 'o', 'o'],
        ['x', 'o', 'x']];
    var count = 0;
    if (matrix[0].length >= 3) {
        for (var col = 0; col <= matrix[0].length - PatternT[0].length; col++) {
            var counter = matrix.length - 2 + 1;

            for (var row = 0; row <= matrix.length - PatternT.length; row++) {
                if (matrix[row][col] !== PatternT[0][0] ||

                    matrix[row][col + 1] !== PatternT[0][1] ||
                    matrix[row + 1][col + 1] !== PatternT[1][1] ||

                    matrix[row][col + 2] !== PatternT[0][2]) {
                    counter--;

                }
            }
            count += counter;
        }
        arr.T = count;
    }
    console.log(JSON.stringify(arr));
}
//solve(['--o--o-', '--oo-oo', 'ooo-oo-', '-ooooo-', '---oo--'])