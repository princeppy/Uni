function solve(input) {
    var numberOfJumps = Number(input[0]);
    var length = Number(input[1]);

    var players=[];
    //0:{name: '', jumpdistance:0, position:0},1:{name: '', jumpdistance:0, position:0},2:{name: '', jumpdistance:0, position:0},3:{name: '', jumpdistance:0, position:0}



    for (var i = 2; i < input.length; i++) {

        var arrLine = input[i].split(/,\s+/g);
        players[i-2] = {name:'', jumpdistance:'',position:''};
        players[i-2]['name'] = arrLine[0].trim();
        players[i-2]['jumpdistance'] = arrLine[1].trim();
        players[i-2]['position']=0;

    }
    var winner = '';
    var isEnd = false;
    i=0;
    for (var i = 0; i < numberOfJumps; i++) {
        j = 0;
        for (var j = 0; j < players.length; j++) {
            players[j].position +=Number(players[j].jumpdistance);
            if(players[j].position>=length-1){
                winner = players[j].name;
                players[j].position = length-1;
                isEnd = true;
                break;
            }

        }


        if(isEnd){
            break;
        }
    }
    var temp = 0;
    if(isEnd==false){
        for (var obj in players) {
            if(players[obj].position>=temp){
                temp = players[obj].position;
                winner = players[obj].name;
            }
        }
    }
    var str = new Array(length + 1).join( '#' );
    console.log(str);
    console.log(str);
    var line = '';
    for (var obj1 in players) {
        line = '';
        i = 0;
        for (var i = 0; i < length; i++) {
            if(i!=(players[obj1].position)){
                line+=".";
            }
            else{
                line+=(players[obj1].name.substr(0,1)).toUpperCase();
            }

        }
        console.log(line);
    }
    console.log(str);
    console.log(str);
    console.log("Winner: "+winner);
}

solve(
    [ '10', '19', 'angel, 10', 'Boris, 10', 'Georgi, 3', 'Dimitar, 7' ]
)

solve(
    [ '3', '5', 'cura, 1', 'Pepi, 1', 'UlTraFlee, 1', 'BOIKO, 1' ]
)