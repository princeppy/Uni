function solve(args) {

var datesFans = [];
var datesHaters = [];
var dateRelease = new Date(1973, 05, 25);
for (var i in args) {
    var arrDate = args[i].split('.');
    var d = new Date(Number(arrDate[2]), Number(arrDate[1]-1), Number(arrDate[0]));
    if (d>new Date(1900,00,01) && d < new Date(2015,00,01)) {

        datesFans.push(d);
    }
}

datesFans.sort(function (a, b) {
    var x = new Date(a);
    var y = new Date(b);

    return (x > y) ? 1 : (x < y) ? -1 : 0;
});
if (datesFans.length === 0) {
    console.log('No result')
}
else {
    var str = '';

    if (datesFans[datesFans.length - 1] > dateRelease) {


        str = 'The biggest fan of ewoks was born on ' + datesFans[datesFans.length - 1].toDateString();
        console.log(str);
    }
    if(datesFans[0]<=dateRelease){
        str = 'The biggest hater of ewoks was born on ' + datesFans[0].toDateString();
        console.log(str);
    }


}
}

//solve([
//    '22.03.2014',
//    '17.05.1933',
//    '1.15.1954'
//]);
//
//solve(['22.03.2000']);
//
//solve([
//    '22.03.1700',
//    '01.07.2020'
//    ]);
//solve([
//    '01.01.1900',
//    '01.02.1900',
//    '01.03.1900',
//    '01.04.1900',
//    '01.05.1900',
//    '01.06.1900',
//    '31.12.2014',
//    '15.11.2456'
//]);