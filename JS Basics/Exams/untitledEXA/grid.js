function deeeebaIzpitaDeeeba(input) {
    var message = input[0];
    var magic = Number(input[1].trim());
    input.splice(0, 2);

    var matrix = [];
    for (var obj in input) {
        var line =input[obj].split(/\s+/);
            line = line.filter(function(a){
                return a!='';
            })
        matrix.push(line);

    }

    //console.log(matrix);
    var finalSum = 0;
    var found = false;
    for (var row in matrix) {
        for (var col in matrix[row]) {
            var sum = Number(matrix[row][col]);
            for (var row1 in matrix) {
                for (var col1 in matrix) {
                    //console.log(matrix[row1][col1]);
                    if (row !== row1 || col !== col1) {
                        var num = Number(matrix[row1][col1])
                        if ((sum + num) == magic) {
                            finalSum = Number(row) + Number(col) + Number(row1) + Number(col1);
                            //console.log(row + " " + col);
                            //console.log(row1 + " " + col1);
                            found = true;
                            break;
                        }
                        if (found) {
                            break;
                        }
                    }
                    if (found) {
                        break;
                    }
                }
                if (found) {
                    break;
                }
            }
            if (found) {
                break;
            }
        }
        if (found) {
            break;
        }
    }
    //console.log(finalSum);
    var text = '';
    for (var i = 0; i < message.length; i++) {
        if(i%2==0){
            text+=String.fromCharCode(message.charCodeAt(i)+finalSum);
        }
        else{
            text+=String.fromCharCode(message.charCodeAt(i)-finalSum);
        }

    }

    console.log(text);
}


deeeebaIzpitaDeeeba([
    'QqdvSpg',
    '400',
    '100 200 120',
    '120 300 310',
    '150 290 370'
])