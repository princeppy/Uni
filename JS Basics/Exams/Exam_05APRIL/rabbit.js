function solve(input) {
    var directions = input[0].split(/\s*,\s*/g);
    var result = {'&': 0, '*': 0, '#': 0, '!': 0, 'wall hits': 0};
    var garden = [];
    var vegetables = [];

    for (var i = 1; i < input.length; i++) {
        var arrLine = input[i].split(/\s*,\s*/g);
        garden.push(arrLine);

    }
    var currentVegetable = garden[0][0];


    var curCol = 0;
    var curRow = 0;


    var path = [];
    var regex1 = new RegExp('\{\\*\}', 'g');
    var regex2 = new RegExp('\{\!\}', 'g');
    var regex3 = new RegExp('\{\&\}', 'g');
    var regex4 = new RegExp('\{\#\}', 'g');
    for (var obj in directions) {
        var isMoved = false;


        if (directions[obj].trim().toLowerCase() == 'right') {
            if (curCol <= garden[curRow].length - 2) {
                curCol++;
                isMoved = true;
            }
            else {
                result['wall hits']++;
            }
        }
        else if (directions[obj].trim().toLowerCase() == 'left') {
            if (curCol >= 1) {
                curCol--;
                isMoved = true;
            }
            else {
                result['wall hits']++;
            }
        }
        else if (directions[obj].trim().toLowerCase() == 'up') {
            if (curRow >= 1) {
                curRow--;
                isMoved = true;
            }
            else {
                result['wall hits']++;
            }
        }
        else if (directions[obj].trim().toLowerCase() == 'down') {
            if (curRow <= garden.length - 2) {
                curRow++;
                isMoved = true;
            }
            else {
                result['wall hits']++;
            }
        }
        currentVegetable = garden[curRow][curCol];
        if (isMoved) {
            path.push(currentVegetable);
        }



    }

    for (var index in path) {
        var match1 = path[index].match(regex1);
        var match2 = path[index].match(regex2);
        var match3 = path[index].match(regex3);
        var match4 = path[index].match(regex4);

        if (match1) {
            path[index] = path[index].replace(/\{(\*)\}/g, "@");
            currentVegetable = path[index];
            if (curCol != 0 && curCol != 0) {
                result['*'] += match1.length;
            }
        }
        if (match2) {
            path[index] = path[index].replace(/\{(\!)\}/g, "@");
            currentVegetable = path[index];
            if (curCol != 0 && curCol != 0) {
                result['!'] += match2.length;
            }
        }
        if (match3) {
            path[index] = path[index].replace(/\{(\&)\}/g, "@");
            currentVegetable = path[index];
            if (curCol != 0 && curCol != 0) {
                result['&'] += match3.length;
            }
        }
        if (match4) {
            path[index] = path[index].replace(/\{(\#)\}/g, "@");
            currentVegetable = path[index];
            if (curCol != 0 && curCol != 0) {
                result['#'] += match4.length;
            }
        }
    }
    console.log(JSON.stringify(result))

        if(path.length==0){
            console.log("no");
        }
    else {
            console.log(path.join("|"));
        }
}

solve(
    [' right    , up, up, down, right, up, up , up',
        'a{!}sdf,    as{#}aj{g}da{#}s{#}{!}d   , kjldk{**}fdffd, jdflk{#}jdfj',
        'tr{X}yrty, z{*}xx{*}z{&}xc, mncvnvcn, popipoip',
        'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne']
)

solve(
    ['up, right, left, down', 'as{!}xnk']
)