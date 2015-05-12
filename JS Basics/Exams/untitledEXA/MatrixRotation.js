function zaebiChuek(input) {

    var pattern = /Rotate\((\d+)\)/;

    var match = pattern.exec(input[0]);

    var degrees = parseInt(match[1]);

    input.splice(0, 1);


    var matrix = createMatrix(input);


    if((degrees/90)%4==0){
        for (var i = 0; i < matrix.length; i++) {
            var row = '';
            for (var j = 0; j < matrix[0].length; j++) {
                row+=matrix[i][j];
            }
            console.log(row);
        }
    }else if((degrees/90)%4==1){
        rotate90(matrix);
    }else if((degrees/90)%4==2){
        rotate180(matrix);
    }else if((degrees/90)%4==3){
        rotate270(matrix);
    }

    function rotate90(matrix) {
        var count = matrix[0].length;
        for (var j = 0; j < count; j++) {
            var row = '';
            for (var i = matrix.length - 1; i >= 0; i--) {
                row += matrix[i][j];
            }
            console.log(row);
        }
    }

    function rotate180(matrix) {
        var count = matrix[0].length;
        for (var i = matrix.length-1; i >=0; i--) {
            var row = '';
            for (var j = count-1; j >=0; j--) {
               row+=matrix[i][j];

            }
            console.log(row);
            
        }
    }

    function rotate270(matrix) {
        var count = matrix[0].length;
        for (var j = count-1; j >=0; j--) {
            var row = '';
            //console.log();
            for (var i = 0; i <matrix.length; i++) {
                row += matrix[i][j];
            }
            console.log(row);
        }
    }



    function createMatrix(input) {
        var max = 0;
        for (var i = 0; i < input.length; i++) {
            var temp = input[i].length;
            if (temp > max) {
                max = temp;
            }

        }
        var arrFinal = [];
        for (var i = 0; i < input.length; i++) {
            var arr = [];
            for (var j = 0; j < max; j++) {
                if (j < input[i].length) {
                    arr.push(input[i][j]);
                } else {
                    arr.push(' ');
                }

            }
            arrFinal.push(arr);

        }
        return arrFinal;
    }


}

zaebiChuek([
    'Rotate(0)',
    'hello',
    'softuni',
    'exam'
]);