function solve(input) {
    var pattern = /([A-Za-z\s]+)(?=vs.)(vs.)([A-Za-z\s]+)(\s*:\s*)([\s*\d-]+)/;
    var players = [];
    for (var i in input) {
        var result = '';
        result = pattern.exec(input[i]);

        var player1 = result[1].trim();
        player1 = player1.replace(/\s+/, ' ');
        var player2 = result[3].trim();
        player2 = player2.replace(/\s+/, ' ');
        var results = result[5].trim();

        results = results.split(/\s+/);
        var gamesWonP1 = 0;
        var gamesLostP1 = 0;
        var gamesWonP2 = 0;
        var gamesLostP2 = 0;
        var setsWonP1 = 0;
        var setsLostP1 = 0;
        var setsWonP2 = 0;
        var setsLostP2 = 0;
        for (var j in results) {
            if (results[j][0] > results[j][2]) {
                setsWonP1 += 1;
                setsLostP2 += 1;
            }
            else {
                setsLostP1 += 1;
                setsWonP2 += 1;
            }
            gamesWonP1 += parseInt(results[j][0]);
            gamesLostP1 += parseInt(results[j][2]);
            gamesWonP2 += parseInt(results[j][2]);
            gamesLostP2 += parseInt(results[j][0]);
        }
        var matchesWonP1 = 0;
        var matchesLostP1 = 0;
        var matchesWonP2 = 0;
        var matchesLostP2 = 0;

        if (setsWonP1 > setsWonP2) {
            matchesWonP1 += 1;
            matchesLostP2 += 1;
        }
        else {
            matchesLostP1 += 1;
            matchesWonP2 += 1;
        }
            var p1exist = false;
            var p2exist = false;
            for (var obj in players) {

                if (players[obj]['name'] == player1) {
                    players[obj]['matchesWon'] +=matchesWonP1;
                    players[obj]['matchesLost'] +=matchesLostP1;
                    players[obj]['setsWon'] +=setsWonP1;
                    players[obj]['setsLost'] +=setsLostP1;
                    players[obj]['gamesWon'] +=gamesWonP1;
                    players[obj]['gamesLost'] +=gamesLostP1;
                    p1exist = true;
                }

                if (players[obj]['name'] == player2) {
                    players[obj]['matchesWon'] +=matchesWonP2;
                    players[obj]['matchesLost'] +=matchesLostP2;
                    players[obj]['setsWon'] +=setsWonP2;
                    players[obj]['setsLost'] +=setsLostP2;
                    players[obj]['gamesWon'] +=gamesWonP2;
                    players[obj]['gamesLost'] +=gamesLostP2;
                    p2exist = true;
                }
            }

            if(!p1exist){
                var p1 = {
                    'name': player1,
                    'matchesWon': matchesWonP1,
                    "matchesLost": matchesLostP1,
                    "setsWon": setsWonP1,
                    "setsLost": setsLostP1,
                    "gamesWon": gamesWonP1,
                    "gamesLost": gamesLostP1
                };
                players.push(p1);
            }
            if(!p2exist){
                var p2 = {
                    'name': player2,
                    'matchesWon': matchesWonP2,
                    "matchesLost": matchesLostP2,
                    "setsWon": setsWonP2,
                    "setsLost": setsLostP2,
                    "gamesWon": gamesWonP2,
                    "gamesLost": gamesLostP2
                };
                players.push(p2);
            }
    }

    players.sort(function(p1,p2){
        if(p1.matchesWon==p2.matchesWon){
            if(p1.setsWon==p2.setsWon){
                if(p1.gamesWon==p2.gamesWon){
                    return p1.name.localeCompare(p2.name);
                }
                return p2.gamesWon-p1.gamesWon;
            }
            return p2.setsWon-p1.setsWon;
        }
        return p2.matchesWon-p1.matchesWon;

    });

    console.log(JSON.stringify(players));
}

solve([
    'Novak Djokovic vs. Roger Federer : 6-3 6-3',
    'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
    'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
    'Andy Murray vs. David Ferrer : 6-4 7-6',
    'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
    'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
    'Pete Sampras vs. Andre Agassi : 2-1',
    'Boris Beckervs.Andre        			Agassi:2-1'
]);
