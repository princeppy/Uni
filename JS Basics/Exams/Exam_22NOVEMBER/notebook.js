function solve(input) {

    var result = {};
    var inside = {age: '', name: '', opponents: [], wins: 0, losses: 0, rank: 0};
    for (var row in input) {
        var arr = input[row].split(/\|+/g);
        var color = arr[0];

        if(!result[color]){
            result[color] = {age: '', name: '', opponents: [], wins: 0, losses: 0, rank: 0};
        }

        if (arr[1] === 'age') {
            result[color]['age'] = arr[2];
        }
        else if (arr[1] === 'name') {
            result[color].name = arr[2];
        }

        if (arr[1] === 'win') {
            result[color].wins++;
            result[color].opponents.push(arr[2]);
            result[color].opponents.sort(function(a,b){
                return a.localeCompare(b);
            });
        }
        else if (arr[1] == 'loss') {
            result[color].losses++;
            result[color].opponents.push(arr[2]);
            result[color].opponents.sort(function(a,b){
                return a.localeCompare(b);
            });
        }



    }

    for (var obj in result) {
        if(result[obj].name === ''||result[obj].age === ''){
            delete result[obj];
        }

        else{
            var rank = ((result[obj].wins+1)/(result[obj].losses+1));
            var rankRounded = (Math.round(rank*100)/100).toFixed(2);
            result[obj].rank = rankRounded;
            delete result[obj].wins;
            delete result[obj].losses;
        }

        
    }

    var result = sortObj(result);



    console.log(JSON.stringify(result))

    function sortObj(arr) {
// Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};

// Separate keys and sort them
        for (var i in arr) {
            sortedKeys.push(i);

        }
        sortedKeys.sort();

// Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];

        }
        return sortedObj;

    }

}


solve([
    'purple|age|99',
    'red|age|44',
    'blue|win|pesho',
    'blue|win|mariya',
    'purple|loss|kiko',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Yana',
    'purple|loss|Yana',
    'purple|loss|manoV',
    'purple|loss|Manov',
    'red|name|gosho',
    'blue|win|Vladko',
    'purple|loss|Yana',
    'purple|name|VladoKaramfilov',
    'blue|age|21',
    'blue|loss|Pesho'
])