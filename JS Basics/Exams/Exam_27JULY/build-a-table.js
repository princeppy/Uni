function solve(input){
    console.log('<table>');

    console.log("<tr><th>Num</th><th>Square</th><th>Fib</th></tr>");

    var start = Number(input[0]);
    var end = Number(input[1]);

    var check;

    for (var i = start; i <= end; i++) {
        var check = 'no';
        var a = (5 * Math.pow(i, 2) + 4)
        var b=(5 * Math.pow(i, 2) - 4 )

        var result = Math.sqrt(a) % 1==0;
        var res = Math.sqrt(b) % 1==0;

        if(result||res ==true){
            check = 'yes';
        }
        console.log('<tr><td>'+i+'</td><td>'+i*i+'</td><td>'+check+'</td></tr>');
    }
    console.log('</table>');
}

solve([2,6]);

solve([55,56]);