function solve(args) {
    var regex = new RegExp('(<td>)([^<]+)(</td>)', 'g');

    var sum = -50000;


    var str;
    var count = 0;

    for (var i in args) {
        var match = args[i].match(regex);
        var tempStr = [];
        var tempSum = 0;

        if(match!=null) {

            for (var j = 1; j < match.length; j++) {
                var text = match[j];
                var m;
                while ((m = regex.exec(text)) != null) {
                    if (!isNaN(Number(m[2]))) {
                        tempSum += Number(m[2]);
                        tempStr.push(m[2]);
                        count++;
                    }


                }

            }

            if (tempSum > sum) {
                sum = tempSum;
                str = tempStr.join(' + ');
            }
        }

    }

    if(count==0){
        console.log('no data')
    }
    else {
        console.log(sum + ' = ' + str);
    }

}

//var arr = ['<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>', '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>', '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>', '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>', '</table>'];
//
//solve(arr);