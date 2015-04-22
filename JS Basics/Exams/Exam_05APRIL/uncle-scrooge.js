function solve(input) {

    var result = {gold: 0, silver: 0, bronze: 0};
    var sum = 0;
    for (var i in input) {
        var arrLine = input[i].split(/\s+/g);
        if (arrLine[0].toLowerCase().trim() != "coin" && arrLine[0].toLowerCase().trim() != "coins") {
            continue;
        }
        if (!Number(arrLine[1].trim())) {
            continue;
        }
        if (Number(arrLine[1].trim()) % 1 != 0) {
            continue;
        }

        if(Number(arrLine[1].trim())<=0){
            continue;
        }
        sum += parseInt(arrLine[1].trim());

    }

    if (sum != 0) {
        if (sum >= 100) {
            var gold = Math.floor(sum / 100);

            sum = sum % 100;
            result.gold = gold;
        }else{
            result.gold=0;
        }
        if(sum>=10){


            var silver = Math.floor(sum / 10);

            sum = sum % 10;
            result.silver = silver;
        }else{
            result.silver=0;
        }
        if(sum>0)
        {
        var bronze = sum;
        result.bronze = bronze;}
        else{
            result.bronze = 0;
        }

    }
    for (var obj in result) {
        console.log(obj + " : " + result[obj]);
    }
}
solve([
    'Coin 1',
    'coin 2',
    'coin 5',
    'coin 10',
    'coin 20',
    'coin 50',
    'coin 100',
    'coin 200',
    'COINS 500',
    'cigars 1'

])


solve(
    [ 'coin 1 ',
        'coin two',
        'coin 5',
        'coin 10.50',
        'coin 20',
        'coin 50',
        'coin hundred',
        'cigars 1' ]

)


solve(
    [ 'Coin one',
        'coin two',
        'coin five',
        'coin ten',
        'coin twenty',
        'coin fifty',
        'coin hundred',
        'cigars 1' ]

)
