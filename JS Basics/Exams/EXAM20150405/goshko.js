function solve(input) {
    var pattern = /{[#!*&]}/g;

    var result = {"&": 0, "*": 0, "#": 0, "!": 0, "wall hits": 0};

    var directions = input[0];
    directions = directions.split(/\s*,\s*/);

    input.splice(0, 1);

    var row = 0;
    var col = 0;

    var path = [];
    for (var i in directions) {
        var isMoved = false;
        var currRow = input[row].split(/\s*,\s*/);
        if (directions[i] == 'left') {
            if (col > 0) {
                col--;
                isMoved = true;
            }
            else {
                result['wall hits']++;
                //console.log('left');
            }
        }
        else if (directions[i] == 'right') {
            if (col < (currRow.length - 1)) {
                col++;
                isMoved = true;
            } else {
                result['wall hits']++;
                //console.log('right');

            }
        }
        else if (directions[i] == 'up') {
            if (row > 0) {
                row--;
                isMoved = true;
            } else {
                result['wall hits']++;
                //console.log('up');

            }
        }
        else if (directions[i] == 'down') {
            if (row < (input.length - 1)) {
                row++;
                isMoved = true;

            } else {
                result['wall hits']++;
                //console.log('down');

            }
        }
        currRow = input[row].split(/\s*,\s*/);
        //console.log(currRow);
        if (isMoved) {
            path.push(currRow[col]);
        }

    }


    for (var index in path) {
        var match = path[index].match(pattern);
        //while(match=  pattern.exec(path[index])!==null)
        for (var j in match) {
            result[match[j].substr(1, 1)]++;
            path[index] = path[index].replace(match[j], '@');
        }

    }

    console.log(JSON.stringify(result));
    if (path.length > 0) {
        console.log(path.join('|'));
    }
    else {
        console.log('no');
    }


}

solve([
    'right, up, up, down',
    'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj',
    'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
    'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne'
]);
